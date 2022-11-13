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
            AreaOfEffect = new AOE(540);
            Effect = new Effect()
            {
                Name = "Übercharge",
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
            Name = "Medi Gun Crit Heals";
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


            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
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


            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
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
            Name = "quickfix crit heal";

            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
            AreaOfEffect = new AOE(540);
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


            Melee = new Melee()
            {
                //Damage = new Damage(0)
                //{
                //    Offset = 23.5,
                //},
                MaxRange = 450
            };
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