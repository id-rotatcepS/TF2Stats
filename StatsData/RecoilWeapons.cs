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
                    ZeroRangeRamp = Damage.PISTOL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP
                },
                Recoil = new Recoil(Damage.SPREAD_PISTOL)
            };
            FireRate = 0.15m;

            Ammo = new Ammo(12, 36) // scout carry as typical
            {
                Reload = 1.035m, // engineer reload as typical
            };
        }
    }

    public class EngineerPistol : APistol
    {
        public EngineerPistol()
        {
            Name = "Pistol";

            // Ammo is the difference
            Ammo.Carried = 200;
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

            Ammo.Reload = 1.005m; // variants use 1.10m in wiki, but with no explanation.  I am assuming this is the accurate one.
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

            Ammo.Loaded = 5;
            //Ammo.Reload = 1.10m;//TODO used slower reload number from wiki... but nothing says a difference from pistol in text
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

            Effect = new Effect()
            {
                Name = "Leach up to 3hp"//TODO "up to" by weapon text...but isn't it ALWAYS 3? min damage is 8.
            };

            Ammo.Loaded = 9;
            //Ammo.Reload = 1.10m;//TODO used slower reload number from wiki... but nothing says a difference from pistol in text
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

            Ammo = new Ammo(25, 75)
            {
                Reload = 1.1m,
            };
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

            Ammo.Loaded = 20;
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

            Ammo = new Ammo(6, 24)
            {
                Reload = 1.133m,
            };
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
             1.0m//TODO other spreadsheet AND WIKI have 1, another page has 0.9, discussion page mentions this too
                 )
        {
            Name = "ambassador";

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

            AlternateModes = new List<Weapon>()
            {
                //obs: crit-boosted Amby does normal crit damage, not ranged.  Guessing: only headshots do ranged?  In which case minicrit isn't relevant?
                new AmbassadorHeadshot()
            };
        }
    }

    public class AmbassadorHeadshot : ARevolver
    {
        //TODO need evidence, wiki is all over the place.
        //Wiki: max 102 (base 34 with crit), ramps down to 51(based on? maybe just transferred from close range ramp no crit?), and super-long-range (1200) does base (34?)
        // so maybe we need a range of crits plus: 34 close to 51/3=17 (somewhere) to 34/3 super long range;
        // But what about minicrits?
        public AmbassadorHeadshot()
            : base(34,
             1.0m//TODO see note on main
                 )
        {
            Name = "(headshot)";

            // Crits (and minicrits??) are affected by distance falloff.
            // Wiki says as low as 54 damage crit, but doesn't show reduction in mini-crit numbers.
            // yet " the critical hits and mini-crit damage are affected by distance falloff"
            Hitscan.Damage.ZeroRangeRamp = 1.0001m;//TODO hack to show up when it's 1.0// Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            Hitscan.Damage.LongRangeRamp = 0.33m;//UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.525m,
            Hitscan.Damage.CritIncludesRamp = true;//TODO .33 not gonna work for minicrit range.

            CanMinicrit = false;

            FireRate = 0.6m;

            Effect = new Effect()
            {
                Name = "Crit on Recovered Headshot"
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
            Name = "(disguised)";

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