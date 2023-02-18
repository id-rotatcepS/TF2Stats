using StatsData;
using System.Collections.Generic;

namespace StatsData
{
    // different stats depending on who wields it.
    abstract public class APistol : Weapon
    {
        public APistol(decimal baseDamage = 15) // tf_weapon_pistol Damage=15
        {
            Name = "Pistol";
            Notes += "TODO wiki spread 48:1, my calc 50:1\n";
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
        /*
BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle	Name
1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0	TF_WEAPON_PISTOL
         */
        public EngineerPistol()
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Wielded by the Engineer:"),
            new PositiveAttribute("+455% max secondary ammo"),

            });
          
            Name = "Pistol"; Level = 1; WeaponType = "Pistol";//Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n15 damage (100 dps) 147%-53% by range\nRecoil accurate to 61% range\nReloads 12 in 1.2 sec (clip), 36 carried"),});
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
        /*
BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle	Name
1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0	TF_WEAPON_PISTOL_SCOUT
         */
        // TODO (Addressed with offsets) wiki/obs point blank 22, calc 23; (winger comes out correct)
        public ScoutPistol(decimal baseDamage = 15)
            :base(baseDamage)
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Wielded by the Scout:"),
            new PositiveAttribute("-8% faster clip reload"),

            }); 
            Name = "Pistol"; Level = 1; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n15 damage (100 dps) 147%-53% by range\nRecoil accurate to 61% range\nReloads 12 in 1.2 sec (clip), 36 carried"),
});
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

            Ammo.Reload = 1.005m; // recently proved value - variants use 1.10m in wiki because they weren't updated to match.
        }
    }

    /// <summary>
    /// 26	9	35	23	52	52
    /// wiki: 23-26	9-11	35	23	52
    /// TODO WIKI update: 1.10 reload was before Perci got better time of 1.0005
    /// </summary>
    public class Winger : ScoutPistol
    {
        /*
BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle	Name
1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0	The Winger
         */
        public Winger()
            :base(17.25m)
        {
            Name = "Winger"; Level = 15; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+15% damage bonus"),
new PositiveAttribute("+25% greater jump height when active"),
new NegativeAttribute("-60% clip size"),
});
            Notes += "Wiki 1.10 reload was based on scout pistol that since was proven as 1.005\n";

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
        /*
BulletsPerShot	Damage	Spread	DamageRadius	WeaponType	TimeReload	TimeReloadStart	AmmoPerShot	ClipSize	DefaultClip	ProjectileType	Range	TimeFireDelay	TimeIdle	TimeIdleEmpty	PunchAngle	Name
1	15	0.04	0	secondary	0.5	0	0	12	12	projectile_bullet	4096	0.15	5	0.25	0	Pretty Boy's Pocket Pistol
         */
        public PrettyBoysPocketPistol()
        {
            Name = "Pretty Boy's Pocket Pistol"; Level = 10; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("+15% faster firing speed"),
new PositiveAttribute("On Hit: Gain up to +3 health"),
new NegativeAttribute("-25% clip size"),
});
            Notes += "Wiki 1.10 reload was based on scout pistol that since was proven as 1.005\n";

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
            Notes += "TODO Wiki spread 76:1 my calc 80:1\n";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(8) // tf_weapon_smg Damage=8
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
            Name = "SMG"; Level = 1; WeaponType = "SMG"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n8 damage (80 dps) 150%-50% by range\nRecoil accurate to 98% range\nReloads 25 in 1.1 sec (clip), 75 carried"),
});
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
            Name = "Cleaner's Carbine"; Level = 1; WeaponType = "SMG"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Dealing damage fills charge meter."),
new PositiveAttribute("Secondary fire when charged grants mini-crits for 8 seconds."),
new NegativeAttribute("-20% clip size"),
new NegativeAttribute("-25% slower firing speed"),
new NegativeAttribute("No random critical hits"),
});
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
        public ARevolver(decimal baseDamage = 40, decimal recovery = 1.25m) // tf_weapon_revolver Damage=40
        {
            Name = "revolver";
            Notes += "TODO Wiki spread 76:1 my calc 80:1\n";

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
            Name = "Revolver"; Level = 1; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n40 damage (78 dps) 150%-53% by range\nRecoil accurate to 98% range\nReloads 6 in 1.2 sec (clip), 24 carried"),
});
        }
    }

    public class Ambassador : ARevolver
    {
        public Ambassador()
            : base(34,
             1.0m//TODO other spreadsheet AND WIKI have 1, another page has 0.9, discussion page mentions this too.  August 2020 wiki updates changed this from 0.95 to 1 and Enforcer from .95 to 1.25
                 )
        {
            Name = "Ambassador"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Crits on headshot"),
new NegativeAttribute("-15% damage penalty"),
new NegativeAttribute("20% slower firing speed"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Critical damage is affected by range"),
}); 
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
            Name = "headshot";

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
            Name = "L'Etranger"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+40% cloak duration"),
new PositiveAttribute("+15 cloak on hit"),
new NegativeAttribute("-20% damage penalty"),
});
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
            :base(40)//had 0.9 (or 0.95) recovery in the past, but wiki was restored to same as others in August 2020 ... there was a May 2022 discussion post asking about it because OTHER pages still say smaller number.
        {
            Name = "Enforcer"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+20% damage bonus while disguised"),
new PositiveAttribute("Attacks pierce damage resistance effects and bonuses"),
new NegativeAttribute("20% slower firing speed"),
new NegativeAttribute("No random critical hits"),
}); 
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
            : base(40 * 1.20m)
        {
            Name = "disguised";

            FireRate = 0.6m;
        }
    }


    public class Diamondback : ARevolver
    {
        public Diamondback()
            :base(34)
        {
            Name = "Diamondback"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Gives one guaranteed critical hit for each building destroyed with your sapper attached or backstab kill"),
new NegativeAttribute("-15% damage penalty"),
new NegativeAttribute("No random critical hits"),
});
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