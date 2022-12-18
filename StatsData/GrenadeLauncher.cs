using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class AGrenadeLauncher : Weapon
    {
        public AGrenadeLauncher(decimal splashRadius = AOE.DEFAULT_SPLASH * 1,
            decimal speed = 1216.6m,//wd; 1200 in other sheet
            decimal buildingModifier = 1.0m
            )
        {
            Name = "grenade launcher";

            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(100)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                    BuildingModifier = buildingModifier
                },
                Splash = new AOE(splashRadius),
            };
            FireRate = 0.6m;

            //fuse (if no impact or contact with surfaces):
            ActivationTime = 2.3m;//wiki text says 2.3s;
            Projectile.MaxRangeTime = ActivationTime;

            Ammo = new Ammo(4, 16)
            {
                ReloadFirst = 1.24m,
                ReloadAdditional = 0.6m,
            };
        }
    }

    public class GrenadeLauncher : AGrenadeLauncher
    {
        public GrenadeLauncher()
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Dual-use: Impact or Roller"),
            new PositiveAttribute("Deals 100% damage at any range"),
            new NegativeAttribute("Self inflicted blast damage"),
            new NeutralAttribute("Explosive: 50%-100% damage in explosion radius"),
            new NeutralAttribute("Blast knocks away enemy stickybombs"),
            new DescriptionAttribute("Impact: Explodes on contact with players and buildings<br/>Roller: -40% damage penalty from surface bounces, 2.3 second fuse"),
            });
            
            Name = "Grenade Launcher"; Level = 1; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n100 explosive damage (167 dps) \n Arced projectile accurate to 19%, explosion to 133% range\nReloads 4 in 3 sec (first in 1.2 sec), 16 carried"),
});
            AlternateModes = new List<Weapon>
            {
                new GrenadeLauncherRoller()
            };
        }
    }

    public abstract class AGrenadeLauncherRoller : Weapon
    {
        public AGrenadeLauncherRoller(decimal splashRadius = AOE.DEFAULT_SPLASH * 1,
            decimal speed = 1216.6m//wd; 1200 in other sheet
            )
        {
            Name = "grenade launcher (roller)";

            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(60)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                Splash = new AOE(splashRadius),
            };
            FireRate = 0.6m;
            //fuse:
            ActivationTime = 2.3m;//wiki text says 2.3s;
            Projectile.MaxRangeTime = ActivationTime;

            Ammo = new Ammo(4, 16)
            {
                ReloadFirst = 1.24m,
                ReloadAdditional = 0.6m,
            };
        }
    }

    public class GrenadeLauncherRoller : AGrenadeLauncherRoller
    {
        public GrenadeLauncherRoller()
        {
            Name = "(roller)";
        }
    }

    public class LochNLoad : AGrenadeLauncher
    {
        public LochNLoad()
            :base(AOE.DEFAULT_SPLASH * 0.75m,
            1513.3m, // wd; 1500 in other sheet
            1.20m)
        {
            Name = "loch n load";
            Name = "Loch-n-Load"; Level = 10; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+20% damage vs buildings"),
new PositiveAttribute("+25% projectile speed"),
new NegativeAttribute("-25% clip size"),
new NegativeAttribute("-25% explosion radius"),
new NegativeAttribute("Launched bombs shatter on surfaces"),
});
            //Projectile = new Projectile(1513.3)// wd; 1500 in other sheet
            //{
            //    HitDamage = new Damage(100)
            //    {
            //        Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,

            //        BuildingModifier = 1.20,
            //    },

            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.75)
            //};
            //FireRate = 0.6;

            // TODO technically it has explode on fuse expiration flak
            //fuse (if no impact or contact with surfaces):
            ActivationTime = 2.3m;
            Projectile.MaxRangeTime = ActivationTime;

            Ammo.Loaded = 3;

            AlternateModes = null;// no rollers
        }
    }

    /// <summary>
    /// myobs: 
    /// "summary: 34-50donk / explosion:30-56 (*81doubledonkMinicritNoRadius) - did not try to donk while moving away from target (or teleporting) seemed to do 50 at long range, and less beyond long range?
    /// 46/37 50/48 50/53 47/48 37/81* 42 50/54 /42_ (roller?)
    /// /32^ (air?) ""126""* 42/""123""* 45 50/54 35/81* /30 50 
    /// /36 38/81* 42/81* 43 47 34/81* /54? /56
    /// /roller52 /roller54 "
    /// c168(suspect... probably /168) c/150 c/roller125 c/?145
    /// </summary>
    public class LooseCannon : AGrenadeLauncher
    {
        public LooseCannon()
        {
            Name = "Loose Cannon"; Level = 10; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("Cannonballs have a fuse time of 1 second; fuses can be primed to explode earlier by holding down the fire key."),
new PositiveAttribute("+20% projectile speed"),
new PositiveAttribute("Cannonballs push players back on impact"),
new NegativeAttribute("Cannonballs do not explode on impact"),
new DescriptionAttribute("Double Donk! Bomb explosions after a cannon ball impact will deal mini-crits to impact victims"),
});
            Notes += "Needs more obs. ranged fuse in wiki, obs don't think so. obs: maybe falloff starts post-long range (time-based)? crit truly affected by range?\n";

            Projectile = new Projectile(1453.9m)// wd; 1440 in other sheet
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 0.5m, // per wiki.
                    //CritIncludesRamp = true, // wiki sort-of says crit affected by range.  Need evidence either way.  wiki's Function times matches better without ramp included.
                },
                // no splash or explosion (technically explosive damage classification however)
                // TODO increased knockback

                Penetrating = true // Sort of... it can hit multiple enemies in this mode until it hits a surface.
            };
            FireRate = 0.6m;

            ActivationTime = 0;// direct hits have no activation time, just roller fuses
            Effect = new Effect()
            {
                Name = "Donk (take mini-crit & no-radius-falloff fuse explosion (double-donk))",
                Minimum = 0.5m,
                Maximum = 0.5m
            };

            AlternateModes = new List<Weapon>()
            {
                new LooseCannonFuse(),// basically a roller, but doesn't have to hit something first.
            };
        }
    }

    public class LooseCannonFuse : AGrenadeLauncherRoller
    {
        public LooseCannonFuse()
        {
            Name = "(fuse)";

            ActivationTime = 1.0m;// "Cannonballs have a fuse time of 1 second; fuses can be primed to explode earlier by holding down the fire key."
            Projectile.MaxRangeTime = ActivationTime;
        }
    }

    public class IronBomber : AGrenadeLauncher
    {
        //"-30% fuse time on grenades"
        //"-15% explosion radius"
        public IronBomber()
            :base(AOE.DEFAULT_SPLASH * 0.85m)
        {
            Name = "Iron Bomber"; Level = 1 - 99; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Grenades have very little bounce and roll"),
new PositiveAttribute("-30% fuse time on grenades"),
new NegativeAttribute("-15% explosion radius"),
});
            //Projectile = new Projectile(1216.6)//wd; 1200 in other sheet
            //{
            //    HitDamage = new Damage(100)
            //    {
            //        Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.85)
            //};
            //FireRate = 0.6;
            ActivationTime = 1.61m;
            Projectile.MaxRangeTime = ActivationTime;

            AlternateModes = new List<Weapon>()
            {
                new IronBomberRoller()
            };
        }
    }

    public class IronBomberRoller : AGrenadeLauncherRoller
    {
        //"-30% fuse time on grenades"
        public IronBomberRoller()
            :base(AOE.DEFAULT_SPLASH * 0.85m)
        {
            Name = "(roller)";

            //FireRate = 0.6;
            //Projectile = new Projectile(1216.6)//wd; 1200 in other sheet
            //{
            //    HitDamage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 0.85)

            //};
            //FireRate = 0.6;
            ////fuse:
            ActivationTime = 1.61m;//I had 2.0m;... but that's not 2.3m -30%
            Projectile.MaxRangeTime = ActivationTime;
        }
    }

}