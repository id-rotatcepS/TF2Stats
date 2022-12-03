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
            CanCrit = false;
            CanMinicrit = false;
            AreaOfEffect = new BannerAOE();//TODO FIXME value??

            FireRate = 0;
        }
    }

    public class BuffBanner : Banners
    {
        public BuffBanner()
        {
            //Offset = 23.5,
            Name = "buff banner";
            ActivationTime = 3;

            Effect = new Effect()
            {
                Name = "Mini-crit Buff",
                Minimum = 10,
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
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class BASEJumper : PassiveJumpAssist
    {
        public BASEJumper()
        {
            //Offset = 23.5,
            Name = "BASE jumper";

        }
    }

    public class Gunboats : PassiveJumpAssist
    {
        public Gunboats()
        {
            //Offset = 23.5,
            Name = "gunboats";

        }
    }

    public abstract class PassiveChargeAssists : Weapon
    {
        public PassiveChargeAssists()
        {
            Name = "passive charge assists";
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class AliBabasWeeBooties : PassiveChargeAssists
    {
        public AliBabasWeeBooties()
        {
            //Offset = 23.5,
            Name = "ali baba's wee booties / bootlegger";

        }
    }

    public abstract class PassiveShields : Weapon
    {
        public PassiveShields()
        {
            Name = "passive shields";
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class Razorback : PassiveShields
    {
        public Razorback()
        {
            //Offset = 23.5,
            Name = "razorback";

        }
    }

    public class DarwinsDangerShield : PassiveShields
    {
        public DarwinsDangerShield()
        {
            //Offset = 23.5,
            Name = "darwin's danger shield";

        }
    }

    public class CozyCamper : PassiveShields
    {
        public CozyCamper()
        {
            //Offset = 23.5,
            Name = "cozy camper";

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
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public abstract class ShareableLunchbox : Weapon
    {
        public ShareableLunchbox()
        {
            Name = "lunchbox(shareable snack)";
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class Sandvich : ShareableLunchbox
    {
        public Sandvich()
        {
            //Offset = 23.5,
            Name = "sandvich";
            ActivationTime = 4.3m;

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
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class BonkAtomicPunch : Lunchbox
    {
        public BonkAtomicPunch()
        {
            //Offset = 23.5,
            Name = "bonk! atomic punch";
            ActivationTime = 1.2m;

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
            CanCrit = false;
            CanMinicrit = false;
            FireRate = 0;
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
            CanCrit = false;
            CanMinicrit = false;

            // oversimplified still... It's "build sapper" and sapper has health and effect "sap building"
            Effect = new BuildingEffect() { Name = "Sapped" };

            FireRate = 0;//TODO FIXME I know there is a rate for this... probably same as melee
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
            Effects.Clear();// not normal sap
            Effect = new BuildingEffect() { Name = "Unbuilding" };
        }
    }

    public class InvisWatch : Weapon
    {
        public InvisWatch()
        {
            Name = "invis watch";
            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0;
        }
    }

    public class Deadringer : InvisWatch
    {
        public Deadringer()
        {
            Name = "deadringer";

        }
    }

    public class CloakAndDagger : InvisWatch
    {
        public CloakAndDagger()
        {
            Name = "Cloak & Dagger";

        }
    }

}