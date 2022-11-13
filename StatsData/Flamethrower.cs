using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class AFlamethrower : Weapon
    {
        public AFlamethrower()
        {
            Name = "flamethrower";

            Projectile = new Projectile(1)//TODO FIXME flame speed?
            {
                HitDamage = new Damage(6.5m)
                {
                    Offset = Damage.OFFSET_6_FLAMETHROWER,
                    ZeroRangeRamp = 2,
                    LongRangeRamp = 1,
                    BuildingModifier = 2.0m,
                },

                /*
                 * from tf/scripts/items/items_game.txt "weapon_newflame"
                 * 				
				"flame_gravity"							"0"
				"flame_drag"							"8.5"
				"flame_up_speed"						"50"
				"flame_speed"							"2450"
				"flame_spread_degree"					"2.8"
				"flame_lifetime"						"0.6"
				"flame_random_life_time_offset"			"0.1"
                 */

                //FIXME particles
                //Fragmentation = new Fragmentation()
                //{
                //    Fragments = 2,
                //    FragmentType = "particle",
                //},
                MaxRangeTime = 330,//TODO I maybe 350 in other spreadsheet? or I made it up//TODO time vs. speed, not distance.

                Penetrating = true,
                Influenceable = false
            };
            FireRate = 0.08m;

            Effect = new AfterburnEffect(0, 10);//TODO times? - depends on exposure, so is that an alt mode?

        }
    }

    public class Flamethrower : AFlamethrower
    {
        public Flamethrower()
        {
            Name = "flamethrower";

            AlternateModes = new List<Weapon>
            {
                new CompressionBlast()
            };
        }
    }

    public class CompressionBlast : Weapon
    {
        public CompressionBlast()
        {
            Name = "compression blast";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(0)
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = -1;
        }
    }

    public class BackBurner : AFlamethrower
    {
        public BackBurner()
        {
            Name = "backburner";

            //Projectile = new Projectile(1)//TODO FIXME flame speed?
            //{
            //    HitDamage = new Damage(6.5)
            //    {
            //        ZeroRangeRamp = 2,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 0.08;
            AlternateModes = new List<Weapon>
            {
                new CompressionBlast()
            };
        }
    }

    public class Degreaser : AFlamethrower
    {
        public Degreaser()
        {
            Name = "degreaser";

            //Projectile = new Projectile(1)//TODO FIXME flame speed?
            //{
            //    HitDamage = new Damage(6.5)
            //    {
            //        ZeroRangeRamp = 2,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 0.08;
            AlternateModes = new List<Weapon>
            {
                new CompressionBlast()
            };
        }
    }

    public class Phlogistinator : AFlamethrower
    {
        public Phlogistinator()
        {
            Name = "phlogistinator";

            //Projectile = new Projectile(1)//TODO FIXME flame speed?
            //{
            //    HitDamage = new Damage(6.5)
            //    {
            //        ZeroRangeRamp = 2,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 0.08;

            AlternateModes = null; // no compression blast
        }
    }

}