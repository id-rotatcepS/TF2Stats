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
            Name = "wrench";
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
            Name = "Gunslinger";

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
            Name = "knife";
        }
    }

    public class YourEternalReward : AKnife
    {
        public YourEternalReward()
        {
            Name = "your eternal reward";
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
            Name = "conniver's kunai";
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
            Name = "big earner";
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
            Name = "bat";
        }
    }

    public class Sandman : ABat
    {
        public Sandman()
        {
            Name = "sandman";
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
            Name = "candy cane";
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
            Name = "boston basher";
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
            Name = "sun-on-a-stick";
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
            Name = "fan o'war";
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
            Name = "atomizer";
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
            Name = "wrap assassin";
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
            Name = "active movement modifying melee";

            //FireRate = -1;
        }
    }

    public class EscapePlan : ActiveMovementeMelee
    {
        public EscapePlan()
        {
            Name = "escape plan";

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
            Name = "disciplinary action";

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
            Name = "hot hand";

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
            Name = "powerjack";

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
            Name = "gloves of running urgently";

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
            Name = "eviction notice";

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
            Name = "pain train";

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
            Name = "equalizer";

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
            Name = "market gardener";

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
            Name = "axtinguisher / postal pummeler";

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
            Name = "homewrecker / maul";

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
            Name = "back scratcher";

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
            Name = "sharpened volcano fragment";

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
            Name = "third degree";

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
            Name = "neon annihilator";

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
            Name = "ullapool caber";

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
            Name = "Claidheamh Mòr";

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
            Name = "persian persuader";

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
            Name = "scotsman's skullcutter";

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
            Name = "killing gloves of boxing";

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
            Name = "warrior's spirit";

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
            Name = "holiday punch";

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
            Name = "fists of steel";

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
            Name = "ubersaw";

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
            Name = "vitasaw";

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
            Name = "amputator";

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
            Name = "solemn vow";

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
            Name = "tribalman's shiv";

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
            Name = "bushwaka";

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
            Name = "shahanshah";

            //Melee = new Melee()
            //{
            //    Damage = new Damage(65)
            //};
            //FireRate = 0.8;
        }
    }

}