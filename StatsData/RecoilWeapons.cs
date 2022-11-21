using StatsData;
using System.Collections.Generic;

namespace StatsData
{
    // different stats depending on who wields it.
    abstract public class APistol : Weapon
    {
        public APistol(decimal baseDamage = 15)
        {
            Name = "Pistol";
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_PISTOL, //Offset = 22, I had 22... probably to try and account for "wiki/obs point blank 22, calc 23; (winger comes out correct)"
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP
                },
                Recoil = new Recoil(Damage.SPREAD_PISTOL)
            };
            FireRate = 0.15m;
        }
    }

    public class EngineerPistol : APistol
    {
        public EngineerPistol()
        {
            Name = "Pistol";

            // Ammo is the difference
        }
    }

    /// <summary>
    /// 22	8	30	20	45	45
    /// wiki: 20-22	8-9	30	20	45
    /// </summary>
    public class ScoutPistol : APistol
    {
        // TODO wiki/obs point blank 22, calc 23; (winger comes out correct)
        // TODO wiki spread 48:1, calc rounding issue 47.4999repeating
        public ScoutPistol(decimal baseDamage = 15)
            :base(baseDamage)
        {
            Name = "Pistol";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(baseDamage)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_PISTOL,
            //        ZeroRangeRamp = UseSimpleOverrides ? Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP : 1.46666666666667,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Recoil = new Recoil(0.04)
            //    {
            //        Recovery = 1.25,
            //    },

            //};
            //FireRate = 0.15;
        }
    }

    /// <summary>
    /// 26	9	35	23	52	52
    /// wiki: 23-26	9-11	35	23	52
    /// </summary>
    public class Winger : ScoutPistol
    {
        public Winger()
            :base(17.25m)
        {
            Name = "winger";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(17.25)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_PISTOL,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Recoil = new Recoil(0.04)
            //    {
            //        Recovery = 1.25,
            //    },
            //};
            //FireRate = 0.15;
        }
    }

    /// <summary>
    /// 22	8	30	20	45	45
    /// wiki: 20-22	8-9	30	20	45
    /// </summary>
    public class PrettyBoysPocketPistol : ScoutPistol
    {
        public PrettyBoysPocketPistol()
        {
            Name = "pretty boy's pocket pistol";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(15)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_PISTOL,
            //        ZeroRangeRamp = UseSimpleOverrides ? Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP : 1.46666666666667,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Recoil = new Recoil(0.04)
            //    {
            //        Recovery = 1.25,
            //    },
            //};
            FireRate = 0.135m;// 0.1275m;// "The base value is 0.1275 seconds, but in practice it's rounded up to the next multiple of 0.015 seconds (a game tick)."
        }
    }

    public abstract class ASMG : Weapon
    {
        public ASMG()
        {
            Name = "smg";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(8)
                {
                    Offset = Damage.OFFSET_HITSCAN_SMG,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides? Damage.NORMAL_LONG_RANGE_RAMP: 0.5m,
                },
                Recoil = new Recoil(Damage.SPREAD_SMG_REVOLVER)
                {
                    Recovery = 1.25m,
                },

            };
            FireRate = 0.105m;//used to be 0.1m;, but game tick (like minigun) says that's not quite right.
        }
    }

    public class SMG : ASMG
    {
        public SMG()
        {
            Name = "smg";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(8)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SMG,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides? Damage.NORMAL_LONG_RANGE_RAMP: 0.5,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 1.25,
            //    },

            //};
            //FireRate = 0.1;
        }
    }

    public class CleanersCarbine : ASMG
    {
        public CleanersCarbine()
        {
            Name = "cleaner's carbine";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(8)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SMG,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 1.25,
            //    },

            //};
            FireRate = 0.135m;//wiki.  I previously had 0.13m;
        }
    }

    public abstract class ARevolver : Weapon
    {
        public ARevolver(decimal baseDamage = 40, decimal recovery = 1.25m)
        {
            Name = "revolver";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_REVOLVER,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.525m,
                },
                Recoil = new Recoil(Damage.SPREAD_SMG_REVOLVER)
                {
                    Recovery = recovery,
                },

            };
            FireRate = 0.5m; // wiki .. I used to have 0.51m (maybe that was an old wiki value)
        }
    }

    public class Revolver : ARevolver
    {
        public Revolver()
        {
            Name = "revolver";
        }
    }

    public class Ambassador : ARevolver
    {
        public Ambassador()
            : base(34,
             1.0m//TODO other spreadsheet AND WIKI have 1, where did I get 0.9 from?,
                 )
        {
            Name = "ambassador";

            //TODO Crits (and minicrits??) are affected by distance falloff.
            // Wiki says as low as 54 damage crit, but doesn't show reduction in mini-crit numbers.
            // yet " the critical hits and mini-crit damage are affected by distance falloff"

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(34)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_REVOLVER,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 0.9,//other spreadsheet had 1,
            //    },

            //};
            FireRate = 0.6m;

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }

    public class LEtranger : ARevolver
    {
        public LEtranger()
            :base(32)
        {
            Name = "l'etranger";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(32)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_REVOLVER,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 1.25,
            //    },

            //};
            //FireRate = 0.51;
        }
    }

    public class Enforcer : ARevolver
    {
        public Enforcer()
            :base(40, 
                 0.9m)//other spreadsheet had default 1.25,
        {
            Name = "enforcer";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(40)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_REVOLVER,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.525,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 0.9,//other spreadsheet had default 1.25,
            //    },

            //};
            FireRate = 0.6m;

            AlternateModes = new List<Weapon>
            {
                new EnforcerDisguised()
            };
        }
    }
    
    public class EnforcerDisguised : ARevolver
    {
        public EnforcerDisguised()
            : base(40 * 1.20m,
                 0.9m)//other spreadsheet had default 1.25,
        {
            Name = "enforcer (disguised)";

            FireRate = 0.6m;
        }
    }


    public class Diamondback : ARevolver
    {
        public Diamondback()
            :base(34)
        {
            Name = "diamondback";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(34)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_REVOLVER,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
            //    },
            //    Recoil = new Recoil(0.025)
            //    {
            //        Recovery = 1.25,
            //    },

            //};
            //FireRate = 0.51;
        }
    }


}