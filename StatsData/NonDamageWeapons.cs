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
            Name = "Buff Banner"; Level = 5; WeaponType = "Battle Banner"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Provides an offensive buff that causes nearby team members to do mini-crits. Rage increases through damage done."),
});
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
            Name = "Battalion's Backup"; Level = 10; WeaponType = "Battle Banner"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+20 max health on wearer"),
new DescriptionAttribute("Provides a defensive buff that protects nearby team members from crits, incoming sentry damage by 50% and 35% from all other sources.<br>Rage increases through damage done."),
}); 
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
            Name = "Concheror"; Level = 5; WeaponType = "Sashimono"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+4 health regenerated per second on wearer"),
new DescriptionAttribute("Provides group speed buff<br>with damage done giving health.<br>Gain rage with damage."),
}); 
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
            Name = "B.A.S.E. Jumper";/*Level*/WeaponType = "Parachute"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Press 'JUMP' key in the air to deploy.<br>Deployed Parachutes slow your descent."),
}); 
        }
    }

    public class Gunboats : PassiveJumpAssist
    {
        public Gunboats()
        {
            //Offset = 23.5,
            Name = "Gunboats"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("-60% blast damage from rocket jumps"),
}); 
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
            Name = "Ali Baba's Wee Booties"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25 max health on wearer"),
new PositiveAttribute("+200% increase in turning control while charging"),
new PositiveAttribute("+10% faster move speed on wearer (shield required)"),
new PositiveAttribute("Melee kills refill 25% of your charge meter."),
}); 
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
            Name = "Razorback"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Blocks a single backstab attempt"),
new NegativeAttribute("-100% maximum overheal on wearer"),
}); 
        }
    }

    public class DarwinsDangerShield : PassiveShields
    {
        public DarwinsDangerShield()
        {
            //Offset = 23.5,
            Name = "Darwin's Danger Shield"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% fire damage resistance on wearer"),
new PositiveAttribute("Immune to the effects of afterburn."),
}); 
        }
    }

    public class CozyCamper : PassiveShields
    {
        public CozyCamper()
        {
            //Offset = 23.5,
            Name = "Cozy Camper"; Level = 10; WeaponType = "Backpack"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+4 health regenerated per second on wearer"),
new PositiveAttribute("No flinching when aiming and fully charged"),
new PositiveAttribute("Knockback reduced by 20% when aiming"),
});
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
            Name = "Sandvich"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Eat to regain up to 300 health.<br>Alt-fire: Share a Sandvich with a friend (Medium Health Kit)"),
});
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
            Name = "Dalokohs Bar"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Adds +50 max health for 30 seconds"),
new DescriptionAttribute("Eat to gain up to 100 health.<br>Alt-fire: Share chocolate with a friend (Small Health Kit)"),
}); 
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
            Name = "Buffalo Steak Sandvich"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("After consuming, move speed is increased, attacks mini-crit, and the player may only use melee weapons. Lasts 16 seconds.<br>Alt-fire: Share with a friend (Medium Health Kit)<br><br>Who needs bread?"),
});
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
            Name = "Second Banana"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% increase in charge recharge rate"),
new NegativeAttribute("-33% healing effect"),
new DescriptionAttribute("Eat to gain health<br />Alt-fire: Share banana with a friend (Small Health Kit)"),
});
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
            Name = "Bonk! Atomic Punch"; Level = 5; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Drink to become invulnerable for 8 seconds. Cannot attack during this time.<br>Damage absorbed will slow you when the effect ends."),
});
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
            Name = "Crit-a-Cola"; Level = 5; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("While effect is active: each attack mini-crits and sets Mark-For-Death for 5 seconds."),
});
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
            Name = "Jarate"; Level = 5; WeaponType = "Jar Based Karate"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("Coated enemies take mini-crits"),
new NeutralAttribute("Can be used to extinguish fires."),
new PositiveAttribute("Extinguishing teammates reduces cooldown by -20%"),
}); 
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
            Name = "Mad Milk"; Level = 5; WeaponType = "Non-Milk Substance"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Extinguishing teammates reduces cooldown by -20%"),
new DescriptionAttribute("Players heal 60% of the damage done to an enemy covered with milk.<br>Can be used to extinguish fires."),
});
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
            Name = "Gas Passer"; Level = 1 - 100; WeaponType = "Gas-Like Substance"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Gas meter builds with damage done and/or time"),
new NegativeAttribute("Spawning and resupply do not affect the Gas meter"),
new NegativeAttribute("Gas meter starts empty"),
new DescriptionAttribute("Creates a horrific visible gas that coats enemies with a flammable material, which then ignites into afterburn if they take damage (even enemy Pyros!)"),
});
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
            Name = "Sapper"; Level = 1; WeaponType = "Sapper"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n"),
new DescriptionAttribute("Place on enemy buildings to disable and slowly drain away its health. Placing a sapper does not remove your disguise"),
});
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
            Name = "Red-Tape Recorder"; Level = 1 - 100; WeaponType = "Sapper"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Reverses enemy building construction"),
new NegativeAttribute("-100% Sapper damage penalty"),
});
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
            Name = "Invis Watch"; Level = 1; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new DescriptionAttribute("Alt-Fire: Turn invisible. Cannot attack while invisible. Bumping in to enemies will make you slightly visible to enemies"),
});

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
            Name = "Dead Ringer"; Level = 5; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("Cloak Type: Feign Death"),
new NeutralAttribute("Leave a fake corpse on taking damage<br>and temporarily gain invisibility, speed and damage resistance"),
new PositiveAttribute("+50% cloak regen rate"),
new PositiveAttribute("+40% cloak duration"),
new NegativeAttribute("-50% cloak meter when Feign Death is activated"),
}); 
        }
    }

    public class CloakAndDagger : InvisWatch
    {
        public CloakAndDagger()
        {
            Name = "Cloak & Dagger";
            Name = "Cloak and Dagger"; Level = 5; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("Cloak Type: Motion Sensitive"),
new NeutralAttribute("Alt-Fire: Turn invisible. Cannot attack while invisible. Bumping in to enemies will make you slightly visible to enemies."),
new NeutralAttribute("Cloak drain rate based on movement speed"),
new PositiveAttribute("+100% cloak regen rate"),
new NegativeAttribute("No cloak meter from ammo boxes when invisible"),
new NegativeAttribute("-35% cloak meter from ammo boxes"),
});
        }
    }

}