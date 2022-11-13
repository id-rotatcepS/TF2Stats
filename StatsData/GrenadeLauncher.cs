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
                //TODO but it doesn't explode on impact...no way to express that?
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
            ActivationTime = 2.3m;//wiki text says 2.3s;//TODO bad use of ActivationTime?
        }
    }

    public class GrenadeLauncherRoller : AGrenadeLauncherRoller
    {
        public GrenadeLauncherRoller()
        {
            Name = "grenade launcher (roller)";
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

            // technically it has explode on fuse expiration flak
            //fuse (if no impact or contact with surfaces):
            ActivationTime = 2.3m;//TODO bad use of ActivationTime?

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
                    //TODO wiki says crit affected by range.
                },
                // no splash or explosion (technically explosive damage classification however)
                // TODO increased knockback

                Penetrating = true // Sort of... it can hit multiple enemies in this mode until it hits a surface.
            };
            FireRate = 0.6m;

            Effect = new Effect()
            {
                Name = "Donk (take mini-crit & no-radius-falloff fuse explosion (double-donk))"
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
            Name = "Loose Cannon (fuse)";

            ActivationTime = 1.0m;// "Cannonballs have a fuse time of 1 second; fuses can be primed to explode earlier by holding down the fire key."
        }
    }

    public class IronBomber : AGrenadeLauncher
    {
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

            AlternateModes = new List<Weapon>()
            {
                new IronBomberRoller()
            };
        }
    }

    public class IronBomberRoller : AGrenadeLauncherRoller
    {
        public IronBomberRoller()
            :base(AOE.DEFAULT_SPLASH * 0.85m)
        {
            Name = "iron bomber (roller)";

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
            //ActivationTime = 2.0;//TODO FIXME value? bad use of ActivationTime?
        }
    }

}