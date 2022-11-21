using System.Collections.Generic;

namespace StatsData
{


    public abstract class AFlameThrower : Weapon
    {
        public AFlameThrower(decimal baseDamage = 6.5m*.5m)
        {
            Name = "flamethrower";

            Projectile = new Projectile(2450m)//TODO taken from items_game.txt weapon_newflame, but that also includes Drag value that changes everything.  What will the wiki think? equivalent for 0.6s lifespan would be ~641 Hu/s
            {
                //"Note: Flame damage is proportional to particle lifetime instead of distance from target. Unlike most weapons, Critical hits are also affected by the scaling."
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_6_FLAMETHROWER,
                    ZeroRangeRamp = 2,
                    LongRangeRamp = 1,
                    //BuildingModifier = 2.0m, // no, I think it's full exposure always for buildings.
                },

                //FIXME particles
                //Fragmentation = new Fragmentation()
                //{
                //    Fragments = 2,
                //    FragmentType = "particle",
                //},
                
                MaxRangeTime = GetMaxRangeWeaponNewFlame() / 2450m,// 385 Hu based on below calculation accounting for drag.  can't use 0.6 with 2450 Hu/s (that'd be 1470Hu range!)
                // was using 330... from ? I dont' even know. wiki text has 340 
                //TODO I maybe 350 in other spreadsheet? or I made it up

                Penetrating = true,
                Influenceable = false
            };

            FireRate = 0.075m;//recent wiki change? used to have 0.08m;

            //TODO crits multiply with ramp

            Effect = new AfterburnEffect(4, 10);//TODO flamethrower says 4-10 (increase by .4s per hit), others show 3-10 or other nonsense
                                                //TODO depends on exposure, so only minimum for min exposure? This is likely additive regardless of constant exposure, howerver.

        }

        protected decimal GetMaxRangeWeaponNewFlame()
        {
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
            // ASSUME drag is percent reduction in speed per game tick (0.015 s).
            // Apply that, the speed, and the lifetime as follows to get a max range of 385:
            decimal gameTick = 0.015m;
            decimal flame_drag = 8.5m;
            decimal flame_lifetime = 0.6m;
            decimal flame_speed = 2450m;
            decimal maxRange = MaxRangeWithDrag(flame_lifetime, gameTick, flame_speed, flame_drag);
            // ... but random offset of .1 to the lifetime (result 376 to 389), (the random spread direction of 2.8 degrees would shorten it negligibly, like 99.8%).
            return maxRange;
        }

        private decimal MaxRangeWithDrag(decimal travelTime, decimal dragIncrement, decimal startSpeed, decimal drag)
        {
            decimal answer = 0;
            decimal speed = startSpeed;
            int j = 0;
            for (decimal i = 0; i <= travelTime; i += dragIncrement)
            {
                speed = speed * (100.0m - drag) / 100.0m;
                if (speed <= 0) return answer;
                answer += speed * dragIncrement;
                if (answer < 0) return 0;
            }
            return answer;
        }
    }

    public abstract class AFullFlameThrower : AFlameThrower
    {
        public AFullFlameThrower(decimal baseDamage = 6.5m)
            : base(baseDamage)
        {
            Name = "flamethrower (max exposure/buildings)";

            //TODO crits multiply with ramp

            Effect = new AfterburnEffect(10);

        }

    }

    public class FlameThrower : AFlameThrower
    {
        public FlameThrower()
        {
            Name = "Flame Thrower";

            AlternateModes = new List<Weapon>
            {
                new CompressionBlast(),
                new FlameThrowerMaxExposure()
            };
        }
    }

    internal class FlameThrowerMaxExposure : AFullFlameThrower
    {
        public FlameThrowerMaxExposure()
            //TODO accurate? do buildings have time-ranged damage?  Should this be primary and half-damage is alternate like cold minigun? But Dragon's Fury works best as a ramp up that includes buildings
        {
            Name = "Flame Thrower (max exposure/buildings)";
        }
    }

    //"Cow Mangler: Deals critical hits when reflected by a crit-boosted flamethrower." - implies crit-boosted reflects crit-ify anything they reflect.
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

            FireRate = 0.75m;

            Effect = new Effect()
            {
                Name = "Deflect projectiles, Minicrit; push enemies; extinguish teammates"
            };
        }
    }

    public class BackBurner : AFlameThrower
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
                new CompressionBlast(),//TODO More expensive
                new FlameThrowerMaxExposure()
                //TODO ?FromBack, Effect: crit
            };
        }
    }

    public class Degreaser : AFlameThrower
    {
        //TODO wiki numbers all look like old flamethrower stats or something

        //-66% afterburn damage penalty
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
                new CompressionBlast(), //TODO more expensive
                new FlameThrowerMaxExposure()
            };

            decimal time = 4m;decimal time2 = 10m;//TODO using normal afterburn times - wiki says 5.4 s but degreaser page looks woefully outdated.
            Effect = new Effect()
            {
                Name = (time2 == time)
                ? $"Degreaser Afterburn({time} s)"
                : $"Degreaser Afterburn({time} - {time2} s)",
                Minimum = time,
                Maximum = time2,

                Damage = new Damage(4m * 0.34m), // Wiki says 1/tick (2/tick minicrit) - probably accurate, math works and ensures minicrit does more damage.
                DamageRate = 0.5m,
            };
        }
    }

    public class Phlogistinator : AFlameThrower
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

            // no compression blast
            AlternateModes = new List<Weapon>
            {
                new FlameThrowerMaxExposure()
                //TODO phlog crits for 10 seconds
            };
        }
    }

}