using System.Collections.Generic;

namespace StatsData
{
  

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
                    LongRangeRamp = UseSimpleOverrides?Damage.NORMAL_LONG_RANGE_RAMP:
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
            :base(20)
        {
            Name = "Righteous Bison";
            //TODO damage rate... damage is actually half base and always hits twice.

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

            //TODO Alternate: single-hit damage, list double-hit as if it were the main value? Anyhow, one of these is "alternate"
        }
    }


    public abstract class Bolts : Weapon
    {
        public Bolts()
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
    public class Huntsman : Bolts
    {
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

            };
            FireRate = 1.94m;
            AlternateModes = new List<Weapon>
            {
                new HuntsmanLit(),
                new HuntsmanCharged()
            };
        }
    }

    public class HuntsmanCharged : Bolts
    {
        public HuntsmanCharged()
        {
            Name = "Huntsman charged";

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
        }
    }

    public class HuntsmanLit : Bolts
    {
        public HuntsmanLit()
        {
            Name = "huntsman(lit)";

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

            Effect = new AfterburnEffect(10);// TODO time?
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
    public class RescueRanger : Bolts
    {
        //TODO wiki mini-crit max of 72 is nonsense
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
        public AStickybombLauncher(decimal baseDamage = 120, decimal armTime = 0.7m, decimal splashRadius = AOE.DEFAULT_SPLASH * 1)
        {
            Name = "Stickybomb Launcher";
            //TODO ActivationTime = ...0.05? time to explode after right-click.
            Projectile = new Projectile(925.38m) //wd; other sheet had 900
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = Damage.NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP,
                    LongRangeRamp = UseSimpleOverrides? Damage.NORMAL_LONG_RANGE_RAMP: 0.5m,
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

            //TODO alternatemodes charged, flak, trap
        }
    }

    public class ScottishResistance : AStickybombLauncher
    {
        public ScottishResistance()
            :base(120, 1.5m)
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

            //TODO alternatemodes charged, flak, trap
        }
    }

    public class QuickiebombLauncher : AStickybombLauncher
    {
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

            //TODO alternatemodes charged, flak, trap
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
        }
    }

    public class Overdose : ASyringeGun
    {
        public Overdose()
            :base(8.5m) // -15% damage
        {
            Name = "overdose";
            //TODO wiki claims 9 base against players... find out why, that makes 0 sense.
            //FIXME (fixed wth 8.5 vs. 9?) no stat or wiki text says it should have different ramps, it just has them in stats box.
            // base damage matches but different vs. buildings?? and then everything else is off by 1??
            // max ramp 111% in wiki

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
        }
    }

    
}