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
                Splash = new AOE(splashRadius)
            };
            FireRate = 0.6m;

            //fuse (if no impact or contact with surfaces):
            ActivationTime = 2.3m;//wiki text says 2.3s;//TODO bad use of ActivationTime?
        }
    }

    public class GrenadeLauncher : AGrenadeLauncher
    {
        public GrenadeLauncher()
        {
            Name = "grenade launcher";

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
                // Using Armtime=fuse time to express it doesn't explode on impact when it's a roller.
                ArmTime = 2.3m,
            };
            FireRate = 0.6m;
            //fuse:
            ActivationTime = 2.3m;//wiki text says 2.3s;//TODO bad use of ActivationTime?
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
            Name = "loose cannon";

            Projectile = new Projectile(1453.9m)// wd; 1440 in other sheet
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_3_GRENADE_STICKY_JARS,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 0.5m, // per wiki.
                    // wiki says crit affected by range.
                    CritIncludesRamp = true,
                },
                // no splash or explosion (technically explosive damage classification however)
                // TODO increased knockback

                Penetrating = true // Sort of... it can hit multiple enemies in this mode until it hits a surface.
            };
            FireRate = 0.6m;

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
            // Using Armtime=fuse time to express it doesn't explode on impact when it's a roller.
            Projectile.ArmTime = 1.0m;

            ActivationTime = 1.0m;// "Cannonballs have a fuse time of 1 second; fuses can be primed to explode earlier by holding down the fire key."
        }
    }

    public class IronBomber : AGrenadeLauncher
    {
        //"-30% fuse time on grenades"
        //"-15% explosion radius"
        public IronBomber()
            :base(AOE.DEFAULT_SPLASH * 0.85m)
        {
            Name = "iron bomber";

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
            Projectile.ArmTime = 1.61m; //2.3 s * 0.70 = 1.61 s
            ActivationTime = 1.61m;

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
            // Using Armtime=fuse time to express it doesn't explode on impact when it's a roller.
            Projectile.ArmTime = 1.61m;
            ActivationTime = 1.61m;//I had 2.0m;... but that's not 2.3m -30%
        }
    }

}