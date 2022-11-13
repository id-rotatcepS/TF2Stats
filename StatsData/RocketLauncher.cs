using System.Collections.Generic;

namespace StatsData
{
    /// <summary>
    /// myobs: 112	48	151	122	270	270
    /// wiki: 105-112	24-48	151	122	135-270
    /// </summary>
    public abstract class ARocketLauncher : Weapon
    {
        //TODO point blank obs/wiki 112 (151mc), calcs as 113 (152mc)
        public ARocketLauncher(decimal baseDamage = 90, decimal speed = 1100, decimal splashRadius= AOE.DEFAULT_SPLASH)
        {
            Name = "Rocket Launcher";
            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_1_ROCKETS_FLARES,
                    ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,
                },
                Propelled = true,
                Splash = new AOE(splashRadius)
            };
            FireRate = 0.80m;

            //xRocketLauncher:
            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(90)
            //    {
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Splash = new AOE(AOE.DEFAULT_RADIUS * 1)
            //};
            //FireRate = 0.8;

        }
    }

    public class RocketLauncher : ARocketLauncher
    {
        public RocketLauncher()
        {
            Name = "Rocket Launcher";
        }
    }

    public class xRocketLauncher : Weapon
    {
        public xRocketLauncher()
        {
            Name = "rocket launcher";

            Projectile = new Projectile(1100)
            {
                HitDamage = new Damage(90)
                {
                    Offset = Damage.OFFSET_1_ROCKETS_FLARES,
                    ZeroRangeRamp = UseSimpleOverrides? Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP: 1.24444444444444m,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
                },
                Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            };
            FireRate = 0.8m;
        }
    }

    /// <summary>
    /// 140	59	189	152	338	338
    /// wiki: 133-140	30-59	189	152	169-338
    /// </summary>
    public class DirectHit : ARocketLauncher
    {
        // TODO (similar to base) point blank obs/wiki 140 (mc 189); calc is 141 (mc 190); (wiki base 112 should round to 113, so that's ok)
        public DirectHit()
            :base(112.5m,//112.5=(90*1.25), but weapon_damage I had 112. //112)
                 1980,
                 AOE.DEFAULT_SPLASH * 0.3m)
        {
            Name = "direct hit";

            //Projectile = new Projectile(1980)
            //{
            //    HitDamage = new Damage(112.5)//112.5=(90*1.25), but weapon_damage I had 112. //112)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.526785714285714,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.3)
            //};
            //FireRate = 0.8;
        }
    }

    /// <summary>
    /// 112	48	151	122	270	270
    /// wiki: 105-112	24-48	151	122	135-270
    /// </summary>
    public class BlackBox : ARocketLauncher
    {
        public BlackBox()
        {
            Name = "black box";

            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(90)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP, // 1.25 makes more sense and also works fine. Had 1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            //FireRate = 0.8;
        }
    }

    /// <summary>
    /// 84	36	114	91	203	203
    /// wiki: 79-84	18-36	114	91	101-203
    /// </summary>
    public class LibertyLauncher : ARocketLauncher
    {
        //"-25% damage penalty"
        //TODO wiki & obs have crit as 203, function times shows 202.
        public LibertyLauncher()
            :base(67.5m,//67.5=90*.75, had that in weapon_damage, wiki says:68, results work if ZeroRange is 1.25
            1540)
        {
            Name = "Liberty Launcher";

            //Projectile = new Projectile(1540)
            //{
            //    HitDamage = new Damage(67.5)//67.5=90*.75, had that in weapon_damage, wiki says:68, results work if ZeroRange is 1.25
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP,//1.25 helps make sense of results. Had 1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            //FireRate = 0.8;
        }
    }

    /// <summary>
    /// myobs: 112	48	151	122	122	122
    /// wiki: 105-112	24-48	151	122	135-270 (D/H)
    /// note on 151: correct, but special reduced crit-boosted value of 122 needs to be updated on wiki. They seem to be unaware
    /// note on 135-270: check the reflect-crit really can do crit damage.  Looks like it should NOT be true and wiki needs update because: "May 13, 2013 Patch    [Undocumented] Fixed reflected Cow Mangler shots becoming Critical hits."
    /// </summary>
    public class CowMangler5000 : ARocketLauncher
    {
        public CowMangler5000()
        {
            Name = "Cowmangler 5000";

            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(90)
            //    {
            //        Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP, // 1.25 makes more sense and also works fine. Had 1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            //FireRate = 0.8;

            //"Deals only 20% damage to buildings"
            Projectile.HitDamage.BuildingModifier = .20m;

            AlternateModes = new List<Weapon>()
            {
                new CowManglerAlt()
            };
        }
    }

    /// <summary>
    /// myobs: 151	122	151	122	151	122
    /// </summary>
    public class CowManglerAlt : ARocketLauncher
    {
        public CowManglerAlt()
        {
            Name = "cowmangler charged shot";
            ActivationTime = 4;

            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(90)
            //    {
            //        Offset = Damage.OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP, // 1.25 makes more sense and also works fine. Had 1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1),
            //};
            //FireRate = 0.8;

            Effect = new BuildingEffect()//AfterburnEffect(0);//TODO time?
            {
                Name = "Mini-crit; Disable Building (time); Afterburn(time)"
            };
        }
    }


    /// <summary>
    /// myobs: 112	48	151	122	270	270
    /// wiki: 105-112	24-48	151	122	135-270
    /// </summary>
    public class BeggarsBazooka : ARocketLauncher
    {
        //-20% explosion radius
        public BeggarsBazooka()
            :base(90m, 1100m, 
                 AOE.DEFAULT_SPLASH * 0.8m)
        {
            Name = "Beggar's Bazooka";

            // +3 degrees random projectile deviation
            Projectile.Spread = 0.05236m;

            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(90)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP, // 1.25 makes more sense and also works fine. Had 1.24444444444444,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },

            //    Propelled = true,
            //    Spread = 0.05236m,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.8m)
            //};
            FireRate = 0.24m;
        }
    }

    /// <summary>
    /// 96	40	129	103	230	230
    /// wiki: 90-95	20-40	129	103	115-230
    /// </summary>
    public class AirStrike : ARocketLauncher
    {
        // -15% damage penalty
        // -10% explosion radius
        // TODO point blank obs/wiki of 95; calcs as 96
        public AirStrike()
            :base(76.5m,
                 1100, 
                 AOE.DEFAULT_SPLASH * 0.9m)
        {
            Name = "Air Strike";

            //Projectile = new Projectile(1100)
            //{
            //    HitDamage = new Damage(76.5)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = Damage.NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP, // 1.25 makes more sense and also works fine. Had 1.25490196078431,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Propelled = true,
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.9)
            //};
            FireRate = 0.28m;

            //TODO alt with more heads (larger clip)
            //TODO alt with blast jumping (smaller radius, faster rate)
        }
    }

}