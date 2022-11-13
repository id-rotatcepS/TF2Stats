
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
        }
    }

    public class Scattergun : AScattergun
    {
        public Scattergun()
        {
            Name = "Scattergun";

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
        }
    }

    /// <summary>
    /// 72	6-25	97	16-65	144	18-144
    /// wiki: 69-72	6-12	97	65	144
    /// </summary>
    public class Shortstop : AScattergun
    {
        //Wiki claims "has approximately 40% less pellet spread" although it's not listed in stats
        public Shortstop() // closer to a pistol than defaults
            :base(48, 4,
                 Damage.SPREAD_PISTOL,//TODO get real value from weapon script files (wiki translates value to 50:1 vs. 48:1 pistol)
                 Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP) // yes, normal, not scattergun
        {
            Name = "Shortstop";

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
            FireRate = 0.36m;

            AlternateModes = new List<Weapon>
            {
                //TODO new ShortstopShove(); melee, 1damage, Offset = 23.5, knockback
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
                 Damage.SPREAD_SHOTGUN_SCATTERGUN*1.20m// stats: "20% less accurate"
                 )
        {
            Name = "backscatter";

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
        }
    }


}