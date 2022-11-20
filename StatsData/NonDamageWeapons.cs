using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    //TODO rocketjumper, stickyjumper

    public abstract class Banners : Weapon
    {
        public Banners()
        {
            Name = "banners";

            AreaOfEffect = new BannerAOE();//TODO FIXME value??

            FireRate = -1;
        }
    }

    public class BuffBanner : Banners
    {
        public BuffBanner()
        {
            //Offset = 23.5,
            Name = "buff banner";
            ActivationTime = 3;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Mini-crit Buff",
                Maximum = 10 // TODO value??
            };
        }
    }

    public class BatallionsBackup : Banners
    {
        public BatallionsBackup()
        {
            //Offset = 23.5,
            Name = "batallion's backup";
            ActivationTime = 2.645m;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Crit Protection, etc.",
                Maximum = 10 // TODO value??
            };
        }
    }

    public class Concheror : Banners
    {
        public Concheror()
        {
            //Offset = 23.5,
            Name = "concheror";
            ActivationTime = 3;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Speed Buff, Leach, Passive Health regen",
                Maximum = 10 // TODO value??
            };
            //PassiveEffect = new Effect()
            //{
            //    Name = "Heal",
            //    Damage = new Damage(-1), // TODO value?
            //    DamageRate = .5 //  TODO value?
            //};
        }
    }

    public abstract class PassiveJumpAssist : Weapon
    {
        public PassiveJumpAssist()
        {
            Name = "passive jump assists";

            FireRate = -1;
        }
    }

    public class BASEJumper : PassiveJumpAssist
    {
        public BASEJumper()
        {
            //Offset = 23.5,
            Name = "BASE jumper";

            FireRate = -1;
        }
    }

    public class Gunboats : PassiveJumpAssist
    {
        public Gunboats()
        {
            //Offset = 23.5,
            Name = "gunboats";

            FireRate = -1;
        }
    }

    public abstract class PassiveChargeAssists : Weapon
    {
        public PassiveChargeAssists()
        {
            Name = "passive charge assists";

            FireRate = -1;
        }
    }

    public class AliBabasWeeBooties : PassiveChargeAssists
    {
        public AliBabasWeeBooties()
        {
            //Offset = 23.5,
            Name = "ali baba's wee booties / bootlegger";

            FireRate = -1;
        }
    }

    public abstract class PassiveShields : Weapon
    {
        public PassiveShields()
        {
            Name = "passive shields";

            FireRate = -1;
        }
    }

    public class Razorback : PassiveShields
    {
        public Razorback()
        {
            //Offset = 23.5,
            Name = "razorback";

            FireRate = -1;
        }
    }

    public class DarwinsDangerShield : PassiveShields
    {
        public DarwinsDangerShield()
        {
            //Offset = 23.5,
            Name = "darwin's danger shield";

            FireRate = -1;
        }
    }

    public class CozyCamper : PassiveShields
    {
        public CozyCamper()
        {
            //Offset = 23.5,
            Name = "cozy camper";

            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Heal",
                Damage = new Damage(-1),//TODO VALUE?
                DamageRate = .5m, // TODO value?
            };
        }
    }

    public abstract class TeammateHealthpack : Weapon
    {
        public TeammateHealthpack()
        {
            Name = "teammate healthpack";

            FireRate = -1;
        }
    }

    public abstract class ShareableLunchbox : Weapon
    {
        public ShareableLunchbox()
        {
            Name = "lunchbox(shareable snack)";

            FireRate = -1;
        }
    }

    public class Sandvich : ShareableLunchbox
    {
        public Sandvich()
        {
            //Offset = 23.5,
            Name = "sandvich";
            ActivationTime = 4.3m;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Heal",
                Damage = new Damage(-50),//TODO VALUE?
                DamageRate = .5m, // TODO value?
            };
        }
    }

    public class DalokahsBar : ShareableLunchbox
    {
        public DalokahsBar()
        {
            //Offset = 23.5,
            Name = "dalokahs bar";
            ActivationTime = 4.3m;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Heal",
                Damage = new Damage(-1),//TODO VALUE?
                DamageRate = .5m, // TODO value?

                //Effect = new Effect()
                //{
                //    Name = "Chocolate",
                //    Maximum
                //}
            };
        }
    }

    public class BuffaloSteakSandvich : ShareableLunchbox
    {
        public BuffaloSteakSandvich()
        {
            //Offset = 23.5,
            Name = "buffalo steak sandvich";
            ActivationTime = 4.3m;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Heal",
                Damage = new Damage(-1),//TODO VALUE?
                DamageRate = .5m, // TODO value?
                //Effect = new Effect()
                //{
                //    Name = "Melee Crit",
                //    Maximum = 
                //}
            };
        }
    }

    public class SecondBanana : ShareableLunchbox
    {
        public SecondBanana()
        {
            //Offset = 23.5,
            Name = "second banana";
            ActivationTime = 4.3m;
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Heal",
                Damage = new Damage(-25),//TODO VALUE?
                DamageRate = .5m, // TODO value?
            };
        }
    }

    public abstract class Lunchbox : Weapon
    {
        public Lunchbox()
        {
            Name = "lunchbox(drink)";

            FireRate = -1;
        }
    }

    public class BonkAtomicPunch : Lunchbox
    {
        public BonkAtomicPunch()
        {
            //Offset = 23.5,
            Name = "bonk! atomic punch";
            ActivationTime = 1.2m;
            FireRate = -1;
            Effect = new Effect()
            {
                Name = "Phase",
                //Maximum = 
            };
        }
    }

    public class CritACola : Lunchbox
    {
        public CritACola()
        {
            //Offset = 23.5,
            Name = "crit - a - cola";
            ActivationTime = 1.2m;
            FireRate = -1;
            Effect = new Effect()
            {
                Name = "Mini-Crit buff and debuff",
                //Maximum = 
            };
        }
    }

    //public class TeammateExtinguisher : Weapon
    //{
    //    public TeammateExtinguisher()
    //    {
    //        Name = "teammate extinguisher";

    //        Hitscan = new Hitscan()
    //        {
    //            Damage = new Damage()
    //            {
    //                //Offset = ,
    //                ZeroRangeRamp = 1,
    //                LongRangeRamp = 1,
    //            },
    //            Fragmentation = new Fragmentation()
    //            {


    //            },
    //            Recoil = new Recoil()
    //            {

    //            },

    //        };
    //        FireRate = -1;
    //    }
    //}

    public abstract class ThrowableAOE : Weapon
    {
        public ThrowableAOE()
        {
            Name = "throwable AOE";

            Projectile = new Projectile(0)//TODO FIXME VALUE!
            {
                Splash = new AOE(AOE.DEFAULT_SPLASH * 1)//TODO FIXME value?

            };
            FireRate = -1;
        }
    }

    public class Jarate : ThrowableAOE
    {
        public Jarate()
        {
            Name = "jarate";
            Projectile = new Projectile(1017.9m)//wd
            {
                //no damage, but Offset = 32,.. but Damage.OFFSET_3_GRENADE_STICKY_JARS which is 23.5!
                Splash = new AOE(AOE.DEFAULT_SPLASH * 1.0m),//TODO FIXME value?
            };
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Mini-crit",
                //TODO Maximum =
            };
        }
    }

    public class MadMilk : ThrowableAOE
    {
        public MadMilk()
        {
            Name = "mad milk";

            Projectile = new Projectile(1019.9m)//wd
            {
                //no damage, but Offset = 32,.. but Damage.OFFSET_3_GRENADE_STICKY_JARS which is 23.5!
                Splash = new AOE(AOE.DEFAULT_SPLASH * 1),//TODO FIXME value?
            };
            FireRate = -1;

            Effect = new Effect()
            {
                Name = "Leach",
                //TODO Maximum =
            };
        }
    }

    public class GasPasser : ThrowableAOE
    {
        public GasPasser()
        {
            Name = "gas passer";
            ActivationTime = 60;
            Projectile = new Projectile(2009.2m)//basis? 2009.2 on wd
            {
                //no damage, but Offset = 32,.. but Damage.OFFSET_3_GRENADE_STICKY_JARS which is 23.5!
                Splash = new AOE(AOE.DEFAULT_SPLASH * 1.0m),//TODO FIXME value?
            };
            FireRate = -1;
            //TODO Splash Hang Time
            Effect = new Effect()
            {
                Name = "Flammable",
                //TODO Maximum =
            };
        }
    }

    public class Sapper : Weapon
    {
        public Sapper()
        {
            Name = "sapper";

            Melee = new Melee()
            {
                Damage = new Damage(0)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                }
            };

            // oversimplified still... It's "build sapper" and sapper has health and effect "sap building"
            Effect = new BuildingEffect() { Name = "Sapped" };

            FireRate = -1;
        }
    }

    public class RedTapeRecorder : Sapper
    {
        public RedTapeRecorder()
        {
            Name = "red tape recorder";

            Melee = new Melee()
            {
                //{
                //    Offset = 23.5,
                //}
            };
            Effect = new BuildingEffect() { Name = "Unbuilding" };
            FireRate = -1;
        }
    }

    public class InvisWatch : Weapon
    {
        public InvisWatch()
        {
            Name = "invis watch";

            FireRate = -1;
        }
    }

    public class Deadringer : InvisWatch
    {
        public Deadringer()
        {
            Name = "deadringer";

            FireRate = -1;
        }
    }

    public class CloakAndDagger : InvisWatch
    {
        public CloakAndDagger()
        {
            Name = "Cloak & Dagger";

            FireRate = -1;
        }
    }

}