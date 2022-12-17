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
            FireRate = 0m; // single shot reload is functionally its rate

            Effect = new AfterburnEffect(7.5m);

            Ammo = new Ammo(1, 16)
            {
                Reload = 2.0m,
                ReloadUsing = "Passive",
            };
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
            Name = "Flare Gun"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("100% critical hit vs burning players"),
new DescriptionAttribute("This weapon will reload when not active"),
}); 
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
            Effect = new AfterburnEffect(10m);
            Effects.Add(new Effect
            {
                Name = "Crit"
            });
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
            Name = "Detonator"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("100% mini-crits vs burning players"),
new NegativeAttribute("-25% damage penalty"),
new NegativeAttribute("+50% damage to self"),
new DescriptionAttribute("Alt-Fire: Detonate flare.<br>This weapon will reload automatically when not active."),
});
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

            Effect = new AfterburnEffect(7.5m);
            Effects.Add(new Effect()
            {
                Name = "Destroy Stickybombs"
            });
        }
    }

    internal class DetonatorBurning : AFlareGun
    {
        public DetonatorBurning()
            : base(22.5m,//23
                 2000)
        {
            Name = "(burning)";

            Effect = new AfterburnEffect(10m);
            Effects.Add(new Effect()
            {
                Name = "Mini-Crit"
            });
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
            Name = "Manmelter"; Level = 30; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% projectile speed"),
new PositiveAttribute("Does not require ammo"),
new PositiveAttribute("Alt-Fire: Extinguish teammates to gain guaranteed critical hits"),
new PositiveAttribute("Extinguishing teammates restores 20 health"),
new NegativeAttribute("No random critical hits"),
new DescriptionAttribute("This weapon will reload automatically when not active.<br><br>Being a device that flouts conventional scientific consensus that the molecules composing the human body must be arranged \"just so\", and not, for example, across a square-mile radius."),
}); 
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

            Ammo.Carried = Ammo.INFINITE_AMMO;
        }
    }

    internal class ManmelterBurning : AFlareGun
    {
        public ManmelterBurning()
            : base(30,
                 3000)
        {
            Name = "(burning)";

            Ammo.Carried = Ammo.INFINITE_AMMO;

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
            Name = "Scorch Shot"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("100% mini-crits vs burning players"),
new PositiveAttribute("Flare knocks back target on hit and explodes when it hits the ground."),
new PositiveAttribute("Increased knockback on burning players"),
new NegativeAttribute("-35% self damage force"),
new NegativeAttribute("-35% damage penalty"),
new DescriptionAttribute("This weapon will reload automatically when not active."),
});
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

            Effect = new AfterburnEffect(7.5m);
            Effects.Add(new Effect()
            {
                Name = "Knockback; Destroy Stickybombs"
            });

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

            Effect = new AfterburnEffect(10m);
            Effects.Add(new Effect()
            {
                Name = "Extra Knockback; Mini-Crit; Destroy Stickybombs"
            });
        }
    }
}