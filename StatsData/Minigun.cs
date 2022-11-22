using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class AMinigun : Weapon
    {
        public AMinigun(decimal baseDamage = 36, decimal spread = Damage.SPREAD_MINIGUN)
        {
            Name = "minigun";
            ActivationTime = 0.87m;// sec spin up;
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_MINIGUN,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.527777777777778m,
                },
                Fragmentation = new Fragmentation(spread)
                {
                    Fragments = 4,
                    FragmentType = "bullet",
                },

            };
            FireRate = 0.105m;// May 6 2021 wiki all changed from .1 to .105.
                              // pocket pistol mentions "rounded up to the next multiple of 0.015 seconds (a game tick)"

            //AlternateModes = new List<Weapon>()
            //{
            //    new MinigunCold() //TODO the same for other miniguns
            //};
        }
    }

    public class Minigun : AMinigun
    {
        public Minigun()
        {
            Name = "minigun";
            //ActivationTime = 0.87;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(36)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.527777777777778,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },

            //};
            //FireRate = 0.1;

            AlternateModes = new List<Weapon>()
            {
                new MinigunCold()
            };
        }
    }

    public class MinigunCold : AMinigun
    {
        public MinigunCold()
            :base(18)
        {
            Name = "(cold)";
            ////ActivationTime = 0.87;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(18)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.527777777777778,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },
            //};
            ////FireRate = 0.1;
        }
    }

    public class Natascha : AMinigun
    {
        //TODO calc'd close max of 41. Wiki says 40.
        public Natascha()
        : base(27)
        {
            Name = "natascha";
            ActivationTime = 1.16m;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(27)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },

            //};
            //FireRate = 0.1;
            AlternateModes = new List<Weapon>()
            {
               new NataschaCold()
            };
        }
    }

    public class NataschaCold : AMinigun
    {
        public NataschaCold()
            : base(27/2.0m)
        {
            Name = "(cold)";
            ActivationTime = 1.16m;// sec spin up;
        }
    }

    public class BrassBeast : AMinigun
    {
        public BrassBeast()
            :base(43.2m)
        {
            Name = "brass beast";
            ActivationTime = 1.31m;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(43.2)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },

            //};
            //FireRate = 0.1;
            AlternateModes = new List<Weapon>()
            {
                new BrassBeastCold()
            };
        }
    }

    public class BrassBeastCold : AMinigun
    {
        public BrassBeastCold()
            : base(43.2m / 2.0m)
        {
            Name = "(cold)";
            ActivationTime = 1.31m;// sec spin up;
        }
    }

    public class Tomislav : AMinigun
    {
        public Tomislav()
            :base(36, 0.064m)
        {
            Name = "tomislav";
            ActivationTime = 0.696m;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(36)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Fragmentation = new Fragmentation(0.064)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },

            //};
            FireRate = 0.12m; // "sometimes .135 due to server tick innacuracy"

            AlternateModes = new List<Weapon>()
            {
               new TomislavCold()
            };

        }
    }

    public class TomislavCold : AMinigun
    {
        public TomislavCold()
            : base(36 / 2.0m, 0.064m)
        {
            Name = "(cold)";
            ActivationTime = 0.696m;// sec spin up;
            FireRate = 0.12m; // "sometimes .135 due to server tick innacuracy"
        }
    }


    public class HuoLongHeater : AMinigun
    {
        public HuoLongHeater()
            :base(32.4m)
        {
            Name = "huo - long heater";
            ////ActivationTime = 0.87;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(32.4)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },
            //};
            ////FireRate = 0.1;

            AreaOfEffect = new AOE(AOE.DEFAULT_SPLASH * 1);//TODO value??
            //TODO NO this belongs on an alt mode of "Fire Ring"...direct damage + afterburn like a flamethrower
            Effect = new Effect()
            {
                Name = $"Direct Burn & Afterburn(8s)",
                Minimum = 8m,
                Maximum = 8m,

                Damage = new Damage(12), // direct fire ring damage (4 @0.5 for afterburn)
                //TODO what does this even mean? how can it do non-active direct burn damage of 12? shouldn't it always be "15?"  probably just "instant 3x afterburn application"... or maybe it's some kind of flamethrower calculation

            }; // & ammo cost

            AlternateModes = new List<Weapon>()
            {
                new HuoLongHeaterCold(),
                new HuoLongHeaterBurningTarget()
                //TODO and coldburning
            };
        }
    }
    public class HuoLongHeaterCold : AMinigun
    {
        public HuoLongHeaterCold()
            : base(32.4m / 2.0m)
        {
            Name = "(cold)";


            AreaOfEffect = new AOE(AOE.DEFAULT_SPLASH * 1);//TODO value??
            Effect = new Effect()
            {
                Name = $"Direct Burn & Afterburn(8s)",
                Minimum = 8m,
                Maximum = 8m,

                Damage = new Damage(12), // direct fire ring damage (4 @0.5 for afterburn)

            }; // & ammo cost

        }
    }


    public class HuoLongHeaterBurningTarget : AMinigun
    {
        //TODO calc'd close max of 49. Wiki says 48.
        //TODO wiki on burning target crit & minicrit are just wrong, probably had a cold weapon.
        // +25% (includes afterburn while active)
        public HuoLongHeaterBurningTarget()
            :base(40.5m)
        {
            Name = "(burning target)";
            ////ActivationTime = 0.87;// sec spin up;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(40.5)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MINIGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Fragmentation = new Fragmentation(0.08)
            //    {
            //        Fragments = 4,
            //        FragmentType = "bullet",
            //    },
            //};
            ////FireRate = 0.1;

            AreaOfEffect = new AOE(AOE.DEFAULT_SPLASH * 1);//TODO value??
            Effect = new Effect()
            {
                Name = $"Direct Continuous Burn & Active with Afterburn(8s +25%)",
                Minimum = 8m,
                Maximum = 8m,

                Damage = new Damage(12*1.25m), // direct fire ring damage (4 @0.5 for afterburn)

            }; // & ammo cost
        }
    }

}