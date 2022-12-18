using StatsData;
using System.Collections.Generic;

namespace StatsData
{
    public abstract class MeleeWeapon : Weapon
    {
        public MeleeWeapon(decimal baseDamage = 65,
            decimal activationTime = 0.2m)// hits at end of swing;
        {
            Name = "Melee";

            Name = "Shovel"; Level = 1; WeaponType = "Shovel"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
}); Name = "Fire Axe"; Level = 1; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
}); Name = "Bottle"; Level = 1; WeaponType = "Bottle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
}); Name = "Fists"; Level = 1; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
}); Name = "Bonesaw"; Level = 1; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
}); Name = "Kukri"; Level = 1; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
});

            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Alt-Fire: Right cross"),
            new NeutralAttribute("Kill Taunt: Showdown"),

            });
            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Selects building to construct"),
            new PositiveAttribute("Buildings are immune to crits and mini-crits"),
            new NegativeAttribute("Buildings take 100% damage at any range"),
            new NeutralAttribute("Cannot pass through own buildings"),
            new NeutralAttribute("Metal cost: 130 (Sentry), 100 (Dispenser), or 50 (Teleporter)"),
            new DescriptionAttribute("Every building begins with a solid foundation, showing your mettle, and striking at the heart of the problem"),
            });
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Look and sound like others to the enemy"),
            new PositiveAttribute("Disguises fool enemy buildings"),
            new NegativeAttribute("Match move speed of slower disguise"),
            new NeutralAttribute("Attacking removes your disguise"),
            new NeutralAttribute("Cannot capture or taunt while disguised"),
            new NeutralAttribute("Taking damage or bumping enemies may give you away"),
            new DescriptionAttribute("Avoid suspicion by facing away from the enemy or running from your team's bullets to get behind the enemy"),
            });
           

            //            Name = "Lollichop"; Level = 1 - 100; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            //new PositiveAttribute("On Equip: Visit Pyroland"),
            //new NegativeAttribute("Only visible in Pyroland"),
            //new DescriptionAttribute("Fill (split) your buddies' tummies (skulls) with delicious candy (cold steel) with this oversized sugary treat. (Equips Pyrovision.)"),
            //}); 
            //            Name = "Apoco-Fists"; Level = 10; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            //new PositiveAttribute("Killing an enemy with a critical hit will dismember your victim. Painfully."),
            //new DescriptionAttribute("Turn every one of your fingers into the Four Horsemen of the Apocalypse! That's over nineteen Horsemen of the Apocalypse per glove! The most Apocalypse we've ever dared attach to one hand!"),
            //}); 
            Name = "Disguise Kit"; Level = 1; WeaponType = "...Cigarette Case?"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
});
            Name = "PDA"; Level = 1; WeaponType = "PDA"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
});
            Name = "Spellbook Magazine"; Level = 1; WeaponType = "Spellbook"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("This weapon deploys 50% faster"),
new DescriptionAttribute("A vintage edition of Casters Quarterly.<br>Found in the back of a closet, it contains just enough magic to get the job done.<br><br>Equip to enable picking up and casting spells."),
});
            Name = "Grappling Hook"; Level = 1; WeaponType = "Grappling Hook"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("This weapon holsters 80% faster"),
new PositiveAttribute("This weapon deploys 100% faster"),
new NeutralAttribute("Press and hold the Action key<br>to quickly fire a grapple line."),
new DescriptionAttribute("Optionally can be switched to by pressing slot6<br>and manually fired using primary attack.<br><br>Can only be used in Mannpower Mode or when enabled by the server."),
});
            Name = "Power Up Canteen"; Level = 1 - 100; WeaponType = "Usable Item"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Holds a maximum of 3 charges"),
new PositiveAttribute("Currently holds 0 charges"),
new PositiveAttribute("Each charge lasts 5 seconds"),
new DescriptionAttribute("Applies a bonus effect for a limited amount of time when used. Must first be filled at an Upgrade Station and can only be filled with one bonus type at a time."),
});

            // prefire swing
            ActivationTime = activationTime;
            Melee = new Melee()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                },
            };
            FireRate = 0.8m;
        }
    }

    public abstract class BuildingMaintenance : MeleeWeapon
    {
        public BuildingMaintenance(decimal baseDamage = 65)
            :base(baseDamage)
        {
            Attributes.Clear(); Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
new DescriptionAttribute("Upgrades, repairs and speeds up construction of friendly buildings on hit."),
});
            Name = "wrench";

            Effect = new BuildingEffect()
            {
                Name = "Building Maintenance"
            };
        }
    }

    public class Wrench : BuildingMaintenance
    {
        public Wrench()
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Dual-use: Melee or Maintenance"),
            new PositiveAttribute("Damages sappers"),
            new NegativeAttribute("-10% move speed while hauling"),
            new NeutralAttribute("Alt-Fire: Haul own building"),
            new DescriptionAttribute("Maintenance: Use metal to repair, reload, or upgrade friendly buildings on hit<br/>Speeds up construction of friendly buildings on hit<br/>Cannot repair old damage during redeploy"),
            });
            
            Name = "Wrench"; Level = 1; WeaponType = "Wrench";
            //ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            //FireRate = 0.8;
        }
    }

    public class SouthernHospitality : BuildingMaintenance
    {
        public SouthernHospitality()
        {
            Name = "The Southern Hospitality";
            Name = "Southern Hospitality"; Level = 20; WeaponType = "Wrench"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Bleed for 5 seconds"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("20% fire damage vulnerability on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;

            // TODO bleed effect AND maintenance (and 20% fire damage vuln & no random)
            Effect = new BleedEffect(5m);
            // AND new BuildingEffect() (already added by superclass)
        }
    }

    public class Jag : BuildingMaintenance
    {
        //"Construction hit speed boost increased by 30%"
        //"+15% faster firing speed"
        //"-25% damage penalty"
        //"20% slower repair rate"
        //"-33% damage penalty vs buildings"
        public Jag()
            :base(65*.75m)//=48.75m
        {
            Name = "The Jag";
            Level = 15;
            WeaponType = "Wrench";
            Attributes.AddRange(new WeaponAttribute[] {
                new PositiveAttribute("Construction hit speed boost increased by 30%"),
                new PositiveAttribute("+15% faster firing speed"),
                new NegativeAttribute("-25% damage penalty"),
                new NegativeAttribute("20% slower repair rate"),
                new NegativeAttribute("-33% damage penalty vs buildings"),
            });

            //TODO: Sappers: 65dmg -33% = 43;
            // buildings: 65*.75*.6666666666666667 = 32.49999; wiki says 32 dmg (whole math: 65 *3/4 *2/3 = 65/2 = 32.5 = 33dmg)
            Melee.Damage.BuildingModifier = 2m/3m; 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(48.75)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            
            FireRate = 0.68m;
        }
    }

    public class EurekaEffect : BuildingMaintenance
    {
        public EurekaEffect()
        {
            Name = "The Eureka Effect";
            Name = "Eureka Effect"; Level = 20; WeaponType = "Wrench"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Press your reload key to choose to teleport to spawn or your exit teleporter"),
new PositiveAttribute("-50% metal cost when constructing or upgrading teleporters"),
new NegativeAttribute("Construction hit speed boost decreased by 50%"),
new NegativeAttribute("20% less metal from pickups and dispensers"),
new DescriptionAttribute("Being a tool that eliminates exertion by harnessing the electrical discharges of thunder-storms for the vigorous coercion of bolts, nuts, pipes and similar into their rightful places. May also be used to bludgeon."),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;

            //alt: teleport  effect: different metal costs
        }
    }

    public class Gunslinger : BuildingMaintenance
    {
        public Gunslinger()
        {
            Name = "Gunslinger"; Level = 15; WeaponType = "Robot Arm"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25 max health on wearer"),
new PositiveAttribute("Sentry build speed increased by 150%"),
new PositiveAttribute("Third successful punch in a row always crits."),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Replaces the Sentry with a Mini-Sentry"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;

            //Effect? - PDA builds minisentries
        }
    }


    public abstract class AKnife : MeleeWeapon
    {
        public AKnife(decimal baseDamage = 40)
            : base(baseDamage,
                 activationTime: 0)// hits immediately;
        {
            Attributes.Clear();Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n40 damage (50 dps)"),
new DescriptionAttribute("Attack an enemy from behind to Backstab them for a one hit kill."),
            });
            Name = "knife";
            //ActivationTime = 0;// hits immediately;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(40)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class Knife : AKnife
    {
        public Knife(decimal baseDamage = 40)
            :base(baseDamage)
        {
            Attributes.AddRange(new WeaponAttribute[] {
            new NeutralAttribute("Dual-use: Butterknife or Backstab"),
            new PositiveAttribute("Backstab: Instant kill"),
            new PositiveAttribute("Hits at beginning of swing"),
            new NegativeAttribute("-23% damage penalty"),
            new NegativeAttribute("No random critical hits"),
            new NeutralAttribute("Kill Taunt: Fencing"),
            new DescriptionAttribute("Attack an enemy from behind to Backstab them for a one hit kill."),
            });
           
            Name = "Knife"; Level = 1; WeaponType = "Knife"; 

        }
    }

    public class YourEternalReward : AKnife
    {
        public YourEternalReward()
        {
            Name = "Your Eternal Reward"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Upon a successful backstab against a human target, you rapidly disguise as your victim"),
new PositiveAttribute("Silent Killer: No attack noise from backstabs"),
new NegativeAttribute("+33% cloak drain rate"),
new NegativeAttribute("Normal disguises require (and consume) a full cloak meter"),
}); 
            //ActivationTime = 0;// hits immediately;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(40)
            //};
            //FireRate = 0.8;
        }
    }

    public class ConniversKunai : AKnife
    {
        public ConniversKunai()
        {
            Name = "Conniver's Kunai"; Level = 1; WeaponType = "Kunai"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Backstab: Absorbs the health from your victim"),
new NegativeAttribute("-55 max health on wearer"),
new DescriptionAttribute("Start off with low health<br />Kill somebody with this knife<br />Steal all of their health"),
}); 
            //ActivationTime = 0;// hits immediately;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(40)
            //};
            //FireRate = 0.8;
        }
    }

    public class BigEarner : AKnife
    {
        public BigEarner()
        {
            Name = "Big Earner"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+30% cloak on kill"),
new PositiveAttribute("Gain a speed boost on kill"),
new NegativeAttribute("-25 max health on wearer"),
});
            //ActivationTime = 0;// hits immediately;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(40)
            //};
            //FireRate = 0.8;
        }
    }

    public class Spycicle : AKnife
    {
        public Spycicle()
        {
            Name = "spy - cicle";
            Name = "Spy-cicle"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit by Fire: Fireproof for 1 second and Afterburn immunity for 10 seconds"),
new NegativeAttribute("Backstab turns victim to ice"),
new NegativeAttribute("Melts in fire, regenerates in 15 seconds and by picking up ammo"),
new DescriptionAttribute("It's the perfect gift for the man who has everything: an icicle driven into their back. Even rich people can't buy that in stores."),
});

            //ActivationTime = 0;// hits immediately;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(40)
            //};
            //FireRate = 0.8;
        }
    }

    public abstract class ABat : MeleeWeapon
    {
        public ABat(decimal baseDamage = 35)
            : base(baseDamage)
        {
            Attributes.Clear();
            Name = "bat";
            //ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(35)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            FireRate = 0.5m;
        }
    }
    
    public class Bat : ABat
    {
        public Bat()
        {
            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Wielded by the Scout:"),
            new PositiveAttribute("+60% faster firing speed"),
            new NegativeAttribute("-47% damage penalty"),

            });
             Name = "Bat"; Level = 1; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n35 damage (70 dps)"),
});
            //            Name = "Holy Mackerel"; Level = 42; WeaponType = "Fish"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            //new DescriptionAttribute("Getting hit by a fish has got to be humiliating."),
            //}); 
        }
    }

    public class Sandman : ABat
    {
        public Sandman()
        {
            Name = "Sandman"; Level = 15; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Alt-Fire: Launches a ball that slows opponents"),
new NegativeAttribute("-15 max health on wearer"),
});
            //ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(35)
            //};
            //FireRate = 0.5;

            AlternateModes = new List<Weapon>
            {
                AltFire
            };
        }
         SandmanBall AltFire = new SandmanBall();
    }

    public class CandyCane : ABat
    {
        public CandyCane()
        {
            Name = "Candy Cane"; Level = 25; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Kill: A small health pack is dropped"),
new NegativeAttribute("25% explosive damage vulnerability on wearer"),
});
            //ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(35)
            //};
            //FireRate = 0.5;
        }
    }

    public class BostonBasher : ABat
    {
        public BostonBasher()
        {
            Name = "Boston Basher"; Level = 25; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Bleed for 5 seconds"),
new NegativeAttribute("On Miss: Hit yourself. Idiot."),
});
            //ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(35)
            //};
            //FireRate = 0.5;

            //TODO also self-damage of 18 on miss before bleed starts

            Effect = new BleedEffect(5m)
            {
                Name = "Bleeding (hit self on miss)"
            };
        }
    }

    public class SunOnAStick : ABat
    {
        public SunOnAStick()
            :base(26.25m)
        {
            Name = "Sun-on-a-Stick"; Level = 10; WeaponType = "RIFT Fire Mace"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("100% critical hit vs burning players"),
new PositiveAttribute("+25% fire damage resistance while deployed"),
new NegativeAttribute("-25% damage penalty"),
new DescriptionAttribute("Spiky end goes into other man."),
}); 
            ////ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(26.25)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.5;

            // Alternate burning target
        }
    }

    public class FanOWar : ABat
    {
        public FanOWar()
            : base(8.75m)
        {
            Name = "Fan O'War"; Level = 5; WeaponType = "Gunbai"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Crits whenever it would normally mini-crit"),
new PositiveAttribute("On Hit: One target at a time is Marked-For-Death, causing all damage taken to be mini-crits"),
new NegativeAttribute("-75% damage penalty"),
new DescriptionAttribute("Winds of Gravel Pit<br />Scout brings on his deadly fan!<br />You are Marked-For-Death"),
});
            ////ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(8.75)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.5;

            CanMinicrit = false;

            Effect = new Effect()
            {
                Name = "Marked For Death (only one)",
                Minimum = 15m,
                Maximum = 15m,
            };
            Effects.Add(new Effect()
            {
                Name = "Crits on minicrit"
            });
        }
    }

    public class Atomizer : ABat
    {
        public Atomizer()
            : base(29.75m)
        {
            Name = "Atomizer"; Level = 10; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Grants Triple Jump while deployed"),
new PositiveAttribute("Melee attacks mini-crit while airborne."),
new NegativeAttribute("-15% damage vs players"),
new NegativeAttribute("This weapon deploys 50% slower"),
}); 
            ////ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(29.75)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.5;
        }
    }

    public class WrapAssassin : ABat
    {
        public WrapAssassin()
            :base(8.75m)
        {
            Name = "Wrap Assassin"; Level = 15; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% increase in recharge rate"),
new PositiveAttribute("Alt-Fire: Launches a festive ornament that shatters causing bleed"),
new NegativeAttribute("-65% damage penalty"),
new DescriptionAttribute("These lovely festive ornaments are so beautifully crafted, your enemies are going to want to see them close up. Indulge them by batting those fragile glass bulbs into their eyes at 90 mph."),
});
            ////ActivationTime = 0.2;// hits at end of swing;
            //Melee = new Melee()
            //{
            //    Damage = new Damage(8.75)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.5;

            AlternateModes = new List<Weapon>
            {
                new WrapAssassinBauble()
            };
        }
    }

    public class ActiveMovementeMelee : MeleeWeapon
    {
        public ActiveMovementeMelee()
        {
            Attributes.Clear();
            Name = "active movement modifying melee";

            //FireRate = -1;
        }
    }

    public class EscapePlan : ActiveMovementeMelee
    {
        public EscapePlan()
        {
            Name = "Escape Plan"; Level = 10; WeaponType = "Pickaxe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("Move speed increases as the user becomes injured"),
new NegativeAttribute("You are marked for death while active, and for short period after switching weapons"),
new NegativeAttribute("-90% less healing from Medic sources"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class DisciplinaryAction : ActiveMovementeMelee
    {
        public DisciplinaryAction() // long range.
        {
            Name = "Disciplinary Action"; Level = 10; WeaponType = "Riding Crop"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit Teammate: Boosts both players' speed for several seconds"),
new NegativeAttribute("-25% damage penalty"),
}); 
            Melee = new Melee()
            {
                Damage = new Damage(48.75m)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                },
                MaxRange = 82,
            };
            //FireRate = 0.8;
            //Effect speed pair
        }
    }

    public class HotHand : ActiveMovementeMelee
    {
        public HotHand()
        {
            Name = "Hot Hand";/*Level*/WeaponType = "Slap"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Gain a speed boost when you hit an enemy player"),
new NegativeAttribute("-20% damage penalty"),
new DescriptionAttribute("This melee slap tells your opponent, and anyone watching the kill feed, that your hand just gave some lucky face the gift of slapping it stupid."),
});
            Melee = new Melee()
            {
                Damage = new Damage(52)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                }
            };
            //TODO but it's really two hits for half damage and one can miss.

            //FireRate = 0.8;
        }
    }

    public class PowerJack : ActiveMovementeMelee
    {
        public PowerJack()
        {
            Name = "Powerjack"; Level = 5; WeaponType = "Sledgehammer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("+15% faster move speed on wearer"),
new PositiveAttribute("+25 health restored on kill"),
new NegativeAttribute("20% damage vulnerability on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class GlovesOfRunningUrgently : ActiveMovementeMelee
    {
        public GlovesOfRunningUrgently()
        {
            Name = "Gloves of Running Urgently"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            new PositiveAttribute("+30% faster move speed on wearer"),
            new NegativeAttribute("This weapon holsters 50% slower"),
            new NegativeAttribute("Maximum health is drained while item is active"),
            });
           
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class EvictionNotice : ActiveMovementeMelee
    {
        public EvictionNotice()
        {
            Name = "Eviction Notice"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+40% faster firing speed"),
new PositiveAttribute("On Hit: Gain a speed boost"),
new PositiveAttribute("+15% faster move speed on wearer"),
new NegativeAttribute("-60% damage penalty"),
new NegativeAttribute("Maximum health is drained while item is active"),
});
            Melee = new Melee()
            {
                Damage = new Damage(26)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                }
            };
            FireRate = 0.48m;
        }
    }

    public class PainTrain : MeleeWeapon
    {
        public PainTrain()
        {
            Attributes.Clear();
            Name = "Pain Train"; Level = 5; WeaponType = "Makeshift Club"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+1 capture rate on wearer"),
new NegativeAttribute("10% bullet damage vulnerability on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class HalfZatoichi : Sword
    {
        public HalfZatoichi() // long range
        {
            Name = "half - zatoichi";
            Name = "Half-Zatoichi"; Level = 5; WeaponType = "Katana"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
new PositiveAttribute("Gain 50% of base health on kill"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Honorbound: Once drawn sheathing deals 50 damage to yourself unless it kills."),
new NeutralAttribute("Soldiers and Demos<br>Can duel with katanas<br>For a one-hit kill"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    },
            //    MaxRange = 72,
            //};
            ////FireRate = 0.8;

        }
    }

    public class Equalizer : MeleeWeapon
    {
        public Equalizer()
            :base(32.5m)
        {
            Attributes.Clear();
            Name = "Equalizer"; Level = 10; WeaponType = "Pickaxe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("Damage increases as the user becomes injured"),
new NegativeAttribute("-90% less healing from Medic sources"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(32.5)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class MarketGardener : MeleeWeapon
    {
        public MarketGardener()
        {
            Attributes.Clear();
            Name = "Market Gardener"; Level = 10; WeaponType = "Shovel"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Deals crits while the wielder is rocket jumping"),
new NegativeAttribute("20% slower firing speed"),
new NegativeAttribute("No random critical hits"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            FireRate = 0.96m;
        }
    }

    public class Axtinguisher : MeleeWeapon
    {
        public Axtinguisher()
            :base(43.3333333333333m)
        {
            Attributes.Clear();
            Name = "axtinguisher / postal pummeler";
            Name = "Axtinguisher"; Level = 10; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Mini-crits burning targets and extinguishes them."),
new PositiveAttribute("Damage increases based on remaining duration of afterburn"),
new PositiveAttribute("Killing blows on burning players grant a speed boost."),
new NegativeAttribute("-33% damage penalty"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("This weapon holsters 35% slower"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(43.3333333333333)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class Homewrecker : MeleeWeapon
    {
        public Homewrecker()
        {
            Attributes.Clear();
            Name = "homewrecker / maul";
            Name = "Homewrecker"; Level = 5; WeaponType = "Sledgehammer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+100% damage vs buildings"),
new PositiveAttribute("Damage removes Sappers"),
new NegativeAttribute("-25% damage vs players"),
}); 
            Melee = new Melee()
            {
                Damage = new Damage(48.75m)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                    BuildingModifier = 2.67m//because it's 2x65, not 2x48.75 TODO is that true for all buildings or just sappers? sappers get their own permanent damage base of 65 from all wrenches.
                    //TODO sapper effect as building
                }
            };
            //FireRate = 0.8;
        }
    }

    public class BackScratcher : MeleeWeapon
    {
        public BackScratcher()
            :base(81.25m)
        {
            Attributes.Clear();
            Name = "Back Scratcher"; Level = 10; WeaponType = "Garden Rake"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% damage bonus"),
new PositiveAttribute("+50% health from packs on wearer"),
new NegativeAttribute("-75% health from healers on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(81.25)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class SharpenedVolcanoFragment : MeleeWeapon
    {
        public SharpenedVolcanoFragment()
            :base(52)
        {
            Attributes.Clear();
            Name = "Sharpened Volcano Fragment"; Level = 10; WeaponType = "RIFT Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: target is engulfed in flames"),
new NegativeAttribute("-20% damage penalty"),
new DescriptionAttribute("Improves upon Mother Nature's original design for volcanos by increasing portability. Modern science is unable to explain exactly where the lava is coming from."),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(52)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;

            Effect = new AfterburnEffect(7.5m);
        }
    }

    public class ThirdDegree : MeleeWeapon
    {
        public ThirdDegree()
        {
            Attributes.Clear();
            Name = "Third Degree"; Level = 10; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("All players connected via Medigun beams are hit"),
new DescriptionAttribute("Being a boon to tree-fellers, backwoodsmen and atom-splitters the world over, this miraculous matter-hewing device burns each individual molecule as it cleaves it."),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;

            //Effect = BeamShareDamage
        }
    }

    public class NeonAnnihilator : MeleeWeapon
    {
        public NeonAnnihilator()
        {
            Attributes.Clear();
            Name = "Neon Annihilator"; Level = 1 - 100; WeaponType = "Sign"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Damage removes Sappers"),
new PositiveAttribute("100% critical hit vs wet players"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("-20% damage penalty vs players"),
});
            Melee = new Melee()
            {
                Damage = new Damage(52)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                }
                //TODO sapper effect as building (65?52? doesn't really matter, same result)
            };
            //FireRate = 0.8;
        }
    }

    public abstract class Sword : MeleeWeapon
    {
        public Sword(decimal baseDamage = 65)
        {
            Attributes.Clear(); Attributes.AddRange(new WeaponAttribute[] {
new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
});
            Name = "long melee range";

            Melee = new Melee()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                },
                MaxRange = 72,
            };
        }
    }
    public class Eyelander : Sword
    {
        public Eyelander()
        {
            Name = "eyelander / 9 - iron / HHHH";
            Name = "Eyelander"; Level = 5; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("-25 max health on wearer"),
new DescriptionAttribute("Gives increased speed and health with every head you take."),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    },
            //    MaxRange = 72,
            //};
            ////FireRate = 0.8;
        }
    }

    public class UllapoolCaber : MeleeWeapon
    {
        public UllapoolCaber()
        {
            Attributes.Clear();
            Name = "Ullapool Caber"; Level = 10; WeaponType = "Stick Bomb"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NegativeAttribute("20% slower firing speed"),
new NegativeAttribute("This weapon deploys 100% slower"),
new NegativeAttribute("No random critical hits"),
new DescriptionAttribute("High-yield Scottish face removal.<br/>A sober person would throw it...<br><br>The first hit will cause an explosion"),
});
            Melee = new Melee()
            {
                Damage = new Damage(55.25m)
                {
                    Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
                }
            };
            FireRate = 0.96m;

            //TODO AlternateModes = Explosion, Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
        }
    }

    public class ClaidheamhMor : Sword
    {
        public ClaidheamhMor()
        {
            Name = "Claidheamh Mòr"; Level = 5; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
//new NeutralAttribute("This Weapon has a large melee range and deploys and holsters slower"),
new PositiveAttribute("0.5 sec increase in charge duration"),
new PositiveAttribute("Melee kills refill 25% of your charge meter."),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("15% damage vulnerability on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    },
            //    MaxRange = 72,
            //};
            ////FireRate = 0.8;
        }
    }

    public class PersionPersuader : Sword
    {
        public PersionPersuader()
        {
            Name = "Persian Persuader"; Level = 10; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
new PositiveAttribute("Ammo boxes collected give Charge"),
new PositiveAttribute("Melee hits refill 20% of your charge meter."),
new NegativeAttribute("-80% max primary ammo on wearer"),
new NegativeAttribute("-80% max secondary ammo on wearer"),
new NegativeAttribute("No random critical hits"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    },
            //    MaxRange = 72,
            //};
            ////FireRate = 0.8;
        }
    }

    public class ScotsmansSkullcutter : Sword
    {
        public ScotsmansSkullcutter()
            :base(65*1.20m)
        {
            Name = "Scotsman's Skullcutter"; Level = 5; WeaponType = "Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("+20% damage bonus"),
new NegativeAttribute("15% slower move speed on wearer"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(78)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    },
            //    MaxRange = 72,
            //};
            ////FireRate = 0.8;
        }
    }

    public class KillingGlovesOfBoxing : MeleeWeapon
    {
        public KillingGlovesOfBoxing()
        {
            Attributes.Clear();
            Name = "Killing Gloves of Boxing"; Level = 7; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Kill: 5 seconds of 100% critical chance"),
new NegativeAttribute("-20% slower firing speed"),
});

            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            FireRate = 0.96m;
        }
    }

    public class WarriorsSpirit : MeleeWeapon
    {
        public WarriorsSpirit()
            :base(84.5m)
        {
            Attributes.Clear();
            Name = "Warrior's Spirit"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("+30% damage bonus"),
new PositiveAttribute("+50 health restored on kill"),
new NegativeAttribute("30% damage vulnerability on wearer"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(84.5)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class HolidayPunch : MeleeWeapon
    {
        public HolidayPunch()
        {
            Attributes.Clear();
            Name = "Holiday Punch"; Level = 10; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Critical hit forces victim to laugh"),
new PositiveAttribute("Always critical hit from behind"),
new PositiveAttribute("On Hit: Force enemies to laugh who are also wearing this item"),
new NegativeAttribute("Critical hits do no damage"),
new DescriptionAttribute("Be the life of the war party with these laugh-inducing punch-mittens."),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class FistsOfSteel : MeleeWeapon
    {
        public FistsOfSteel()
        {
            Attributes.Clear();
            Name = "Fists of Steel"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("-40% damage from ranged sources while active"),
new NegativeAttribute("+100% damage from melee sources while active"),
new NegativeAttribute("This weapon holsters 100% slower"),
new NegativeAttribute("-40% maximum overheal on wearer"),
new NegativeAttribute("-40% health from healers on wearer"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class Ubersaw : MeleeWeapon
    {
        public Ubersaw()
        {
            Attributes.Clear();
            Name = "Ubersaw"; Level = 10; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: 25% ÜberCharge added"),
new NegativeAttribute("20% slower firing speed"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            FireRate = 0.96m;
        }
    }

    public class Vitasaw : MeleeWeapon
    {
        public Vitasaw()
        {
            Attributes.Clear();
            Name = "vitasaw";
            Name = "Vita-Saw"; Level = 5; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Collect the organs of people you hit"),
new NegativeAttribute("-10 max health on wearer"),
new DescriptionAttribute("A percentage of your ÜberCharge level is retained on death, based on the number of organs harvested (15% per). Total ÜberCharge retained on spawn caps at 60%."),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

    public class Amputator : MeleeWeapon
    {
        public Amputator()
            :base(52)
        {
            Attributes.Clear();
            Name = "Amputator"; Level = 15; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("+3 health regenerated per second on wearer"),
new PositiveAttribute("Alt-Fire: Applies a healing effect to all nearby teammates"),
new NegativeAttribute("-20% damage penalty"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(52)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;
        }
    }

    public class SolemnVow : MeleeWeapon
    {
        public SolemnVow()
        {
            Attributes.Clear();
            Name = "Solemn Vow"; Level = 10; WeaponType = "Bust of Hippocrates"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Allows you to see enemy health"),
new NegativeAttribute("10% slower firing speed"),
new DescriptionAttribute("'Do no harm.'"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            FireRate = 0.88m;
        }
    }

    public class TribalmansShiv : MeleeWeapon
    {
        public TribalmansShiv()
            :base(32.5m)
        {
            Attributes.Clear();
            Name = "Tribalman's Shiv"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Hit: Bleed for 6 seconds"),
new NegativeAttribute("-50% damage penalty"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(32.5)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_MELEE,//23.5,
            //    }
            //};
            ////FireRate = 0.8;

            Effect = new BleedEffect(6m);
        }
    }

    public class Bushwaka : MeleeWeapon
    {
        public Bushwaka()
        {
            Attributes.Clear();
            Name = "bushwaka";
            Name = "Bushwacka"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("When weapon is active:"),
new PositiveAttribute("Crits whenever it would normally mini-crit"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("20% damage vulnerability on wearer"),
}); 
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
            CanMinicrit = false;

            Effect = new Effect()
            {
                Name = "Crits on minicrit",
            };
        }
    }

    public class Shahanshah : MeleeWeapon
    {
        public Shahanshah()
        {
            Attributes.Clear();
            Name = "Shahanshah"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% increase in damage when health <50% of max"),
new NegativeAttribute("-25% decrease in damage when health >50% of max"),
});
            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

}