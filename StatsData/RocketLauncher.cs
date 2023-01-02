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
            Notes += "Close Range 124.6% I invented as a single value that works with Liberty Launcher and everything else - When using offset=32 (no min separation).\n";
            Notes += "**CLOSE RANGE REQUIRES OFFSET - 125% works with all when using offset=23.5 (documented value) but NOT with 32 (no min separation).\n";
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

            Ammo = new Ammo(4, 20)
            {
                ReloadFirst = 0.92m,
                ReloadAdditional = 0.8m,
            };
        }
    }

    public class RocketLauncher : ARocketLauncher
    {
        public RocketLauncher()
        {
            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Dual-use: Impact or Rocket Jump"),
            new PositiveAttribute("+11% self push force from rocket jumps"),
            new NegativeAttribute("Self inflicted blast damage"),
            new NegativeAttribute("-44% self push force on ground"),
            new NeutralAttribute("Explosive: 50%-100% damage in explosion radius"),
            new NeutralAttribute("Blasts push enemy stickybombs away"),
            new DescriptionAttribute("Impact: Explodes on contact with players, buildings, and surfaces<br/>Rocket Jump: Mobility from self-damage"),
            });
           
            Name = "Rocket Launcher";
            Name = "Rocket Launcher"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n90 explosive damage (113 dps) 124%-53% by range\n Straight projectile accurate to 18%, explosion to 122% range\nReloads 4 in 3.3 sec (first in 0.9 sec), 20 carried"),
});
//            Name = "Rocket Jumper"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+200% max primary ammo on wearer"),
//new PositiveAttribute("No self inflicted blast damage taken"),
//new NegativeAttribute("-100% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Wearer cannot carry the intelligence briefcase or PASS Time JACK"),
//new DescriptionAttribute("A special rocket launcher for learning <br> rocket jump tricks and patterns. <br> This weapon deals ZERO damage."),
//}); 
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

        // +25% damage bonus
        // +80% projectile speed
        // -70% explosion radius
        public DirectHit()
            :base(112.5m,//112.5=(90*1.25), but weapon_damage I had 112. //112)
                 1980,
                 AOE.DEFAULT_SPLASH * 0.3m)
        {
            Name = "Direct Hit"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% damage bonus"),
new PositiveAttribute("+80% projectile speed"),
new PositiveAttribute("Mini-crits targets launched airborne by explosions, grapple hooks or rocket packs."),
new NegativeAttribute("-70% explosion radius"),
});
            Name = "direct hit";
            Notes += "radius on wiki is rounded - is that editor simplifying or is that how the game uses it?\n";

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
            Effect = new Effect()
            {
                Name = "Mini-crit launched targets"
            };
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
            Name = "Black Box"; Level = 5; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Gain up to +20 health per attack"),
new NegativeAttribute("-25% clip size"),
});
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

            Effect = new Effect()
            {
                Name = "Leach up to 20hp"
            };

            Ammo.Loaded = 3;
        }
    }

    /// <summary>
    /// 84	36	114	91	203	203
    /// wiki: 79-84	18-36	114	91	101-203
    /// </summary>
    public class LibertyLauncher : ARocketLauncher
    {
        //-25% damage penalty
        //-25% blast damage from rocket jumps
        //+40% projectile speed

        //TODO wiki & obs have crit as 203, function times shows 202.
        public LibertyLauncher()
            :base(67.5m,//67.5=90*.75, had that in weapon_damage, wiki says:68, results work if ZeroRange is 1.25
            1540)
        {
            Name = "Liberty Launcher";
            Name = "Liberty Launcher"; Level = 25; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% clip size"),
new PositiveAttribute("+40% projectile speed"),
new PositiveAttribute("-25% blast damage from rocket jumps"),
new NegativeAttribute("-25% damage penalty"),
}); 
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

            Ammo.Loaded = 5;
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
            Name = "Cow Mangler 5000"; Level = 30; WeaponType = "Focused Wave Projector"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Does not require ammo"),
new PositiveAttribute("Alt-Fire: A charged shot that<br>mini-crits players, sets them on fire<br>and disables buildings for 4 sec"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Deals only 20% damage to buildings"),
new NegativeAttribute("Minicrits whenever it would normally crit"),
});
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

            // TODO FIXME actually has a custom crit-downgrade algorithm similar to mini-crit
            CanCrit = false;

            //"Deals only 20% damage to buildings"
            Projectile.HitDamage.BuildingModifier = .20m;

            AlternateModes = new List<Weapon>()
            {
                new CowManglerAlt()
            };

            Ammo.Carried = Ammo.INFINITE_AMMO;
        }
    }

    /// <summary>
    /// myobs: 151	122	151	122	151	122
    /// </summary>
    public class CowManglerAlt : ARocketLauncher
    {
        public CowManglerAlt()
        {
            Name = "charged shot";
            ActivationTime = 2;// I had 4 but that was probably from building disable.
            //TODO by label it feels like this, but functionally it's not ChargeTime = ;

            CanCrit = false;
            Projectile.HitDamage.BuildingModifier = .20m;

            Effect = new AfterburnEffect(6m);
            Effects.Add(new BuildingEffect()
            {
                Name = "Disable Building",
                Minimum = 4m,
                Maximum = 4m,
            });
            Effects.Add(new Effect()
            {
                Name = "Mini-crit; vaporize stickybombs",
            });
            
            Ammo.Carried = Ammo.INFINITE_AMMO;
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
            Name = "Beggar's Bazooka";/*Level*/WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Hold Fire to load up to three rockets"),
new PositiveAttribute("Release Fire to unleash the barrage"),
new NegativeAttribute("-20% explosion radius"),
new NegativeAttribute("+3 degrees random projectile deviation"),
new NegativeAttribute("Overloading the chamber will cause a misfire"),
new NegativeAttribute("No ammo from dispensers when active"),
}); 
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

            //TODO but this is after more than one is loaded.. what about when none are loaded? alt mode? activation time?
            FireRate = 0.24m;

            Ammo.InitialLoaded = 0;
            Ammo.Loaded = 3;
            Ammo.ReloadFirst = 1.196m;
            Ammo.ReloadAdditional = 1.04m;
        }
    }

    /// <summary>
    /// 96	40	129	103	230	230
    /// wiki: 90-95	20-40	129	103	115-230
    /// </summary>
    public class AirStrike : ARocketLauncher
    {
        // -15% damage penalty
        // -15% blast damage from rocket jumps
        // -10% explosion radius

        // TODO my calc (now) & my obs & point blank wiki of 95; wiki Ramp as 96 (my calc USED to do that too)
        public AirStrike()
            :base(76.5m,
                 1100, 
                 AOE.DEFAULT_SPLASH * 0.9m)
        {
            Name = "Air Strike";
            Name = "Air Strike";/*Level*/WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("-15% blast damage from rocket jumps"),
new PositiveAttribute("Increased attack speed and smaller blast radius while blast jumping"),
new PositiveAttribute("Clip size increased on kill"),
new NegativeAttribute("-15% damage penalty"),
new NegativeAttribute("-10% explosion radius"),
});
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
            FireRate = 0.80m;

            AlternateModes = new List<Weapon>
            {
                new MaxHeadsAirStrike(),
                new BlastJumpingAirStrike()
            };
        }
    }

    public class MaxHeadsAirStrike : ARocketLauncher
    {
        // Clip size increase
        public MaxHeadsAirStrike()
            : base(76.5m,
                 1100,
                 AOE.DEFAULT_SPLASH * 0.9m)
        {
            Name = "(max heads)";

            FireRate = 0.80m;

            Ammo.Loaded = 8;
        }
    }

    public class BlastJumpingAirStrike : ARocketLauncher
    {
        // Increased attack speed and smaller blast radius while blast jumping
        public BlastJumpingAirStrike()
            : base(76.5m,
                 1100,
                 (AOE.DEFAULT_SPLASH * 0.9m)*0.8m)
        {
            Name = "(rocket jumping)";

            FireRate = 0.28m;
        }
    }

}