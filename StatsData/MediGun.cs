using System.Collections.Generic;

namespace StatsData
{
    public class Uber : Weapon
    {
        public Uber()
        {
            Name = "Medi Gun Alt-fire";
            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            CanCrit = false;
            CanMinicrit = false;
            AreaOfEffect = new AOE(540);
            Effect = new Effect()
            {
                Name = "Übercharge",
                Minimum = 8.0m,//TODO really, there's a minimum when sharing uber between targets
                Maximum = 8.0m,
                Damage = new Damage(-3),
                DamageRate = 0.125m,
            };
        }
    }
    public class MediGunCritHeals : AMediGun
    {
        public MediGunCritHeals()
        {
            Name = "Crit Heals";
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Target Healing Out of Combat",
                Damage = new Damage(-9),
                DamageRate = 0.125m,
            };
        }
    }
    public abstract class AMediGun : Weapon
    {
        /// <summary>
        /// Medigun hits people within a long range, 
        /// invoking an AOE healing effect between medic and that target (represented by beam) until they leave the radius.
        /// </summary>
        public AMediGun() {
            Name = "Medi Gun";
            CanCrit = false;
            CanMinicrit = false;
            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            Effect = new Effect() {
                Name = "Target Healing",
                Damage = new Damage(-3),
                DamageRate = 0.125m,
            };
            AreaOfEffect = new AOE(540);

            // XMediGun:
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(-3)
            //    {
            //        //Offset = ,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //};
            //FireRate = 0.125;

        }
    }
    public class MediGun : AMediGun
    {
        /// <summary>
        /// Medigun hits people within a long range, 
        /// invoking an AOE healing effect between medic and that target (represented by beam) until they leave the radius.
        /// </summary>
        public MediGun()
        {
            Name = "Medi Gun";
            Name = "Medi Gun"; Level = 1; WeaponType = "Medi Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n3 healing (24 healing per second) \n Beam limited to 105% range"),
});
            //Melee = new Melee()
            //{
            //    //Damage = new Damage(0)
            //    //{
            //    //    Offset = 23.5,
            //    //},
            //    MaxRange = 450
            //};
            //Effect = new Effect()
            //{
            //    Name = "Target Healing",
            //    Damage = new Damage(-3),
            //    DamageRate = 0.125,
            //};
            //AreaOfEffect = new AOE(540);
            AlternateModes = new List<Weapon>() {
                // requires a superclass to prevent loop
                new MediGunCritHeals(),
                new Uber(),
                //TODO UberCritHeals
            };

            //// XMediGun:
            ////Hitscan = new Hitscan()
            ////{
            ////    Damage = new Damage(-3)
            ////    {
            ////        //Offset = ,
            ////        ZeroRangeRamp = 1,
            ////        LongRangeRamp = 1,
            ////    },
            ////};
            ////FireRate = 0.125;

        }
    }

    public class xMediGun : Weapon
    {
        public xMediGun()
        {
            Name = "medi gun";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(-3)
                {
                    Offset = 23.5m,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 0.125m;
        }
    }

    public class Kritzkrieg : AMediGun
    {
        public Kritzkrieg()
        {
            Name = "kritzkrieg";
            Name = "Kritzkrieg"; Level = 8; WeaponType = "Medi Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("ÜberCharge grants 100% critical chance"),
new PositiveAttribute("+25% ÜberCharge rate"),
}); 

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Target Healing",
                Damage = new Damage(-3),
                DamageRate = 0.125m,
            };
            AreaOfEffect = new AOE(540);


            AlternateModes = new List<Weapon>() {
                new MediGunCritHeals(),
                //TODO new KritzUber()
            };

        }
    }

    public class QuickFix : AMediGun
    {
        public QuickFix()
        {
            Name = "quick - fix";
            Name = "Quick-Fix"; Level = 8; WeaponType = "Medi Gun Prototype"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("ÜberCharge increases healing to 300% and grants immunity to movement-impairing effects"),
new PositiveAttribute("+40% heal rate"),
new PositiveAttribute("+10% ÜberCharge rate"),
new NegativeAttribute("50% max overheal"),
new DescriptionAttribute("Mirror the blast jumps and shield charges of patients."),
}); 

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Target Healing",
                Damage = new Damage(-3),
                DamageRate = 1.0m/(33.6m/3.0m),
            };
            AreaOfEffect = new AOE(540);

            AlternateModes = new List<Weapon>() {
                new QuickFixCritHeals(),
                new QuickFixUber(),
                new QuickFixUberCritHeals(),
            };
        }
    }
    public class QuickFixCritHeals : MediGunCritHeals
    {
        public QuickFixCritHeals()
        {
            Name = "crit heal";

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            AreaOfEffect = new AOE(540);
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Target Healing Out of Combat",
                Damage = new Damage(-9),
                DamageRate =  1.0m / (33.6m / 3.0m),
            };

        }
    }
    public class QuickFixUber : AMediGun
    {
        public QuickFixUber()
        {
            Name = "quickfix uber";


            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Quickfix Uber Target Healing",
                Damage = new Damage(-9),
                DamageRate = 1.0m / (33.6m / 3.0m),
            };
            AreaOfEffect = new AOE(540);

        }
    }
    public class QuickFixUberCritHeals : MediGunCritHeals
    {
        public QuickFixUberCritHeals()
        {
            Name = "quickfix uber crit heals";

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            AreaOfEffect = new AOE(540);
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Quickfix Uber Target Healing Out of Combat",
                Damage = new Damage(-27),
                DamageRate = 1.0m / (33.6m / 3.0m),
            };

        }
    }

    public class Vaccinator : AMediGun
    {
        public Vaccinator()
        {
            Name = "vaccinator";
            Name = "Vaccinator"; Level = 8; WeaponType = "Vaccinator"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+67% Übercharge rate"),
new PositiveAttribute("Press your reload key to cycle through resist types."),
new PositiveAttribute("While healing, provides you and your target with a constant 10% resistance to the selected damage type."),
new NegativeAttribute("-33% ÜberCharge rate on Overhealed patients"),
new NegativeAttribute("-66% Overheal build rate."),
new DescriptionAttribute("Übercharge provides a 2.5 second resistance bubble that blocks 75% base damage and 100% crit damage of the selected type to the Medic and Patient."),
});

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            Effects.Clear();
            Effect = new Effect()
            {
                Name = "Target Healing",
                Damage = new Damage(-3),
                DamageRate = 0.125m,
            };
            AreaOfEffect = new AOE(540);

            AlternateModes = new List<Weapon>() {
                new MediGunCritHeals(),
                //TODO new VaccinatorUber()
            };
        }
    }
}