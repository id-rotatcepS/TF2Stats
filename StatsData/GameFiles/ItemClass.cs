using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StatsData.GameFiles
{

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
    public class ItemClass
    {
        internal static void ResolveItemClasses()
        {
            // TODO adding extra translation because.... why doesn't this exist already?
            string shotgun_missing = "tf_weapon_shotgun";
            string shotgun_sub = "tf_weapon_shotgun_primary";
            if (instances.ContainsKey(shotgun_sub) && !instances.ContainsKey(shotgun_missing))
                instances[shotgun_missing] = instances[shotgun_sub];
            //TODO need translation or file for "tf_wearable_demoshield" all shields and "tf_wearable" mantreads, ali baba's/bootlegger, gunboats, darwin's, camper; and "tf_wearable_razorback"
        }
        public static void LoadKnownClasses()
        {
            string[] rows = classTsv.Split("\n");
            foreach (string tsv in rows.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(tsv))
                    continue;
                new ItemClass(tsv);
            }
        }
        public static void ClearClasses()
        {
            instances.Clear();
        }
        private ItemClass(string tsv)
        {
            //"Item_Class	PrintName	BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle"
            //"tf_weapon_bat	#TF_Weapon_Bat	0	35	0	0	melee	0	0	0	0	0		0	0.5	5	0	0"
            string[] values = tsv.Split("\t");
            PrintName = values[1];
            BulletsPerShot = int.Parse(values[2]);
            Damage = decimal.Parse(values[3]);
            Spread = decimal.Parse(values[4]);
            DamageRadius = decimal.Parse(values[5]);
            WeaponType = values[6];
            TimeReload = decimal.Parse(values[7]);
            TimeReloadStart = decimal.Parse(values[8]);
            AmmoPerShot = int.Parse(values[9]);
            ClipSize = int.Parse(values[10]);
            DefaultClip = int.Parse(values[11]);
            ProjectileType = values[12];
            Range = decimal.Parse(values[13]);
            TimeFireDelay = decimal.Parse(values[14]);
            TimeIdle = decimal.Parse(values[15]);
            TimeIdleEmpty = decimal.Parse(values[16]);
            PunchAngle = decimal.Parse(values[17]);

            instances[values[0]] = this;
        }

        public ItemClass(string filename, string fileContent)
        {
            Stack<string> lines = new Stack<string>(
                fileContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Reverse<string>() // stupid just to make stack work.
                );

            ProcessHeaderAndBlock(lines, "WeaponData",
                LoadWeaponData);

            instances[filename] = this;
        }

        /// <summary>
        /// The filename without extension e.g. "tf_weapon_cannon"
        /// </summary>
        public string Name { get; set; }

        public static void ProcessHeaderAndBlock(Stack<string> lines, string layerName, Action<Stack<string>> inBlockProcessor)
        {
            if (layerName == NameClean(lines.Pop()))
            {
                if ("{" == lines.Pop().Trim())
                {
                    inBlockProcessor.Invoke(lines);
                    if (!("}" == lines.Pop().Trim()))
                        throw new BalanceException(layerName);

                    return;
                }
                // else push it back
            }
            // else push it back
        }

        private void LoadWeaponData(Stack<string> lines)
        {
            Dictionary<string, string> rows = ParseSameLayer(lines);
            try { damage = 
                    decimal.Parse(rows["damage"]); } catch { }
            try { damageRadius = 
                    decimal.Parse(rows["damageradius"]); } catch { }
            try { bulletsPerShot = 
                    int.Parse(rows["bulletspershot"]); } catch { }
            try { spread = 
                    decimal.Parse(rows["spread"]); } catch { }
            try { punchAngle = 
                    decimal.Parse(rows["punchangle"]); } catch { }
            try { timeFireDelay = 
                    decimal.Parse(rows["timefiredelay"]); } catch { } // at least one had "1.f" but that won't parse
            try { timeIdle = 
                    decimal.Parse(rows["timeidle"]); } catch { }
            try { timeIdleEmpty = 
                    decimal.Parse(rows["timeidleempty"]); } catch { }
            try { timeReloadStart = 
                    decimal.Parse(rows["timereloadstart"]); } catch { }
            try { timeReload = 
                    decimal.Parse(rows["timereload"]); } catch { }
            try { clipSize = 
                    int.Parse(rows["clip_size"]); } catch { }
            try { defaultClip = 
                    int.Parse(rows["default_clip"]); } catch { }
            try { projectileType = rows["projectiletype"]; } catch { }
            try { printName = rows["printname"]; } catch { }
            try { weaponType = rows["weapontype"]; } catch { }
            try { range = 
                    decimal.Parse(rows["range"]); } catch { }
            try { ammoPerShot = 
                    int.Parse(rows["ammopershot"]); } catch { }
            // meleeWeapon = "1"==
            // useRapidFireCrits = "1"== // e.g. flamethrower - crits for a period of time.
            //	"SmackDelay"			"0.1" (knife, 0.2 slap)
            //"Secondary_SmackDelay"      "0.3" (knife, 0.3 slap)
            //"primary_ammo"		"TF_AMMO_METAL"
            //"DontDrop"          "1"

            //Layer(lines, "SoundData", );
            //Layer(lines, "TextureData", );

            // eat the rest.
            GameItem.SkipToEnd(lines);
        }

        private decimal damage;
        private decimal damageRadius;
        private decimal spread;
        private decimal timeReload;
        private decimal timeReloadStart;
        private int clipSize;
        private int defaultClip;
        private string projectileType;
        private string printName;
        private string weaponType;
        private int bulletsPerShot;
        private decimal punchAngle;
        private decimal timeIdle;
        private decimal timeIdleEmpty;
        private decimal timeFireDelay;


        /// <summary>
        /// can include comment "per second"
        /// </summary>
        public decimal Damage { get => damage; set => damage = value; }
        public decimal DamageRadius { get => damageRadius; set => damageRadius = value; }
        public decimal Spread { get => spread; set => spread = value; }
        public int BulletsPerShot { get => bulletsPerShot; set => bulletsPerShot = value; }
        public decimal TimeReload { get => timeReload; set => timeReload = value; }
        public decimal TimeReloadStart { get => timeReloadStart; set => timeReloadStart = value; }
        public decimal Range { get => range; set => range = value; }
        public int AmmoPerShot { get => ammoPerShot; set => ammoPerShot = value; }
        public int ClipSize { get => clipSize; set => clipSize = value; }
        public decimal TimeFireDelay { get => timeFireDelay; set => timeFireDelay = value; }

        public int DefaultClip { get => defaultClip; set => defaultClip = value; }
        public string ProjectileType { get => projectileType; set => projectileType = value; }
        public string PrintName { get => printName; set => printName = value; }
        public string WeaponType { get => weaponType; set => weaponType = value; }
        public decimal PunchAngle { get => punchAngle; set => punchAngle = value; }
        public decimal TimeIdle { get => timeIdle; set => timeIdle = value; }
        public decimal TimeIdleEmpty { get => timeIdleEmpty; set => timeIdleEmpty = value; }

        public string Summary
        {
            get
            {
                return
                nameof(PrintName) + ": " + PrintName + "\n" +
                nameof(BulletsPerShot) + ": " + BulletsPerShot + "\n" +
                nameof(Damage) + ": " + Damage + "\n" +
                nameof(Spread) + ": " + Spread + "\n" +
                nameof(DamageRadius) + ": " + DamageRadius + "\n" +
                nameof(WeaponType) + ": " + WeaponType + "\n" +
                nameof(TimeReload) + ": " + TimeReload + "\n" +
                nameof(TimeReloadStart) + ": " + TimeReloadStart + "\n" +
                nameof(AmmoPerShot) + ": " + AmmoPerShot + "\n" +
                nameof(ClipSize) + ": " + ClipSize + "\n" +
                nameof(DefaultClip) + ": " + DefaultClip + "\n" +
                nameof(ProjectileType) + ": " + ProjectileType + "\n" +
                nameof(Range) + ": " + Range + "\n" +
                nameof(TimeFireDelay) + ": " + TimeFireDelay + "\n" +
                nameof(TimeIdle) + ": " + TimeIdle + "\n" +
                nameof(TimeIdleEmpty) + ": " + TimeIdleEmpty + "\n" +
                nameof(PunchAngle) + ": " + PunchAngle + "\n" +
                "";
            }
        }

        // backreference first optional quote for second quote or else a single quoted string could eat it all
        // starts with whitespace then
        // an optionally quoted string that starts and ends with a non-space (2 chars at least),
        // whitespace, then optionally quoted string that starts with a non-space OR a pair of empty quotes. 
        // optionally followed by whitespace // anything.
        internal static Regex namevalue = new Regex(@"^\s*(""([^""]*)""|([^""\s]+))\s*(""([^""]*)""|([^""\s]+))(\s*\/\/.*)?"); //2 or 3, 5 or 6
        //internal static Regex namevalue = new Regex(@"^\s*(""?)([^""\s][^""]*[^""\s])\1\s+((""?)([^""\s][^""]*)\4|"""")(\s*//.*)?");
        private decimal range;
        private int ammoPerShot;

        /// <summary>
        /// skips blanks and comments, loads namevalues into dictionary, returns when anything else encountered
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseSameLayer(Stack<string> lines)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            while (lines.Any())
            {
                string line = lines.Pop().Trim();
                if (line.StartsWith("//") || line.Length == 0)
                    continue;

                if (!namevalue.IsMatch(line))
                {
                    lines.Push(line);
                    break;
                }
                Match pair = namevalue.Match(line);
                //string name = pair.Groups[2].Value;
                //string value = pair.Groups[5].Value;
                string name = pair.Groups[2].Success ? pair.Groups[2].Value : pair.Groups[3].Value;
                string value = pair.Groups[5].Success ? pair.Groups[5].Value : pair.Groups[6].Value;

                result[name.ToLower()] = value;
            }
            return result;
        }
        public static string NameClean(string v)
        {
            string result = v.Trim();
            if (result.StartsWith('\"') && result.EndsWith('\"'))
                return result.Substring(1, result.Length - 2);
            else
                return result;
        }

        private static Dictionary<string, ItemClass> instances = new Dictionary<string, ItemClass>();
        public static ItemClass Get(string itemClassName)
        {
            if (itemClassName == null) return null;
            ItemClass result = instances.GetValueOrDefault(itemClassName);
            if (result == null && !string.IsNullOrWhiteSpace(itemClassName) && !classTsvTODO.Contains(itemClassName))
            {
                // just a line to break on so I can add to the TODO list.
                string test = itemClassName;//throw new BalanceException("Could not find class " + itemClassName);
            }
            return result;
        }
        public static List<string> AllNames()
        {
            return instances.Keys.ToList();
        }
        public static string GetName(ItemClass ic)
        {
            return instances.FirstOrDefault(pair => pair.Value == ic).Key;
        }

        private static string[] classTsvTODO = new string[] {
            "tf_wearable",
            "tf_wearable_razorback",
            "tf_wearable_demoshield",
            "saxxy", "craft_item", "no_entity", "tool" , "tf_powerup_bottle", "supply_crate", "map_token"
        };
        /// <summary>
        /// Data extracted from ctx files known to be used as weapon item_class values in items_game.txt
        /// </summary>
        private static string classTsv = @"Item_Class	PrintName	BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle
tf_weapon_bat	#TF_Weapon_Bat	0	35	0	0	melee	0	0	0	0	0		0	0.5	5	0	0
tf_weapon_bat_giftwrap	#TF_Weapon_Bat	0	35	0	0	melee	0	0	0	0	0		0	0.5	5	0	0
tf_weapon_bat_wood	#TF_Weapon_Bat	0	35	0	0	melee	0	0	0	0	0		0	0.5	5	0	0
tf_weapon_bonesaw	#TF_Weapon_Bonesaw	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_breakable_sign	#TF_Weapon_Sign	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_buff_item	#TF_Unique_Achievement_SoldierBuff1	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_builder	#TF_Weapon_Builder	0	0	0	0	building	0	0	0	0	0		0	0	0	0	0
tf_weapon_cannon	#TF_Weapon_Cannon	1	100	0	146	primary	0.6	0.1	0	4	4	projectile_cannonball	0	0.6	0.6	0.6	3
tf_weapon_charged_smg	#TF_Weapon_SMG	1	8	0.025	0	secondary	0	0	0	25	25	projectile_bullet	8192	0.1	10	1	0
tf_weapon_cleaver	#TF_Weapon_Cleaver	0	5	0	200	item1	0	0	0	-1	1	projectile_cleaver	0	0.8	5	0	0
tf_weapon_club	#TF_Weapon_Club	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_compound_bow	#TF_Weapon_CompoundBow	1	70	0	0	item2	1	0	0	1	12	projectile_arrow	8192	2	0.6	0.6	2
tf_weapon_crossbow	#TF_Weapon_Crossbow	1	75	0	0	primary	1.5	0	0	1	1	projectile_healing_bolt	0	0.23	0	0	0
tf_weapon_drg_pomson	#TF_Weapon_DRG_Pomson	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_energy_ring	8192	0.8	5	0.25	2
tf_weapon_fireaxe	#TF_Weapon_FireAxe	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_fists	#TF_Weapon_Fists	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_flamethrower	#TF_Weapon_FlameThrower	1	170	0	0	primary	0	0	0	-1	0		0	0.04	0	0	0
tf_weapon_flaregun	#TF_Weapon_FlareGun	1	30	0	0	item1	0	0	0	-1	12	projectile_flare	8192	2	0	0	2
tf_weapon_flaregun_revenge	#TF_Weapon_Raygun	1	30	0	0	secondary	0	0	0	-1	12	projectile_flare	8192	2	0	0	2
tf_weapon_grenadelauncher	#TF_Weapon_GrenadeLauncher	1	100	0	146	primary	0.6	0.1	0	4	4	projectile_pipe	0	0.6	0.6	0.6	3
tf_weapon_handgun_scout_primary	#TF_Weapon_Peppergun	4	12	0.04	0	primary	0.5	0	0	4	4	projectile_bullet	8192	0.35	5	0.25	0
tf_weapon_handgun_scout_secondary	#TF_Weapon_Pistol	1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0
tf_weapon_invis	#TF_Weapon_PDA	0	0	0	0	item1	0	0	0	0	0		0	0	0	0	0
tf_weapon_jar	#TF_Weapon_Jar	0	5	0	200	item1	0	0	0	-1	1	projectile_jar	0	0.8	5	0	0
tf_weapon_jar_gas	#TF_Weapon_GasJar	0	5	0	200		0	0	0	-1	1	projectile_jar_gas	0	0.8	5	0	0
tf_weapon_jar_milk	#TF_Weapon_MilkJar	0	5	0	200	item1	0	0	0	-1	1	projectile_jar_milk	0	0.8	5	0	0
tf_weapon_katana	#TF_Weapon_SoldierKatana	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_knife	#TF_Weapon_Knife	0	40	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_laser_pointer	#TF_Weapon_Laser_Pointer	1	4	0	0	item1	0	0	0	-1	75	projectile_bullet	8192	1.5	0	0	0
tf_weapon_lunchbox	#TF_Weapon_LunchBox	0	0	0	0	item1	0	0	0	0	0		0	0	0	0	0
tf_weapon_lunchbox_drink	#TF_Weapon_LunchBox	0	0	0	0	item1	0	0	0	0	0		0	0	0	0	0
tf_weapon_mechanical_arm	#TF_Weapon_Mechanical_Arm	1	7	0.04	0	secondary	0	0	0	0	0	projectile_bullet	256	0.15	0	0	0
tf_weapon_medigun	#TF_Weapon_Medigun	0	24	0	0	secondary	0.5	0.1	0	0	0		450	0.5	5	0.25	0
tf_weapon_minigun	#TF_Weapon_Minigun	4	9	0.08	0	primary	0	0	0	-1	0	projectile_bullet	8192	0.1	0	0	0
tf_weapon_parachute	#TF_Unique_Achievement_SoldierBuff1	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_particle_cannon	#TF_Weapon_FocusedWaveProjector	1	90	0	0	primary	0.83	0.1	0	4	4	projectile_energy_ball	0	0.8	0.8	0.8	0
tf_weapon_pep_brawler_blaster	#TF_Weapon_Scattergun	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_bullet	8192	0.625	5	0.25	3
tf_weapon_pipebomblauncher	#TF_Weapon_StickybombLauncher	1	120	0	146	secondary	0.67	0.1	0	8	8	projectile_pipe_remote	0	0.6	0.6	0.6	3
tf_weapon_pistol	#TF_Weapon_Pistol	1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0
tf_weapon_raygun	#TF_Weapon_Raygun	10	6	0.0675	0	secondary	0.5	0.1	1	6	6	projectile_energy_ring	8192	0.8	5	0.25	2
tf_weapon_revolver	#TF_Weapon_Revolver	1	40	0.025	0	secondary	0	0	0	6	6	projectile_bullet	4096	0.5	0	0	0
tf_weapon_robot_arm	#TF_Weapon_RobotArm	0	65	0	0	item2	0	0	0	-1	0		0	0.8	5	0	0
tf_weapon_rocketlauncher	#TF_Weapon_RocketLauncher	1	90	0	0	primary	0.83	0.1	0	4	4	projectile_rocket	0	0.8	0.8	0.8	0
tf_weapon_rocketlauncher_airstrike	#TF_Weapon_RocketLauncher	1	90	0	0	primary	0.83	0.1	0	4	4	projectile_rocket	0	0.8	0.8	0.8	0
tf_weapon_rocketlauncher_directhit	#TF_Weapon_RocketLauncher	1	90	0	0	primary	0.83	0.1	0	4	4	projectile_rocket	0	0.8	0.8	0.8	0
tf_weapon_rocketlauncher_fireball	#TF_Weapon_RocketLauncher	1	90	0	0	primary	0.83	0.1	0	0	0	tf_projectile_balloffire	0	0.8	0.8	0.8	1.5
tf_weapon_rocketpack	#TF_Weapon_RocketPack	0	35	0	0	melee	0	0	0	-1	2		0	0.5	5	0	0
tf_weapon_sapper	#TF_Weapon_Builder	0	0	0	0	building	0	0	0	0	0		0	0	0	0	0
tf_weapon_scattergun	#TF_Weapon_Scattergun	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_bullet	8192	0.625	5	0.25	3
tf_weapon_sentry_revenge	#TF_Weapon_Shotgun	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_bullet	8192	0.625	5	0.25	3
tf_weapon_shotgun_building_rescue	#TF_Weapon_Shotgun_Building_Rescue	1	40	0	0	primary	1	0.1	0	6	6	projectile_arrow	0	0.625	5	0.25	3
tf_weapon_shotgun_primary	#TF_Weapon_Shotgun	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_bullet	8192	0.625	5	0.25	3
tf_weapon_shovel	#TF_Weapon_Shovel	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_slap	#TF_Weapon_Slap	0	35	0	0	melee	0	0	0	0	0		0	0	5	0	0
tf_weapon_smg	#TF_Weapon_SMG	1	8	0.025	0	secondary	0	0	0	25	25	projectile_bullet	8192	0.1	10	1	0
tf_weapon_sniperrifle	#TF_Weapon_SniperRifle	1	4	0	0	primary	0	0	0	-1	75	projectile_bullet	8192	1.5	0	0	0
tf_weapon_sniperrifle_classic	#TF_Weapon_SniperRifle	1	4	0	0	primary	0	0	0	-1	75	projectile_bullet	8192	1.5	0	0	0
tf_weapon_sniperrifle_decap	#TF_Weapon_SniperRifle	1	4	0	0	primary	0	0	0	-1	75	projectile_bullet	8192	1.5	0	0	0
tf_weapon_soda_popper	#TF_Weapon_Scattergun	10	6	0.0675	0	primary	0.5	0.1	1	6	6	projectile_bullet	8192	0.625	5	0.25	3
tf_weapon_stickbomb	#TF_Weapon_StickBomb	0	55	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_sword	#TF_Weapon_Sword	0	65	0	0	melee	0	0	0	0	0		0	0.8	5	0	0
tf_weapon_syringegun_medic	#TF_Weapon_SyringeGun	1	10	0	0	primary	0	0	0	40	40	projectile_syringe	8192	0.1	0	0	0
tf_weapon_wrench	#TF_Weapon_Wrench	0	65	0	0	melee	0	0	0	-1	0		0	0.8	5	0	0
        ";
    }
}
