using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class AFlareGun : Weapon
    {
        //Minicrit rounding issue: wiki shows 41, I get 40.
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

            Effect = new AfterburnEffect(10);//TODO time?
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
        }
    }


    /// <summary>
    /// myobs: 23	23	30	30	68	68
    /// pb: 23 (D/H); long: 23 (D/H); pb mc: 30 (D/H); long mc: 30 (D/H); pb c: 68 (D/H)
    /// </summary>
    public class Detonator : AFlareGun
    {
        //TODO rounding issue - this is rounding to 22 base damage in function times display.
        public Detonator()
            :base(22.5m,//23
                 2000, 
                 AOE.DEFAULT_SPLASH*1) // TODO no, explosion is an alternate mode.
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
            
            //AlternateModes = new List<Weapon>
            //{
            //    TODO new DetonatorTriggeredExplosion()
            //};
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
        }
    }

    /// <summary>
    /// 20	20	26	26	59	59
    /// wiki: 20	20	26	26	59
    /// </summary>
    public class ScorchShot : AFlareGun
    {
        //TODO rounding issue? wiki shows Critical of 59, my function times display is 58
        public ScorchShot()
            : base(19.5m,//20
                 2000,
                 AOE.DEFAULT_SPLASH * 1)
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

            //TODO knockback bonus

            AlternateModes = new List<Weapon>()
            {
                //new ScorchShotBurningTarget() // extra knockback bonus
            };
        }
    }
}