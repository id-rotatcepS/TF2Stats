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
            Name = "Pomson 6000";

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
            Name = "Righteous Bison";

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
            Name = "Huntsman";

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
            FireRate = 1.94m;
            AlternateModes = new List<Weapon>
            {
                new HuntsmanLit(),
                new HuntsmanCharged()
            };

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
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
            //added charge time
            FireRate = 2.94m;

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
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
            FireRate = 1.94m;

            Effect = new AfterburnEffect(10);// TODO time? Wiki doesn't say // TODO crit on headshot, too
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
    //        FireRate = 1.94;
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
            Name = "Rescue Ranger";

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
        }
    }


    public class Wrangler : Weapon
    {
        public Wrangler()
        {
            Name = "wrangler";


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
        }
    }

    public class StickybombLauncher : AStickybombLauncher
    {
        public StickybombLauncher()
        {
            Name = "Stickybomb Launcher";

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

            FireRate = fireRate;
        }
    }

    public class ScottishResistance : AStickybombLauncher
    {
        public ScottishResistance()
            : base(120,
                  1.72m) // 1.5 in text; 1.72 in function times
        {
            Name = "scottish resistance";
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

            FireRate = fireRate;
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
        }
    }

    public class SyringeGun : ASyringeGun
    {
        public SyringeGun()
        {
            Name = "syringe gun";
        }
    }

    public class Blutsauger : ASyringeGun
    {
        public Blutsauger()
        {
            Name = "blutsauger";

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
                Name = "Leach, Passive Self-damage"
            };
        }
    }

    public class Overdose : ASyringeGun
    {
        public Overdose()
            : base(8.5m) // -15% damage
        {
            Name = "overdose";
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