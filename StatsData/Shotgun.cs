using System.Collections.Generic;

namespace StatsData
{
    /// <summary>
    /// 9-90	3-22	12-121	8-49	18-180	18-144
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public abstract class AShotgun : Weapon
    {
        //TODO wiki spread 30:1, but calc is 28:1 (28.148repeating)
        //TODO wiki all pellets far 30, but calc is 32, need evidence
        public AShotgun(decimal baseDamage = 60, int fragments = 10, decimal spread = Damage.SPREAD_SHOTGUN_SCATTERGUN, decimal zeroRange = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP)
        {
            Name = "Shotgun";
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
                    ZeroRangeRamp = zeroRange ,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP
                },
                Fragmentation = new Fragmentation(spread)
                {
                    Fragments = fragments,
                    FragmentType = "pellet",
                }
            };
            FireRate = 0.625m;
        }
    }

    public class Shotgun : AShotgun
    {
        public Shotgun()
        {
            Name = "Shotgun";
        }
    }

    public class xShotgun : Weapon
    {
        public xShotgun()
        {
            Name = "shotgun";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(60)
                {
                    Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
                },
                Fragmentation = new Fragmentation(Damage.SPREAD_SHOTGUN_SCATTERGUN)
                {
                    Fragments = 10,
                    FragmentType = "pellet",
                },

            };
            FireRate = 0.625m;
        }
    }

    /// <summary>
    /// 90	3-19	121	8-41	180	18-108
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class ReserveShooter : AShotgun
    {
        public ReserveShooter()
        {
            Name = "reserve shooter";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
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
    /// 108	3-18	145	6-13	216	14-43
    /// wiki: 104-108	3-10	146	97	216
    /// </summary>
    public class PanicAttack : AShotgun
    {
        // +50% bullets per shot; -20% damage penalty; spread gimmick
        //TODO (probably just from stock issue) wiki far max 36, calc is 38
        public PanicAttack()
            :base(72, 
                 15)
        {
            Name = "panic attack";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(72)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 15,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            AlternateModes = new List<Weapon>
            {
                new PanicAttack6thShot()
            };
        }
    }

    public class PanicAttack6thShot : AShotgun
    {
        public PanicAttack6thShot()
             : base(72,
                 15, 
                 0.0945m)
        {
            Name = "6th shot";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(72)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0945)
            //    {
            //        Fragments = 15,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

        }
    }

    /// <summary>
    /// 76	5-19	103	7-48	153	15-122
    /// wiki: 74-76	3-10	100	70	153
    /// </summary>
    public class FamilyBusiness : AShotgun
    {
        //TODO obs/wiki close max is 76, calc is 77  (and long wiki is 26, calc is 27 - relates to stock tho)
        public FamilyBusiness()
            :base(51)
        {
            Name = "family business";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(51)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            FireRate = 0.53125m;
        }
    }

    /// <summary>
    /// 90	3-22	121	8-49	180	18-90
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class FrontierJustice : AShotgun
    {
        public FrontierJustice()
        {
            Name = "frontier justice";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
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
    /// 90	3-16	121	8-65	180	18-126
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class Widowmaker : AShotgun
    {
        public Widowmaker()
        {
            Name = "widowmaker";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            AlternateModes = new List<Weapon>()
            {
                new WidowmakerSentryTarget()
            };
        }
    }
    public class WidowmakerSentryTarget : AShotgun
    {
        public WidowmakerSentryTarget()
            :base(66)
        {
            Name = "sentry target";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(66)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
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