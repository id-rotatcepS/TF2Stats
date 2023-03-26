
using System.Collections.Generic;

namespace StatsData
{

    /// <summary>
    /// myobs: 10-104	3-25	14-141	8-57	18-180	18-108
    /// wiki: 85-105	3-10	142	81	180
    /// note on first value: maybe try against a scout or something I can maybe get closer to?
    /// </summary>
    public abstract class AScattergun : AShotgun // literally "Scout Shotgun" in some languages.
    {
        public AScattergun(decimal baseDamage = 60, int fragments = 10,
            decimal spread = Damage.SPREAD_SHOTGUN_SCATTERGUN, 
            decimal zeroRange = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP)
            : base(baseDamage, fragments,
                 spread, zeroRange)
        {
            Name = "scattergun";
            Notes = "";// blank out from shotgun.

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(baseDamage)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,// 0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = fragments,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo = new Ammo(6, 32) // same as shotgun
            {
                ReloadFirst = 0.7m,
                ReloadAdditional = 0.5m, // same as shotgun
            };
        }
    }

    public class Scattergun : AScattergun
    {
        public Scattergun()
        {
            Name = "Scattergun";
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Double-barreled lever-action shotgun:"),
            new PositiveAttribute("+17% close range damage bonus"),
            new PositiveAttribute("-30% faster first shot reload"),
            });
           
            Name = "Scattergun"; Level = 1; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n60 damage (96 dps) 175%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.2 sec (first in 0.7 sec), 32 carried"),
});
            Notes += "wiki/calc close 105, but obs 104; minicrit calc 142 but obs/'wiki' 141\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET (32 doesn't match)\n";
            Notes += "obs close 10-104 matches my offsets and not wiki\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,// 0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;
        }
    }

    /// <summary>
    /// 113	3-23	152	7-51	16-194	16-113
    /// wiki: 92-113	3-11	153	87	194
    /// </summary>
    public class ForceANature : AScattergun
    {
        public ForceANature()
            : base(64.8m,
            12)
        {
            Name = "Force-A-Nature";
            Name = "Force-A-Nature"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% faster firing speed"),
new PositiveAttribute("Knockback on the target and shooter"),
new PositiveAttribute("+20% bullets per shot"),
new NegativeAttribute("-10% damage penalty"),
new NegativeAttribute("-66% clip size"),
new DescriptionAttribute("This weapon reloads its entire clip at once"),
});
            Notes += "minicrit 'wiki'/calc close 153, but obs 152\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET (32 doesn't match)\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(64.8)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.53,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 12,
            //        FragmentType = "pellet",
            //    },

            //};
            FireRate = 0.3125m;

            Ammo = new Ammo(2, 32)
            {
                Reload = 1.4333m,
            };
        }
    }

    /// <summary>
    /// 72	6-25	97	16-65	144	18-144
    /// wiki: 69-72	6-12	97	65	144
    /// </summary>
    public class Shortstop : AScattergun
    {
        public Shortstop() // closer to a pistol than defaults
            :base(48, 4,
                 Damage.SPREAD_PISTOL,// per ctx
                 Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP) // yes, normal, not scattergun
            //tf_weapon_handgun_scout_primary Damage=12 BulletsPerShot=4, Spread=0.04 (pistol), TimeFireDelay=0.35
        {
            Name = "Shortstop";
            Name = "Shortstop"; Level = 1; WeaponType = "Peppergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new NegativeAttribute("Increase in push force taken from damage and airblast"),
new DescriptionAttribute("Holds a 4-shot clip and reloads its entire clip at once.<br> Alt-Fire to reach and shove someone! <br><br>Mann Co.'s latest in high attitude break-action personal defense."),
});
            Notes += "Close range works with 30, 25 (scatter current default), also most anything else (23.5-32)\n" +
                "Wiki claims \"has approximately 40% less pellet spread\" although it's not listed in stats. really it's pistol-spread per ctx file.\n";
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(48)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP, // yes, normal, not scattergun
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.53,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 4,
            //        FragmentType = "pellet",
            //    },

            //};
            FireRate = 0.36m; //TODO 0.36 in wiki. would prefer file value 0.35

            Ammo = new Ammo(4, 32)
            {
                Reload = 1.52m,
            };

            AlternateModes = new List<Weapon>
            {
            };
            SeparateModes = new List<Weapon>
            {
                new ShortstopShove()
            };
        }
    }

    public class ShortstopShove : MeleeWeapon
    {
        //melee, 1damage, Offset = 23.5, knockback
        public ShortstopShove()
            :base(1)
        {
            Name = "Shove";

            FireRate = 1.5m;

            Effect = new Effect()
            {
                Name = "Shove knockback"
            };
        }
    }

    /// <summary>
    /// 104	3-22	141	8-41	180	18-126
    /// wiki: 85-105	3-10	142	81	180
    /// </summary>
    public class SodaPopper : AScattergun
    {
        public SodaPopper()
        {
            Name = "Soda Popper";
            Name = "Soda Popper"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% faster firing speed"),
new PositiveAttribute("25% faster reload time"),
new PositiveAttribute("On Hit: Builds Hype"),
new NegativeAttribute("-66% clip size"),
new DescriptionAttribute("When Hype is full, Alt-Fire to activate Hype mode for multiple air jumps.<br>This weapon reloads its entire clip at once."),
});
            Notes += "wiki/calc close 105, but obs 104; minicrit calc/'wiki' 142 but obs 141\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET (32 doesn't match)\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },
            //};
            FireRate = 0.3125m;

            Ammo = new Ammo(2, 32)
            {
                Reload = 1.1333m,
            };
        }
    }

    /// <summary>
    /// 104	3-19	141	8-57	180	18-108
    /// wiki: 85-105	3-10	142	81	180
    /// </summary>
    public class BabyFacesBlaster : AScattergun
    {
        public BabyFacesBlaster()
        {
            Name = "baby face's blaster";
            Name = "Baby Face's Blaster"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Builds Boost"),
new PositiveAttribute("Run speed increased with Boost"),
new NegativeAttribute("-34% clip size"),
new NegativeAttribute("10% slower move speed on wearer"),
new NegativeAttribute("Boost reduced on air jumps"),
new NegativeAttribute("Boost reduced when hit"),
}); 
            Notes += "wiki/calc close 105, but obs 104; minicrit calc/'wiki' 142 but obs 141\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET (32 doesn't match)\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo.Loaded = 4;
        }
    }

    /// <summary>
    /// 104	3-19	141	8-41	180	18-108
    /// wiki: 85-105	3-10	142	81	180
    /// </summary>
    public class BackScatter : AScattergun
    {
        public BackScatter()
            :base(60, 10, 
                 Damage.SPREAD_SHOTGUN_SCATTERGUN*1.20m// stats: "20% less accurate" ; items_game.txt value: 1.20 
                 )
        {
            Name = "backscatter";
            Name = "Back Scatter";/*Level*/WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Mini-crits targets when fired at their back from close range"),
new NegativeAttribute("-34% clip size"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("20% less accurate"),
});
            Notes += "wiki/calc close 105, but obs 104; minicrit calc/'wiki' 142 but obs 141\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET (32 doesn't match)\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SCATTERGUN,
            //        ZeroRangeRamp = Damage.SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo.Loaded = 4;
        }
    }


}