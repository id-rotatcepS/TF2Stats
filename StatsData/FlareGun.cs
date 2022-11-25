using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class AFlareGun : Weapon
    {
        public AFlareGun(decimal baseDamage = 30, decimal speed = 2000, decimal splashRadius = 0)
        {
            Name = "flare guns";

            Projectile = new Projectile(speed)
            {
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_1_ROCKETS_FLARES,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

                Splash = splashRadius > 0 ? new AOE(splashRadius) : null
            };
            FireRate = 2;

            Effect = new AfterburnEffect(7.5m);
        }
    }

    /// <summary>
    /// myobs: 30	30	41	41	90	90
    /// pb: 30; long: 30; pb mc: 41; long mc: 41; pb crit: 90
    /// </summary>
    public class FlareGun : AFlareGun
    {
        public FlareGun()
        {
            Name = "Flare Gun";

            //Projectile = new Projectile(2000)
            //{
            //    HitDamage = new Damage(30)
            //    {
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 2;

            AlternateModes = new List<Weapon>
            {
                new FlareGunBurning()
            };
        }
    }

    internal class FlareGunBurning : AFlareGun
    {
        public FlareGunBurning()
        {
            Name = "(burning)";

            // 10s and crit damage on burning players
            Effect = new AfterburnEffect(10m)
            {
                Name = "Crit; Afterburn"
            };
        }
    }

    /// <summary>
    /// myobs: 23	23	30	30	68	68
    /// pb: 23 (D/H); long: 23 (D/H); pb mc: 30 (D/H); long mc: 30 (D/H); pb c: 68 (D/H)
    /// </summary>
    public class Detonator : AFlareGun
    {
        // -25% damage penalty
        public Detonator()
            :base(22.5m,//23
                 2000)
        {
            Name = "Detonator";

            //Projectile = new Projectile(2000)
            //{
            //    HitDamage = new Damage(22.5)//23)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            ////FireRate = 2;

            AlternateModes = new List<Weapon>
            {
                new DetonatorBurning(),
                new DetonatorExplosion()
            };
        }
    }

    internal class DetonatorExplosion : AFlareGun
    {
        //TODO +50% damage to self
        public DetonatorExplosion()
            : base(22.5m,//23
                 2000,
                 AOE.FLARE_SPLASH)
        {
            Name = "(triggered)";

            Effect = new AfterburnEffect(7.5m)
            {
                Name = "Destroy Stickybombs; Afterburn"
            };
        }
    }

    internal class DetonatorBurning : AFlareGun
    {
        public DetonatorBurning()
            : base(22.5m,//23
                 2000)
        {
            Name = "(burning)";

            Effect = new AfterburnEffect(10m)
            {
                Name = "Mini-Crit; Afterburn"
            };
        }
    }

    /// <summary>
    /// 30	30	41	41	90	90
    /// wiki: 30	30	41	41	90
    /// </summary>
    public class Manmelter : AFlareGun
    {
        public Manmelter()
            :base(30, 
                 3000)
        {
            Name = "Manmelter";

            //Projectile = new Projectile(3000)
            //{
            //    HitDamage = new Damage(30)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //};
            ////FireRate = 2;
            AlternateModes = new List<Weapon>
            {
                new ManmelterBurning()
            };
        }
    }

    internal class ManmelterBurning : AFlareGun
    {
        public ManmelterBurning()
            : base(30,
                 3000)
        {
            Name = "(burning)";

            // 10s on burning players
            Effect = new AfterburnEffect(10m);//according to wiki
        }
    }

    /// <summary>
    /// 20	20	26	26	59	59
    /// wiki: 20	20	26	26	59
    /// </summary>
    public class ScorchShot : AFlareGun
    {
        //-35% damage penalty
        public ScorchShot()
            : base(19.5m,//20
                 2000,
                 AOE.FLARE_SPLASH)
        {
            Name = "Scorch Shot";

            //Projectile = new Projectile(2000)
            //{
            //    HitDamage = new Damage(19.5)//20)
            //    {
            //        Offset = Damage.OFFSET_1_ROCKETS_FLARES,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    Splash = new AOE(AOE.DEFAULT_SPLASH * 1)
            //};
            ////FireRate = 2;

            Effect = new AfterburnEffect(7.5m)
            {
                Name = "Knockback; Destroy Stickybombs; Afterburn"
            };

            AlternateModes = new List<Weapon>()
            {
            //TODO represent "rollers" somehow? it's just normal damage from an abnormal "penetrating" projectile, I think.
                new ScorchShotBurningTarget() // extra knockback bonus
            };
        }
    }

    public class ScorchShotBurningTarget : AFlareGun
    {
        public ScorchShotBurningTarget()
            : base(19.5m,//20
                 2000,
                 AOE.FLARE_SPLASH)
        {
            Name = "(burning)";

            Effect = new AfterburnEffect(10m)
            {
                Name = "Extra Knockback; Mini-Crit; Destroy Stickybombs; Afterburn"
            };
        }
    }
}