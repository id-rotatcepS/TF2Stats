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
                MaxRange = AMediGun.MEDIGUN_MAX_RANGE
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
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Range: 450
        /// tf_weapon_medigun
        /// </summary>
        public static decimal MEDIGUN_MAX_RANGE = 450; // from tf_weapon_medigun.ctx
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
                MaxRange = MEDIGUN_MAX_RANGE
            };
            Effect = new Effect() {
                Name = "Target Healing",
                Damage = new Damage(-3),  // Note (matches healing per second): tf_weapon_medigun Damage=24 also TimeFireDelay=0.5... other unused values.
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
            Attributes.AddRange(new WeaponAttribute[] { 
            new PositiveAttribute("Does not require ammo"),
            new PositiveAttribute("100% healing at any range"),
            new PositiveAttribute("Match move speed of faster heal target"),
            new PositiveAttribute("Overheal target to 150%"),
            new NegativeAttribute("Lock-on within 88% range only"),
            new NeutralAttribute("Up to +200% healing rate out of combat"),
            new DescriptionAttribute("Healing charges Über up to 2.5% per second<br/>Random critical hit chance includes damage by heal targets<br/>?Random critical hit chance includes healing done the last 20 seconds?<br/>Alt-Fire: Activate ÜberCharge for 8 seconds of damage invulnerability and no capture rate"),
            });
            
            Name = "Medi Gun"; Level = 1; WeaponType = "Medi Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n3 healing (24 healing per second) \n Beam limited to 105% range"),
});
            //Melee = new Melee()
            //{
            //    //Damage = new Damage(0)
            //    //{
            //    //    Offset = 23.5,
            //    //},
            //    MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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
                MaxRange = MEDIGUN_MAX_RANGE
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