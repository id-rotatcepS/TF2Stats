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
            return instances.GetValueOrDefault(itemClassName);
        }
        public static List<string> AllNames()
        {
            return instances.Keys.ToList();
        }
        public static string GetName(ItemClass ic)
        {
            return instances.FirstOrDefault(pair => pair.Value == ic).Key;
        }
    }
}
