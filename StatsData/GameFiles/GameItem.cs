using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsData.GameFiles
{
    /// <summary>
    /// represent an entry of items_game.txt for a named prefab or a numbered (weapon) item, or a merger of both.
    /// </summary>
    public class GameItem
    {

        public static void LoadPrefabsItemsAndResolve(string fileContent)
        {
            Stack<string> lines = new Stack<string>(
                            fileContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                            .ToList()
                            .Reverse<string>()//this is stupid just to make stack work
                            );

            SkipToNamedBlockAndProcess(lines, "items_game", PrefabsAndItems);

            ResolveItems();
        }

        internal static void SkipToNamedBlockAndProcess(Stack<string> lines, string layer, Action<string, Stack<string>> inBlockProcessor)
        {
            while (lines.Any())
            {
                string n = lines.Pop();
                bool blockHeading = !ItemClass.namevalue.IsMatch(n);

                string next = ItemClass.NameClean(n);
                if (next.Length == 0 || next.StartsWith("//"))
                    continue;

                if (next.StartsWith("}"))
                {
                    lines.Push(next);
                    break;
                }

                if (blockHeading)
                {
                    if (layer == null || layer == next)
                    {
                        if (ProcessBlockWith(lines, next, inBlockProcessor))
                            //specific requested layer processed? or process all of them.
                            if (layer != null)
                                return;
                    }
                    else
                        EatBlock(lines);
                }

            }
        }

        private static bool ProcessBlockWith(Stack<string> lines, string nameOfBlock, Action<string, Stack<string>> inBlockProcessor)
        {
            string firstline = lines.Pop();
            if (firstline.Trim().StartsWith("{"))
            {
                inBlockProcessor.Invoke(nameOfBlock, lines);
                if (!lines.Pop().Trim().StartsWith("}"))
                {
                    throw new BalanceException(nameOfBlock);
                }
                return true;
            }
            else
                lines.Push(firstline);

            return false;
        }

        private static void EatBlock(Stack<string> lines)
        {
            string firstline = lines.Pop();
            if (firstline.Trim().StartsWith("{"))
            {
                EatRestOfBlock(lines);
            }
            else
                lines.Push(firstline);
        }

        private static string EatRestOfBlock(Stack<string> lines)
        {
            string line = null;
            int balance = 1;
            while (balance > 0)
            {
                line = lines.Pop().Trim();
                if (line.StartsWith("{"))
                    ++balance;
                if (line.StartsWith("}"))
                    --balance;
            }

            return line;
        }

        /// <summary>
        /// misc dir had 78 .ctx weapon files...there are maybe 190 weapons.
        ///tf/scripts/items/items_game.txt
        ///items_game.items."0"
        ///.name (unique name)
        ///.item_name (localizer)
        ///.prefab (space-separated list of prefabs to apply)
        ///.baseitem(bool)
        ///.item_class(.ctx filename).. make custom classes for the 78 ctx files
        ///etc.
        ///items_game.prefabs."weapon_atom_launcher" etc.
        ///also, objects.txt is a file I had for huds that describes key details of sentries and sappers.Where is it??? would have been at top level above scripts I think.
        /// </summary>
        private static void PrefabsAndItems(string items_game, Stack<string> lines)
        {
            prefabInstances.Clear();
            itemInstances.Clear();
            SkipToNamedBlockAndProcess(lines, "prefabs", LoadPrefabs);
            SkipToNamedBlockAndProcess(lines, "items", LoadMainItems);
            // then the "attributes" section
            /*
		        "1"
		        {
			        "name"	"damage penalty"
			        "attribute_class"	"mult_dmg"
			        "description_string"	"#Attrib_DamageDone_Negative"
			        "description_format"	"value_is_percentage"
			        "hidden"	"0"
			        "effect_type"	"negative"
			        "stored_as_integer"	"0"
		        }
            */
            // then the "item_criteria_templates" and other short templates sections...etc.
            SkipToEnd(lines);
        }

        private static List<GameItem> prefabInstances = new List<GameItem>();
        private static void LoadPrefabs(string prefabs, Stack<string> lines)
        {
            ProcessOnlyNamedBlocks(lines, (blockName, lns) => prefabInstances.Add(new GameItem(blockName, lns)));
        }

        internal static void ProcessOnlyNamedBlocks(Stack<string> lines, Action<string, Stack<string>> inNamedBlockProcessor)
        {
            SkipToNamedBlockAndProcess(lines, null, inNamedBlockProcessor);
        }

        private static List<GameItem> itemInstances = new List<GameItem>();
        private static List<string> itemIDs = new List<string>
        {
            "0","1","2","3","4","5","6","7","8","9",
            "10","11","12","13","14","15","16","17","18","19",
            "20","21","22","23","24","25","26","27","28","29",
            "30","735","736","1132","1152","1163","35","36","37","38","39",
            "40","41","42","43","44","45","46","56","57","58","59","60","61",
            "127","128","129","130","131","132","133",
            "140","141","142","153","154","155","159",
            "160","161","163","169","171","172","173",
            "190","191","192","193","194","195","196","197","198","199",
            "200","201","202","203","204","205","206","207","208","209","210","211","212",
            "214","215","220","221","222","224","225","226","228","230","231","232","237","239",
            "264","265","266","294","297","298","304","305","307","308","310","311","312","317","325","326","327","329","331","348","349","351","354","355","356","357",
            "401","402","404","405","406","411","412","413","414","415","416","423","424","425","426","433","441","442","444","447","448","449",
            "450","451","452","457","460","461","466","474",//consc. obj
            "482","489","513","525","526","527","528","572","574","587","588","589","593","594","595",
            "608","609","638","642","648","649",
            //Festive minigun:
            "654","656","658","659","660","661","662","663","664","665","669","727",
            // beggar's
            "730","739","740","741","751","752","772","773","775",
            //botkiller
            //"792","793","794","795","796","797","798","799","800","801","802","803","804","805","806","807","808","809",
            "810","811","812","813","831","832","833","834",
            // minigun "Deflector":
            "850",
            //awper hand:
            "851","863","880",
            // rust botkiller
            //"881","882","883","884","885","886","887","888","889","890","891","892","893","894","895","896","897","898","899","900","901","902","903","904","905","906","907","908","909","910","911","912","913","914","915","916",
            "933","939","947","954",
            // botkillers
            //"957","958","959","960","961","962","963","964","965","966","967","968","969","970","971","972","973","974",
            "996","997","998","999","1000","1001","1002","1003","1004","1005","1006","1007","1013",
            "1071", //golden pan
            "1078","1079","1080","1081","1082","1083","1084","1085","1086","1092","1098","1099","1100","1101","1102","1103","1104","1105","1121","1123","1127","1141","1142","1143","1144","1145","1146","1149",
            "1150","1151","1153",
            "1155",// TF_WEAPON_PASSTIME_GUN
            "1178","1179","1180","1181",
            //MVM
            "1184",
            "1190",
            //... painteds ...
            "30474","30665","30666","30667","30668","30758"
            // last entry before tournament medals: "31346"... last actual entry "20009" a strangifier recipe

        };
        private static void LoadMainItems(string items, Stack<string> lines)
        {
            ProcessOnlyNamedBlocks(lines,
                (blockName, lns) =>
                {
                    if (itemIDs.Contains(blockName))
                        itemInstances.Add(new GameItem(blockName, lns));
                    else
                        EatBlockBody(lns);
                });
        }

        private static void EatBlockBody(Stack<string> lines)
        {
            string line = EatRestOfBlock(lines);
            lines.Push(line);
        }

        internal static void SkipToEnd(Stack<string> lines)
        {
            EatBlockBody(lines);
            //SkipToNamedBlockAndProcess(lines, "now we skip to the end", null);
        }

        private static List<GameItem> resolvedInstances = new List<GameItem>();
        private static void ResolveItems()
        {
            resolvedInstances.Clear();
            foreach (GameItem item in itemInstances)
            {
                List<GameItem> prefablist = GetPrefabList(item);
                resolvedInstances.Add(new GameItem(item.PrefabItemID, item, prefablist.ToArray()));
            }
        }

        public static GameItem Get(string itemID)
        {
            return resolvedInstances.FirstOrDefault(i => i.PrefabItemID == itemID);
        }

        private static List<GameItem> GetPrefabList(GameItem item)
        {
            List<GameItem> prefablist = new List<GameItem>();
            if (item?.Prefab == null) return prefablist;
            string[] prefabnames = item.Prefab.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string prefabname in prefabnames)
            {
                GameItem pre = prefabInstances.FirstOrDefault(g => g.PrefabItemID?.ToLower() == prefabname?.ToLower());
                if (pre != null)
                {
                    prefablist.Add(pre);
                    prefablist.AddRange(GameItem.GetPrefabList(pre));
                }
            }

            return prefablist;
        }


        public GameItem(string itemEntry, GameItem basis, params GameItem[] prefabs)
        {
            this.PrefabItemID = itemEntry;
            this.PrefabList = prefabs.ToList();
            // order for overwriting?
            foreach (GameItem prefab in prefabs)
            {
                Load(prefab);
            }
            // assuming the main entry's values are highest priority.
            Load(basis);
        }

        private void Load(GameItem prefab)
        {
            Base_Item_Name = prefab.Base_Item_Name ?? Base_Item_Name;
            First_Sale_Date = prefab.First_Sale_Date ?? First_Sale_Date;
            Item_Class = prefab.Item_Class ?? Item_Class;
            Item_Name = prefab.Item_Name ?? Item_Name;
            Item_Quality = prefab.Item_Quality ?? Item_Quality;
            Item_Slot = prefab.Item_Slot ?? Item_Slot;
            Item_Type_Name = prefab.Item_Type_Name ?? Item_Type_Name;
            if (prefab.Max_ILevel != 0)
                Max_ILevel = prefab.Max_ILevel;
            if (prefab.Min_ILevel != 0)
                Min_ILevel = prefab.Min_ILevel;
            Name = prefab.Name ?? Name;
            Xifier_Class_Remap = prefab.Xifier_Class_Remap ?? Xifier_Class_Remap;

            Prefab = ((Prefab ?? "")
                + " "
                + (prefab.Prefab ?? "")).Trim();

            foreach (var entry in prefab.Attributes) Attributes[entry.Key] = entry.Value;
            foreach (var entry in prefab.Tags) Tags[entry.Key] = entry.Value;
            foreach (var entry in prefab.Static_Attrs) Static_Attrs[entry.Key] = entry.Value;
        }
        public string Summary
        {
            get
            {
                return
                nameof(Name) + ": " + Name + "\n" +
                nameof(Base_Item_Name) + ": " + Base_Item_Name + "\n" +
                nameof(Item_Name) + ": " + Item_Name + "\n" +
                nameof(Item_Quality) + ": " + Item_Quality + "\n" +
                nameof(Item_Slot) + ": " + Item_Slot + "\n" +
                nameof(Item_Type_Name) + ": " + Item_Type_Name + "\n" +
                nameof(Max_ILevel) + ": " + Max_ILevel + "\n" +
                nameof(Min_ILevel) + ": " + Min_ILevel + "\n" +
                nameof(First_Sale_Date) + ": " + First_Sale_Date + "\n" +
                nameof(Xifier_Class_Remap) + ": " + Xifier_Class_Remap + "\n" +
                nameof(Prefab) + ": " + Prefab + "\n" +
                nameof(Tags) + ":\n" +
                DictSummary(Tags) +
                nameof(Attributes) + ":\n" +
                DictSummary(Attributes) +
                nameof(Static_Attrs) + ":\n" +
                DictSummary(Static_Attrs) +
                "---& Item_Class:---\n" +
                Item_Class?.Summary ?? "--- none ---";
            }
        }

        private string DictSummary(Dictionary<string, string> attributes)
        {
            string result = "";
            foreach (var entry in attributes)
            {
                result += "\t" + entry.Key + ": " + entry.Value + "\n";
            }
            return result;
        }

        /// <summary>
        /// Processes inside of block as properties for the gameitem.
        /// </summary>
        /// <param name="itemEntry"></param>
        /// <param name="lines"></param>
        public GameItem(string itemEntry, Stack<string> lines)
        {
            this.PrefabItemID = itemEntry;
            this.PrefabList = null;

            while (lines.Any())
            {
                LoadItemData(lines);
                // next "must be" a non-(namevalue, blank, or comment)
                string next = ItemClass.NameClean(lines.Pop());
                if (next.StartsWith("}"))
                {
                    lines.Push(next);
                    break;
                }
                // not end of block, only other thing I know of is the header for a sub-block.

                Dictionary<string, Action<string, Stack<string>>> simpleMappers = new Dictionary<string, Action<string, Stack<string>>>()
                {
                    ["tags"] = TagsProcess,
                    ["static_attrs"] = StaticAttrsProcess,
                    //["used_by_classes"]=null,
                };
                Dictionary<string, Action<string, Stack<string>>> complexMappers = new Dictionary<string, Action<string, Stack<string>>>()
                {
                    ["attributes"] = AttributesProcess,
                    //["used_by_classes"]=null,
                };

                if (simpleMappers.ContainsKey(next))
                {
                    Action<string, Stack<string>> loadWeaponData = simpleMappers[next];
                    _ = ProcessBlockWith(lines, next, loadWeaponData);

                }
                else
                if (complexMappers.ContainsKey(next))
                {
                    Action<string, Stack<string>> loadWeaponData = complexMappers[next];
                    ProcessBlockWith(lines, next,
                        (n, lns) => ProcessOnlyNamedBlocks(lns, loadWeaponData));
                }
                else
                    EatBlock(lines);

            }

        }

        private void TagsProcess(string tags, Stack<string> lines)
        {
            Dictionary<string, string> rows = ItemClass.ParseSameLayer(lines);
            Tags = rows;
        }
        public Dictionary<string, string> Tags = new Dictionary<string, string>();

        private void AttributesProcess(string attributeName, Stack<string> lines)
        {
            /*
                "mod sentry killed revenge"
                {
                    "attribute_class"	"sentry_killed_revenge"
                    "value"	"1"
                }
             */
            try
            {

                Dictionary<string, string> parts = ItemClass.ParseSameLayer(lines);

                Attributes[attributeName] = parts["attribute_class"] + "=" + parts["value"];
            }
            catch { }
        }
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();

        private void StaticAttrsProcess(string static_attrs, Stack<string> lines)
        {
            Dictionary<string, string> rows = ItemClass.ParseSameLayer(lines);
            Static_Attrs = rows;
        }
        public Dictionary<string, string> Static_Attrs = new Dictionary<string, string>();

        public ItemClass Item_Class { get; set; }
        public string Name { get; private set; }
        public string Prefab { get; private set; }
        public string Item_Type_Name { get; private set; }
        public string Item_Name { get; private set; }
        public string Item_Slot { get; private set; }
        public string Item_Quality { get; private set; }
        public int Min_ILevel { get; private set; }
        public int Max_ILevel { get; private set; }
        public string Base_Item_Name { get; private set; }
        public string First_Sale_Date { get; private set; }
        public string Xifier_Class_Remap { get; private set; }
        public string PrefabItemID { get; }
        public List<GameItem> PrefabList { get; }

        private void LoadItemData(Stack<string> lines)
        {
            Dictionary<string, string> rows = ItemClass.ParseSameLayer(lines);
            try
            {
                ItemClass itmcls = ItemClass.Get(rows["item_class"]);
                if (Item_Class != null && itmcls != null)
                {
                    throw new BalanceException("item_class=" + Item_Class.Name + " AND " + itmcls.Name);
                }
                Item_Class = Item_Class ?? itmcls;
            }
            catch { }
            try
            {
                Name = rows["name"]; // e.g. TF_WEAPON_BAT
            }
            catch { }
            try
            {
                Xifier_Class_Remap = rows["xifier_class_remap"];
            }
            catch { }
            try
            {
                Prefab = rows["prefab"];
            }
            catch { }
            try
            {
                Item_Type_Name = rows["item_type_name"];
            }
            catch { }
            try
            {
                Base_Item_Name = rows["base_item_name"];
            }
            catch { }
            try
            {
                First_Sale_Date = rows["first_sale_date"];
            }
            catch { }
            try
            {
                Item_Name = rows["item_name"];
            }
            catch { }
            try
            {
                Item_Slot = rows["item_slot"];
            }
            catch { }
            try
            {
                Item_Quality = rows["item_quality"];
            }
            catch { }
            try
            {
                Min_ILevel = int.Parse(rows["min_ilevel"]);
            }
            catch { }
            try
            {
                Max_ILevel = int.Parse(rows["max_ilevel"]);
            }
            catch { }

        }
        //private void Layer(Stack<string> lines, string layerName, Action<Stack<string>> loadWeaponData)
        //{
        //    if (layerName == ItemClass.NameClean(lines.Pop()))
        //    {
        //        if ("{" == lines.Pop().Trim())
        //        {
        //            loadWeaponData.Invoke(lines);
        //            if (!("}" == lines.Pop().Trim()))
        //                throw new BalanceException(layerName);

        //            return;
        //        }
        //        // else push it back
        //    }
        //    // else push it back
        //}

        /// <summary>
        /// null if not found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetItemClassNameForID(string id) => id != null && idToItemClass.ContainsKey(id) ? idToItemClass[id] : null;
        /// <summary>
        /// based in items_game.txt 12/21/2022
        /// </summary>
        private static Dictionary<string, string> idToItemClass = new Dictionary<string, string>
        {
            ["588"] = "tf_weapon_drg_pomson",
            ["442"] = "tf_weapon_raygun",
            ["39"] = "tf_weapon_flaregun",
            ["351"] = "tf_weapon_flaregun",
            ["595"] = "tf_weapon_flaregun_revenge",
            ["740"] = "tf_weapon_flaregun",
            ["56"] = "tf_weapon_compound_bow",
            ["305"] = "tf_weapon_crossbow",
            ["997"] = "tf_weapon_shotgun_building_rescue",
            ["22"] = "tf_weapon_pistol",
            ["528"] = "tf_weapon_mechanical_arm",
            ["140"] = "tf_weapon_laser_pointer",
            ["23"] = "tf_weapon_pistol",
            ["449"] = "tf_weapon_handgun_scout_secondary",
            ["773"] = "tf_weapon_handgun_scout_secondary",
            ["18"] = "tf_weapon_rocketlauncher",
            ["127"] = "tf_weapon_rocketlauncher_directhit",
            ["228"] = "tf_weapon_rocketlauncher",
            ["414"] = "tf_weapon_rocketlauncher",
            ["441"] = "tf_weapon_particle_cannon",
            ["730"] = "tf_weapon_rocketlauncher",
            ["1104"] = "tf_weapon_rocketlauncher_airstrike",
            ["9"] = "tf_weapon_shotgun_primary",
            ["415"] = "tf_weapon_shotgun_primary",
            ["1153"] = "tf_weapon_shotgun_primary",
            ["425"] = "tf_weapon_shotgun_primary",
            ["141"] = "tf_weapon_sentry_revenge",
            ["527"] = "tf_weapon_shotgun_primary",
            ["13"] = "tf_weapon_scattergun",
            ["45"] = "tf_weapon_scattergun",
            ["220"] = "tf_weapon_handgun_scout_primary",
            ["448"] = "tf_weapon_soda_popper",
            ["772"] = "tf_weapon_pep_brawler_blaster",
            ["1103"] = "tf_weapon_scattergun",
            ["21"] = "tf_weapon_flamethrower",
            ["40"] = "tf_weapon_flamethrower",
            ["215"] = "tf_weapon_flamethrower",
            ["594"] = "tf_weapon_flamethrower",
            ["1178"] = "tf_weapon_rocketlauncher_fireball",
            ["19"] = "tf_weapon_grenadelauncher",
            ["308"] = "tf_weapon_grenadelauncher",
            ["996"] = "tf_weapon_cannon",
            ["1151"] = "tf_weapon_grenadelauncher",
            ["20"] = "tf_weapon_pipebomblauncher",
            ["130"] = "tf_weapon_pipebomblauncher",
            ["1150"] = "tf_weapon_pipebomblauncher",
            ["15"] = "tf_weapon_minigun",
            ["41"] = "tf_weapon_minigun",
            ["312"] = "tf_weapon_minigun",
            ["424"] = "tf_weapon_minigun",
            ["811"] = "tf_weapon_minigun",
            ["17"] = "tf_weapon_syringegun_medic",
            ["36"] = "tf_weapon_syringegun_medic",
            ["412"] = "tf_weapon_syringegun_medic",
            ["14"] = "tf_weapon_sniperrifle",
            ["230"] = "tf_weapon_sniperrifle",
            ["402"] = "tf_weapon_sniperrifle_decap",
            ["526"] = "tf_weapon_sniperrifle",
            ["752"] = "tf_weapon_sniperrifle",
            ["1098"] = "tf_weapon_sniperrifle_classic",
            ["16"] = "tf_weapon_smg",
            ["751"] = "tf_weapon_charged_smg",
            ["24"] = "tf_weapon_revolver",
            ["61"] = "tf_weapon_revolver",
            ["224"] = "tf_weapon_revolver",
            ["460"] = "tf_weapon_revolver",
            ["525"] = "tf_weapon_revolver",
            ["812"] = "tf_weapon_cleaver",
            //131	
            //406	
            //1099	
            ["1179"] = "tf_weapon_rocketpack",
            //444	
            ["129"] = "tf_weapon_buff_item",
            ["226"] = "tf_weapon_buff_item",
            ["354"] = "tf_weapon_buff_item",
            ["29"] = "tf_weapon_medigun",
            ["35"] = "tf_weapon_medigun",
            ["411"] = "tf_weapon_medigun",
            ["998"] = "tf_weapon_medigun",
            ["1101"] = "tf_weapon_parachute",
            //133	
            //405	
            //57	
            //231	
            //642	
            ["42"] = "tf_weapon_lunchbox",
            ["159"] = "tf_weapon_lunchbox",
            ["311"] = "tf_weapon_lunchbox",
            ["1190"] = "tf_weapon_lunchbox",
            ["46"] = "tf_weapon_lunchbox_drink",
            ["163"] = "tf_weapon_lunchbox_drink",
            ["58"] = "tf_weapon_jar",
            ["222"] = "tf_weapon_jar_milk",
            ["1180"] = "tf_weapon_jar_gas",
            ["735"] = "tf_weapon_builder",
            ["810"] = "tf_weapon_sapper",
            ["30"] = "tf_weapon_invis",
            ["59"] = "tf_weapon_invis",
            ["60"] = "tf_weapon_invis",
            ["7"] = "tf_weapon_wrench",
            ["155"] = "tf_weapon_wrench",
            ["329"] = "tf_weapon_wrench",
            ["589"] = "tf_weapon_wrench",
            ["142"] = "tf_weapon_robot_arm",
            ["4"] = "tf_weapon_knife",
            ["225"] = "tf_weapon_knife",
            ["356"] = "tf_weapon_knife",
            ["461"] = "tf_weapon_knife",
            ["649"] = "tf_weapon_knife",
            ["0"] = "tf_weapon_bat",
            ["44"] = "tf_weapon_bat_wood",
            ["317"] = "tf_weapon_bat",
            ["325"] = "tf_weapon_bat",
            ["349"] = "tf_weapon_bat",
            ["355"] = "tf_weapon_bat",
            ["450"] = "tf_weapon_bat",
            ["648"] = "tf_weapon_bat_giftwrap",
            ["775"] = "tf_weapon_shovel",
            ["447"] = "tf_weapon_shovel",
            ["1181"] = "tf_weapon_slap",
            ["214"] = "tf_weapon_fireaxe",
            ["239"] = "tf_weapon_fists",
            ["426"] = "tf_weapon_fists",
            ["154"] = "tf_weapon_shovel",
            ["357"] = "tf_weapon_katana",
            ["128"] = "tf_weapon_shovel",
            ["416"] = "tf_weapon_shovel",
            ["38"] = "tf_weapon_fireaxe",
            ["153"] = "tf_weapon_fireaxe",
            ["326"] = "tf_weapon_fireaxe",
            ["348"] = "tf_weapon_fireaxe",
            ["593"] = "tf_weapon_fireaxe",
            ["813"] = "tf_weapon_breakable_sign",
            ["132"] = "tf_weapon_sword",
            ["307"] = "tf_weapon_stickbomb",
            ["327"] = "tf_weapon_sword",
            ["404"] = "tf_weapon_sword",
            ["172"] = "tf_weapon_sword",
            ["43"] = "tf_weapon_fists",
            ["310"] = "tf_weapon_fists",
            ["656"] = "tf_weapon_fists",
            ["331"] = "tf_weapon_fists",
            ["37"] = "tf_weapon_bonesaw",
            ["173"] = "tf_weapon_bonesaw",
            ["304"] = "tf_weapon_bonesaw",
            ["413"] = "tf_weapon_bonesaw",
            ["171"] = "tf_weapon_club",
            ["232"] = "tf_weapon_club",
            ["401"] = "tf_weapon_club",
        };
    }
}
