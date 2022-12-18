using System.Collections.Generic;

namespace StatsData
{

    // reviewing vs. wiki pages, most look good starting from shield bash working up the list.  issues marked as TODO in code items.
    // summary:
    // TODO shotgun long range all pellets is missing weapon tests (with a giant) and tends to not match wiki
    // TODO need evidence observations: stickybombs & flamethrowers - numbers are a pretty good match now.
    // TODO overdose (other needs?) observations: small "vs. building" difference in wiki.
    // TODO huo-long heater direct burn damage a real thing, or does it just invoke simple afterburn? increased damage on already-burning enemy? assuming increased afterburn damage while active is true but test it inactive.
    // TODO short circuit orb building modifier test - wiki talks about it but no number. not sure where I got it. 
    // TODO Crossbow heal: -75: is this just theoretical or can we heal this small an amount?

    //TODO Degreaser wiki numbers all look like old flamethrower stats or something

    //TODO wiki vs. calc'd close max on a huolong & natascha miniguns doesn't match up exactly (what is obs?) scout pistol, too (obs matches wiki)

    // TODO RescueRanger wiki mini-crit max of 72 is nonsense (obs and calc agree to 81)
    // TODO crossbow: Wiki has nonsense crit & minicrit values of 113 & 51 on the low end when I've observed 115 & 52 (matches calc)
    // TODO shortcircuit: wiki went with base + falloff which doesn't really make any sense and they also didn't show mini-crit range
    // TODO rocket launchers point blank required a custom ramp up
    // TODO WIKI IS WRONG about shotguns spread... their own evidence proves them wrong (see comments on constant)
    //TODO (shotgun/scattergun) wiki spread 30:1, but calc is 28:1 (28.148repeating).
    //  calc is 30 if I use 2.0 instead of 1.9 for spread divisor. (but back-scatter is slightly too HIGH calc, then. and Minigun calcs 25 instead of 24 (and tomislav calcs 31 not 30))

    //TODO (shotgun/scattergun) wiki all pellets far 30, but calc is 32, need evidence.  30 implies 50% fall-off

    //TODO self-damage management
    //TODO knock-back management
    //TODO Ubers
    //TODO crit-calculator strategy object to deal with special cases without hacks.
    //TODO ammo-cost & different ammo cost rate from fire rate (e.g. airblasts)

    //TODO Building Maintenance as its own Melee-like add-on, not an effect.  Could include Sapper damage (apply to two pyro weapons with 0 maintenance)

    //TODO All Ammo/Reload info objects still outstanding.  Maybe ammo type for metal weapons

    public abstract class IndivisibleParticleSmasher : Weapon
    {
        public IndivisibleParticleSmasher(decimal baseDamage = 60)
        {
            Name = "indivisible particle smasher";

            Projectile = new Projectile(1200)//wd
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
                    ZeroRangeRamp = Damage.NORMAL_ENERGY_PROJECTILE_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP :
                    0.533333333333333m,

                    BuildingModifier = 0.20m//-80%
                },
                Propelled = true,

                Influenceable = false
            };
            FireRate = 0.8m;

            Ammo = new Ammo(4, Ammo.INFINITE_AMMO)
            {
                ReloadFirst = 1.02m,
                ReloadAdditional = 0.53m,
            };
        }
    }

    /// <summary>
    /// myobs: 72	32	97	81	180	180
    /// wiki: pb: 68-72; long: 32-34; pb mc: 81; long mc: 57; pb crit: 180
    /// </summary>
    public class Pomson6000 : IndivisibleParticleSmasher
    {
        public Pomson6000()
        {
            Name = "Pomson 6000"; Level = 10; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Does not require ammo"),
new PositiveAttribute("Projectile cannot be deflected"),
new PositiveAttribute("On Hit: Victim loses up to 10% Medigun charge"),
new PositiveAttribute("On Hit: Victim loses up to 20% cloak"),
new NegativeAttribute("Deals only 20% damage to buildings"),
new DescriptionAttribute("Being an innovative hand-held irradiating utensil capable of producing rapid pulses of high-amplitude radiation in sufficient quantity as to immolate, maim and otherwise incapacitate the Irish."),
}); 
            //Projectile = new Projectile(1200)
            //{
            //    HitDamage = new Damage(60)
            //    {
            //        ZeroRangeRamp = Damage.NORMAL_ENERGY_PROJECTILE_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //Influenceable = false
            //};
            //FireRate = 0.8;

            // not penetrating.

            Effect = new Effect()
            {
                Name = "Drain Über & Cloak"
            };
        }
    }

    /// <summary>
    /// myobs: 24	11	32	27	60	60
    /// wiki: pb: 22-24 (per tick); long: 11-12 (per tick); pb mc: 32 (per tick); long mc: 27; pb crit: 60 (per tick)
    /// </summary>
    public class RighteousBison : IndivisibleParticleSmasher
    {
        public RighteousBison()
            : base(20)
        {
            Name = "Righteous Bison"; Level = 30; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Does not require ammo"),
new PositiveAttribute("Projectile penetrates enemy targets"),
new PositiveAttribute("Projectile cannot be deflected"),
new NegativeAttribute("Deals only 20% damage to buildings"),
}); 
            //TODO damage rate... damage always hits twice within one frame (could hit more times in theory).

            //Projectile = new Projectile(1200)//wd
            //{
            //    HitDamage = new Damage(20)
            //    {
            //        Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
            //        ZeroRangeRamp = Damage.NORMAL_ENERGY_PROJECTILE_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP :
            //                        0.55,

            //        BuildingModifier = 0.20//-80%
            //    },
            //    Penetrating = true,
            //    Propelled = true,
            //    Influenceable = false,
            //};
            Projectile.Penetrating = true;
            ////FireRate = 0.8;

            // Alternate: double-hit damage, list single-hit as the main value. Anyhow, one of these is "alternate"
            //AlternateModes = new List<Weapon>
            //{
            //    new RighteousBisonTypical()
            //};

            Ammo.ReloadFirst = 0.92m;
            Ammo.ReloadAdditional = 0.4m;
        }
    }

    //public class RighteousBisonTypical : IndivisibleParticleSmasher
    //{
    //    //Alternate: typical double-hit damage
    //    // TODO this doesn't actually work because it's final number (range, crits applied, rounded) *2, not just base damage*2
    //    public RighteousBisonTypical()
    //        : base(20*2)
    //    {
    //        Name = "Righteous Bison (per second)";
    //        Projectile.Penetrating = true;
    //        ////FireRate = 0.8;
    //    }
    //}


    public abstract class ABolt : Weapon
    {
        public ABolt()
        {
            Name = "bolts";

            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(50)
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
            };
            FireRate = 1.94m;
        }
    }

    /// <summary>
    /// myobs: 51	51	69	69	153	153
    /// wiki: 50	50	68	68	150 (charged all agree)
    /// </summary>
    public class Huntsman : ABolt
    {
        //TODO Aim Fatigue: 5s
        public Huntsman()
        {
            Name = "Huntsman"; Level = 10; WeaponType = "Bow"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
});
            Projectile = new Projectile(1875)//wd; had 1812 from other spreadsheet
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                //TODO ArmTime= - minimum charge time to fire.  Impossible to get exactly 50 damage, possible to not fire.
            };
            //TODO ...or is ActivationTime the right place for minimum charge time? that's how sniper rifle pre-charge delay is recorded now
            FireRate = 0m; // single shot reload is functionally its rate
            AlternateModes = new List<Weapon>
            {
                new HuntsmanCharged(),
                new HuntsmanLit(),
            };

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };

            Ammo = new Ammo(1, 12)
            {
                Reload = 1.94m,
            };

        }
    }

    public class HuntsmanCharged : ABolt
    {

        public HuntsmanCharged()
        {
            Name = "charged";

            Projectile = new Projectile(2400)//wd
            {
                HitDamage = new Damage(120)
                {
                    Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            ChargeTime = 1.0m;
            FireRate = ChargeTime; // pre-charge delay (0) + charge time

            //// Aim Fatigue / Accurate Time
            //ActivationTime = 5.0m;
            Effect = new Effect()
            {
                Name = "No Aim Fatigue",
                Minimum = 5.0m,
                Maximum = 5.0m
            };

            Effects.Add(new Effect()
            {
                Name = "Crit on Headshot"
            });

            Ammo = new Ammo(1, 12)
            {
                Reload = 1.94m,
            };

        }
    }

    public class HuntsmanLit : ABolt
    {
        public HuntsmanLit()
        {
            Name = "lit";

            Projectile = new Projectile(1875)//wd; had 1812 from other spreadsheet
            {
                HitDamage = new Damage(50) // or does it do extra? not likely.
                {
                    Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 0m; // single shot reload is functionally its rate

            Effect = new AfterburnEffect(10);// TODO time? Wiki doesn't say
            Effects.Add(new Effect()
            {
                Name = "Crit on Headshot"
            });

            Ammo = new Ammo(1, 12)
            {
                Reload = 1.94m,
            };
        }
    }

    //public class HuntsmanHeadshot : Bolts
    //{
    //    public HuntsmanHeadshot()
    //    {
    //        Name = " huntsman(headshots)";

    //        Projectile = new Projectile(1812)
    //        {
    //            HitDamage = new Damage(150)
    //            {
    //                ZeroRangeRamp = 1,
    //                LongRangeRamp = 1,
    //            },

    //        };
    //        FireRate = 0m; // single shot reload is functionally its rate
    //Ammo = new Ammo(1, 12)
    //{
    //    Reload = 1.94m,
    //        };
    //    }
    //}

    /// <summary>
    /// myobs: 60	21	81	54	120	120
    /// wiki: 57-60	21-23	81	54	120
    /// </summary>
    public class RescueRanger : ABolt
    {
        //TODO RescueRanger wiki mini-crit max of 72 is nonsense (obs and calc agree to 81)
        public RescueRanger()
        {
            Name = "Rescue Ranger"; Level = 1 - 100; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Alt-Fire: Use 100 metal to pick up your targeted building from long range"),
new PositiveAttribute("Fires a special bolt that can repair friendly buildings"),
new NegativeAttribute("-34% clip size"),
new NegativeAttribute("-50% max primary ammo on wearer"),
new NegativeAttribute("Self mark for death when hauling buildings"),
new NegativeAttribute("4-to-1 health-to-metal ratio when repairing buildings"),
}); 
            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(40)
                {
                    //Offset = ,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP, // like shotgun
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
                },

            };
            FireRate = 0.625m;

            Ammo = new Ammo(4, 16)
            {
                ReloadFirst = 1.0m,
                ReloadAdditional = 0.5m,
            };
        }
    }


    public class Wrangler : Weapon
    {
        public Wrangler()
        {
            Name = "Wrangler"; Level = 5; WeaponType = "Laser Pointer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Take manual control of your Sentry Gun.<br>Wrangled sentries gain a shield that reduces damage and repairs by 66%.<br>Sentries are disabled for 3 seconds after becoming unwrangled."),
}); 

            //{
            //    Offset = 23.5,
            //    }
            FireRate = -1;
        }
    }

    public abstract class AStickybombLauncher : Weapon
    {
        //NOTE this is practical, but not really right... stickybombs do no damage on hit, it's triggering them that does the damage.
        //Maybe projectile facts with no damage, then alt mode of triggered (which has its own explode activation time beyond arm time)
        public AStickybombLauncher(decimal baseDamage = 120, decimal armTime = 0.7m, decimal splashRadius = AOE.DEFAULT_SPLASH * 1,
            decimal speed = 925.38m //wd; other sheet had 900; wiki text says 805
            )
        {
            Name = "Stickybomb Launcher";
            ActivationTime = 0.135m;//time to explode after right-click
            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5m,
                },
                ArmTime = armTime, // sec bomb arm time;
                Splash = new AOE(splashRadius)
            };
            FireRate = 0.6m;

            Ammo = new Ammo(8, 24)
            {
                ReloadFirst = 1.09m,
                ReloadAdditional = 0.67m,
            };
        }
    }

    public class StickybombLauncher : AStickybombLauncher
    {
        public StickybombLauncher()
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Multi-use: Spam/Flak, Trap, or Sticky Jump"),
            new NegativeAttribute("Self inflicted blast damage"),
            new NeutralAttribute("No impact damage"),
            new NeutralAttribute("Explosive: 50%-100% damage in explosion radius"),
            new NeutralAttribute("Blast knocks away enemy stickybombs"),
            new NeutralAttribute("Alt-Fire: Detonate all stickybombs"),
            new DescriptionAttribute("8 max stickybombs out<br/>Hold primary fire to charge projectile speed<br/>Max charge in 4.0 seconds for +160% accuracy<br/><br/>Spam: 0.7 second minimum arm time to detonate<br/>Flak: -15% fading explosion radius penalty in air<br/>Trap: Bombs armed 5 seconds deal 100% damage at any range<br/>Sticky Jump: High mobility from high self-damage"),
            });
            
            Name = "Stickybomb Launcher"; Level = 1; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n120 explosive damage (200 dps) 120%-50% by range\n Arced projectile accurate to 14%, explosion to 100% range\nReloads 8 in 5.8 sec (first in 1.1 sec), 24 carried"),
new DescriptionAttribute("Alt-Fire: Detonate all Stickybombs"),
});
//            Name = "Sticky Jumper"; Level = 1; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+200% max secondary ammo on wearer"),
//new PositiveAttribute("No self inflicted blast damage taken"),
//new NegativeAttribute("-100% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("-6 max stickybombs out"),
//new NegativeAttribute("Wearer cannot carry the intelligence briefcase or PASS Time JACK"),
//new DescriptionAttribute("A special no-damage stickybomb launcher for learning stickybomb jump tricks and patterns."),
//}); 
            AlternateModes = new List<Weapon>
            {
                new ChargedStickybomb(Projectile.ArmTime, 4.0m),// maximum charge time
                new FlakStickybomb(Projectile.ArmTime, FireRate),
                new TrapStickybomb(Projectile.ArmTime, FireRate),
            };
        }
    }

    internal class TrapStickybomb : AStickybombLauncher
    {
        public TrapStickybomb(decimal armTime, 
            decimal fireRate)
        {
            Name = "Trap";

            decimal baseDamage = 120;
            //decimal armTime = 0.7m; 
            decimal splashRadius = AOE.DEFAULT_SPLASH * 1;
            decimal speed = 925.38m;

            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                },
                ArmTime = 5.0m,//+ armTime, // bomb arm time + trap activation time;
                Splash = new AOE(splashRadius)
            };
            FireRate = fireRate;
        }
    }

    internal class FlakStickybomb : AStickybombLauncher
    {
        //December 22, 2014 Patch (Smissmas 2014)
        //Stickybombs that detonate in the air now have a radius ramp up, starting at 85% at base arm time(0.8s) going back to 100% over 2 seconds.Stickybombs that touch the world will have full radius.
        //January 7, 2015 Patch
        //Fixed the air detonation radius for stickybomb jumps.

        /// <summary>
        /// mid-air stickybomb at start of 2 second period after armed
        /// </summary>
        public FlakStickybomb(decimal armTime, decimal fireRate)
            : base(120m, armTime, AOE.DEFAULT_SPLASH * .85m)//TODO does "fixed" mean they cancelled this splash reduction?
        {
            Name = "Flak";
            FireRate = fireRate;
        }
    }

    internal class ChargedStickybomb : AStickybombLauncher
    {
        //wiki text speed "approximately 230%" of 805
        public ChargedStickybomb(decimal armTime, decimal fireRate)
            :base(120m,armTime, AOE.DEFAULT_SPLASH * 1,
                 925.38m
                 //805m 
                 * 2.3m)
        {
            Name = "(fully charged)";

            ChargeTime = fireRate;
            FireRate = fireRate;
        }
    }

    public class ScottishResistance : AStickybombLauncher
    {
        public ScottishResistance()
            : base(120,
                  1.72m) // 1.5 in text; 1.72 in function times
        {
            Name = "Scottish Resistance"; Level = 5; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% faster firing speed"),
new PositiveAttribute("+50% max secondary ammo on wearer"),
new PositiveAttribute("+6 max pipebombs out"),
new PositiveAttribute("Detonates stickybombs near the crosshair and directly under your feet"),
new PositiveAttribute("Able to destroy enemy stickybombs"),
new NegativeAttribute("0.8 sec slower bomb arm time"),
});
            //Projectile = new Projectile(925.38) //wd; other sheet had 900
            //{
            //    HitDamage = new Damage(120)
            //    {
            //        Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
            //        ZeroRangeRamp = Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5,
            //    },
            //    ArmTime = 1.5,// sec bomb arm time;
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            FireRate = 0.45m;

            Effect = new Effect()
            {
                Name = "Able to destroy enemy stickybombs"
            };

            Ammo.Carried = 36;//TODO update carried on alternate modes

            AlternateModes = new List<Weapon>
            {
                new ChargedStickybomb(Projectile.ArmTime, 4.0m),// maximum charge time
                new FlakStickybomb(Projectile.ArmTime, FireRate),
                new TrapStickybomb(Projectile.ArmTime, FireRate),
            };

        }
    }

    public class QuickiebombLauncher : AStickybombLauncher
    {
        //"-15% damage penalty"
        //"-0.2 sec faster bomb arm time"
        public QuickiebombLauncher()
            :base(102, 0.5m)
        {
            Name = "The Quickiebomb Launcher";
            Name = "Quickiebomb Launcher"; Level = 1 - 99; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Able to destroy enemy stickybombs"),
new PositiveAttribute("-0.2 sec faster bomb arm time"),
new PositiveAttribute("Max charge time decreased by 70%"),
new PositiveAttribute("Up to +35% damage based on charge"),
new NegativeAttribute("-15% damage penalty"),
new NegativeAttribute("-50% clip size"),
});
            Notes += "Wiki says radius 189 - but same date this weapon was added others reduced from 159 to 146\n";

            //Projectile = new Projectile(925.38) //wd; other sheet had 900
            //{
            //    HitDamage = new Damage(102)
            //    {
            //        Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
            //        ZeroRangeRamp = UseSimpleOverrides? Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP: 1.19607843137255,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5,
            //    },
            //    ArmTime = 0.5,// sec bomb arm time;
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            //FireRate = 0.6;

            Effect = new Effect()
            {
                Name = "Able to destroy enemy stickybombs"
            };

            Ammo.Loaded = 4;

            AlternateModes = new List<Weapon>
            {
                new ChargedQuickiebomb(Projectile.HitDamage.Base, Projectile.ArmTime, 1.2m),// maximum quickiebomb charge time
                new FlakQuickiebomb(Projectile.HitDamage.Base, Projectile.ArmTime, FireRate),
                new TrapQuickiebomb(Projectile.HitDamage.Base, Projectile.ArmTime, FireRate),
            };
        }
    }

    internal class TrapQuickiebomb : AStickybombLauncher
    {
        public TrapQuickiebomb(decimal baseDamage, decimal armTime,
            decimal fireRate)
        {
            Name = "Trap";

            decimal splashRadius = AOE.DEFAULT_SPLASH * 1;
            decimal speed = 925.38m;

            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                },
                ArmTime = 5.0m,//+ armTime, // bomb arm time + trap activation time;
                Splash = new AOE(splashRadius)
            };
            FireRate = fireRate;

            Ammo.Loaded = 4;
        }
    }

    internal class FlakQuickiebomb : AStickybombLauncher
    {
        //December 22, 2014 Patch (Smissmas 2014)
        //Stickybombs that detonate in the air now have a radius ramp up, starting at 85% at base arm time(0.8s) going back to 100% over 2 seconds.Stickybombs that touch the world will have full radius.
        //January 7, 2015 Patch
        //Fixed the air detonation radius for stickybomb jumps.

        /// <summary>
        /// mid-air stickybomb at start of 2 second period after armed
        /// </summary>
        public FlakQuickiebomb(decimal baseDamage, decimal armTime, decimal fireRate)
            : base(baseDamage, armTime, AOE.DEFAULT_SPLASH * .85m)//TODO does "fixed" mean they cancelled this splash reduction?
        {
            Name = "Flak";
            FireRate = fireRate;

            Ammo.Loaded = 4;
        }
    }

    internal class ChargedQuickiebomb : AStickybombLauncher
    {
        //"Max charge time decreased by 70%"
        //"up to +35% damage based on charge"
        public ChargedQuickiebomb(decimal baseDamage, decimal armTime, decimal fireRate)
            : base(baseDamage*1.35m, armTime, AOE.DEFAULT_SPLASH * 1,
                 925.38m
                 //805m 
                 * 2.3m)
        {
            Name = "(fully charged)";

            ChargeTime = fireRate;
            FireRate = fireRate;

            Ammo.Loaded = 4;
        }
    }

    public abstract class ASyringeGun : Weapon
    {
        public ASyringeGun(decimal baseDamage = 10)
        {
            Name = "syringe gun";

            Projectile = new Projectile(1000) //wd; other sheet said 990
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_5_SYRINGES,
                    ZeroRangeRamp = Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5m,
                },

                Influenceable = false
            };
            FireRate = 0.105m;//due to game ticks like minigun. used to be 0.1m;

            Ammo = new Ammo(40, 150)
            {
                Reload = 1.305m,
            };
        }
    }

    public class SyringeGun : ASyringeGun
    {
        public SyringeGun()
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Syringes are immune to projectile influencers"),

            });
            
            Name = "Syringe Gun"; Level = 1; WeaponType = "Syringe Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n10 damage (100 dps) 120%-50% by range\n Arced projectile accurate to 16% range\nReloads 40 in 1.6 sec (clip), 150 carried"),
});
        }
    }

    public class Blutsauger : ASyringeGun
    {
        public Blutsauger()
        {
            Name = "Blutsauger"; Level = 5; WeaponType = "Syringe Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Gain up to +3 health"),
new NegativeAttribute("-2 health drained per second on wearer"),
}); 
            //Projectile = new Projectile(1000) //wd; other sheet said 990
            //{
            //    HitDamage = new Damage(10)
            //    {
            //        Offset = Damage.OFFSET_5_SYRINGES,
            //        ZeroRangeRamp = Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP,
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.5,
            //    },

            //    Influenceable = false
            //};
            //FireRate = 0.1;

            Effect = new Effect()
            {
                Name = "Leach"
            };
            Effects.Add(new Effect()
            {
                Name = "Passive Self-damage"
            });
        }
    }

    public class Overdose : ASyringeGun
    {
        public Overdose()
            : base(8.5m) // -15% damage
        {
            Name = "Overdose"; Level = 5; WeaponType = "Syringe Gun Prototype"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NegativeAttribute("-15% damage penalty"),
new DescriptionAttribute("While active, movement speed increases based on ÜberCharge percentage to a maximum of +20%"),
});
            //TODO wiki claims 8 against buildings... find out why, that makes 0 sense.
            //NOTE no stat or wiki text says it should have different ramps, but it shows 111% in wiki stats box (probably because they were using 9 as base, not 8.5).  We use 120% like the rest of the syringe guns.

            //Projectile = new Projectile(1000) //wd; other sheet said 990
            //{
            //    HitDamage = new Damage(9)
            //    {
            //        Offset = Damage.OFFSET_5_SYRINGES,
            //        ZeroRangeRamp = UseSimpleOverrides? Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP: 1.11111111111111, // no stat or wiki text says it should have different ramps, it just has them in stats box.
            //        LongRangeRamp = UseSimpleOverrides ? Damage.NORMAL_LONG_RANGE_RAMP : 0.444444444444444,
            //    },

            //    Influenceable = false
            //};
            //FireRate = 0.1;

            Effect = new Effect()
            {
                Name = "Uber charge-based Self Speed buff"
            };
        }
    }

    
}