using System.Collections.Generic;

namespace StatsData
{

    /// <summary>
    /// from tf_weapon_flamethrower.ctx:
    /// 	 "Damage"		"170"	// per second
    /// 	 "Range"			"0"
    /// 	 "BulletsPerShot"	"1"
    /// 	 "Spread"		"0.0"
    /// 	 "TimeFireDelay"	"0.04"
    /// 	 "UseRapidFireCrits"	"1"
    /// from items_game.txt:
    /// 		"weapon_flamethrower"
    /// 						"can_deal_damage"			"1"
    /// 						"can_reflect_projectiles"	"1"
    /// 						"can_extinguish"			"1"
    /// 						"can_deal_posthumous_damage"	"1"
    /// 						"can_deal_critical_damage"	"1"
    /// 						"is_flamethrower" "1"
    ///		"weapon_baseflamethrower"
    /// 				"extinguish restores health"			"20"
    ///		"weapon_newflame"
    /// 				"flame_gravity"							"0"
    /// 				"flame_drag"							"8.5"
    /// 				"flame_up_speed"						"50"
    /// 				"flame_speed"							"2450"
    /// 				"flame_spread_degree"					"2.8"
    /// 				"flame_lifetime"						"0.6"
    /// 				"flame_random_life_time_offset"			"0.1"
    /// </summary>
    public abstract class AFlameThrower : Weapon
    {
        #region weapon_newflame constants
        public const decimal flame_gravity = 0m;
        // I am guessing this is a percent reduction in speed per game tick.  Result makes sense.
        public const decimal flame_drag = 8.5m;
        public const decimal flame_up_speed = 50m;
        public const decimal flame_speed = 2450m;
        public const decimal flame_spread_degree = 2.8m;
        public const decimal flame_lifetime = 0.6m;
        public const decimal flame_random_life_time_offset = 0.1m;
        #endregion weapon_newflame constants

        // items_game 170DPS * .04(TimeFireDelay) = 6.8.  170 * .075(Wiki FireRate) = 12.75 (full exposure & close range - half as min: 6.375 vs. 6.5)

        // 0.075 from wiki.  used to have 0.08.  tf_weapon_flamethrower has half that: 0.04 - maybe that reflects flame particle generation, not damage time.
        public const decimal flame_damage_period = 0.075m;
        // 170 dps per tf_weapon_flamethrower.ctx
        public const decimal flame_max_damage = 170m * flame_damage_period;//12.75
        public const decimal flame_full_exposure_damage = flame_max_damage * .5m;//6.375
        //public const decimal flame_base_damage = 6.5m;// what was 6.5 based on? lots of conjecture based on the wiki, I think.

        public AFlameThrower(decimal baseDamage = flame_full_exposure_damage * .5m)
        {
            Name = "flamethrower";

            Projectile = new Projectile(flame_speed)//TODO 2450 from items_game.txt, but that also has Drag that changes meaning.  What will the wiki think? equivalent for 0.6s lifespan would be ~641 Hu/s
            {
                //"Note: Flame damage is proportional to particle lifetime instead of distance from target. Unlike most weapons, Critical hits are also affected by the scaling."
                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_6_FLAMETHROWER,
                    ZeroRangeRamp = 2,
                    LongRangeRamp = 1,
                    //BuildingModifier = 2.0m, // no, I think it's full exposure always for buildings.

                    CritIncludesRamp = true, // (e.g. zero range damage with crits is 6x)
                },

                //FIXME particles
                //Fragmentation = new Fragmentation()
                //{
                //    Fragments = 2,
                //    FragmentType = "particle",
                //},
                
                MaxRangeTime = GetMaxRangeWeaponNewFlame() / flame_speed,// 385 Hu based on below calculation accounting for drag.
                // was using 330... from ? I dont' even know. wiki text has 340 

                Penetrating = true,
                Influenceable = false
            };

            // fire rate as shown in wiki, currently matches flame_damage_period which may not be appropriate.
            FireRate = 0.075m;//recent wiki change? used to have 0.08m;

            Effect = new AfterburnEffect(4, 10);//TODO flamethrower says 4-10 (increase by .4s per hit), others show 3-10 or other nonsense
                                                //TODO depends on exposure, so only minimum for min exposure? This is likely additive regardless of constant exposure, however.

            Ammo = new Ammo(200)
            {
                AmmoUseInterval = 0.105m,
            };

        }

        protected decimal GetMaxRangeWeaponNewFlame()
        {
            // ASSUME drag is PERCENT reduction in speed per game tick (0.015 s).
            // Apply that, the speed, and the lifetime as follows to get a max range of 385.
            // not using flame_up_speed or flame_gravity, just care about horizontal distance
            // not using flame_spread_degree, currently. the random spread direction of 2.8 degrees would shorten it negligibly, like 99.8%
            // not including flame_random_life_time_offset, currently. random offset of .1 to the lifetime results in 376 to 389 (vs 385).
            // (FYI, life time of 5s still only gets range of 395HU)
            decimal gameTick = 0.015m;
            decimal maxRange = MaxRangeWithDrag(flame_lifetime, gameTick, flame_speed, flame_drag);
            return maxRange;
        }

        private decimal MaxRangeWithDrag(decimal travelTime, decimal dragIncrement, decimal startSpeed, decimal drag)
        {
            decimal answer = 0;
            decimal speed = startSpeed;
            for (decimal i = 0; i <= travelTime; i += dragIncrement)
            {
                speed = speed * (100.0m - drag) / 100.0m;
                if (speed <= 0)
                    return answer;
                answer += speed * dragIncrement;
                if (answer < 0)
                    return 0;
            }
            return answer;
        }
    }

    public abstract class AFullFlameThrower : AFlameThrower
    {
        public AFullFlameThrower(decimal baseDamage = flame_full_exposure_damage)
            : base(baseDamage)
        {
            Name = "flamethrower (max exposure/buildings)";

            Effects.Clear();
            Effect = new AfterburnEffect(10);

        }

    }

    public class FlameThrower : AFlameThrower
    {
        public FlameThrower()
        {
            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Dual-use: Flames or Airblast"),
            new PositiveAttribute("Extinguishing teammates restores 20 health"),
            new PositiveAttribute("On Hit: Afterburn for 3-10 seconds by exposure"),
            new NegativeAttribute("No effect underwater"),
            new NeutralAttribute("Afterburn: 8 dps, reduces Medi Gun healing and resist shield effects"),
            new NeutralAttribute("Does not destroy stickybombs"),
            new DescriptionAttribute("Flames: Steady exposure grants up to +100% damage<br/>0.9 second max exposure<br/>Alt-Fire: -20 ammo to release a blast of air that pushes enemies, redirects projectiles, and extinguishes teammates<br/>Deflected projectiles (except stickybombs) deal mini-crits to enemies"),
            });
            
            Name = "Flame Thrower";
            Name = "Flame Thrower"; Level = 1; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n7 fire damage (81 dps) 200%-0% by range\n Penetrating flames limited to 64% range\n 200 carried"),
new PositiveAttribute("Extinguishing teammates restores 20 health"),
new DescriptionAttribute("Afterburn reduces Medi Gun healing and resist shield effects.<br>Alt-Fire: Release a blast of air that pushes enemies and projectiles and extinguish teammates that are on fire."),
});
            //            Name = "Rainblower"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            //new PositiveAttribute("On Equip: Visit Pyroland"),
            //new PositiveAttribute("Extinguishing teammates restores 20 health"),
            //new NegativeAttribute("Only visible in Pyroland"),
            //new DescriptionAttribute("Your friends (enemies) will squeal with delight (be consumed with fire) when you cover them in sparkly rainbows (all-consuming fire). (Equips Pyrovision.)"),
            //}); Name = "Nostromo Napalmer"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
            //new PositiveAttribute("Extinguishing teammates restores 20 health"),
            //}); 
            AlternateModes = new List<Weapon>
            {
                new FlameThrowerMaxExposure(),
            };
            SeparateModes = new List<Weapon>
            { 
                new CompressionBlast(),
            };
        }
    }

    internal class FlameThrowerMaxExposure : AFullFlameThrower
    {
        public FlameThrowerMaxExposure()
            //TODO accurate? do buildings have time-ranged damage?
            //TODO Should this be primary and half-damage is alternate like cold minigun? But Dragon's Fury works best as a ramp up that includes buildings
        {
            Name = "(max exposure/buildings)";
        }
    }

    //"Cow Mangler: Deals critical hits when reflected by a crit-boosted flamethrower." - implies crit-boosted reflects crit-ify anything they reflect.
    public class CompressionBlast : Weapon
    {
        public CompressionBlast(int ammoUsed = 20)
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

            CanCrit = false;
            CanMinicrit = false;

            FireRate = 0.75m;

            Effect = new Effect()
            {
                Name = "Deflect projectiles, Minicrit; push enemies; extinguish teammates"
            };

            Ammo = new Ammo(200)
            {
                AmmoUsed = ammoUsed,
            };
        }
    }

    public class BackBurner : AFlameThrower
    {
        public BackBurner()
        {
            Name = "backburner";
            Name = "Backburner"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("100% critical hits from behind"),
new PositiveAttribute("Extinguishing teammates restores 20 health"),
new NegativeAttribute("+150% airblast cost"),
}); 
            AlternateModes = new List<Weapon>
            {
                new FlameThrowerMaxExposure(),
                //TODO ?FromBack, Effect: crit
            };
            SeparateModes = new List<Weapon>
            {
                new CompressionBlast(30),
            };
        }
    }

    public class Degreaser : AFlameThrower
    {
        //-66% afterburn damage penalty
        public Degreaser()
        {
            Name = "degreaser";
            Name = "Degreaser"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("This weapon deploys 60% faster"),
new PositiveAttribute("This weapon holsters 30% faster"),
new PositiveAttribute("Extinguishing teammates restores 20 health"),
new NegativeAttribute("-66% afterburn damage penalty"),
new NegativeAttribute("+25% airblast cost"),
}); 
            AlternateModes = new List<Weapon>
            {
                new DegreaserMaxExposure(),
            };
            SeparateModes = new List<Weapon>
            {
                new CompressionBlast(25),
            };

            Effects.Clear();
            Effect = NewDegreaserAfterburn();
        }

        internal static Effect NewDegreaserAfterburn(decimal time = 4m)
        {
            decimal time2 = 10m;// using normal afterburn times - wiki says 5.4 s but degreaser page looks woefully outdated.
            return new Effect()
            {
                //Name = (time2 == time)
                //? $"Degreaser Afterburn({time} s)"
                //: $"Degreaser Afterburn({time} - {time2} s)",
                Name = "Degreaser Afterburn",
                Minimum = time,
                Maximum = time2,

                Damage = new Damage(4m * 0.34m), // Wiki says 1/tick (2/tick minicrit) - probably accurate, math works and ensures minicrit does more damage.
                DamageRate = 0.5m,
            };
        }
    }
    internal class DegreaserMaxExposure : AFullFlameThrower
    {
        public DegreaserMaxExposure()
        //TODO (same as flameethrower) accurate? do buildings have time-ranged damage?
        //TODO (same as flameethrower) Should this be primary and half-damage is alternate like cold minigun? But Dragon's Fury works best as a ramp up that includes buildings
        {
            Name = "(max exposure/buildings)";

            Effects.Clear();
            Effect = Degreaser.NewDegreaserAfterburn(10m);
        }
    }



    public class Phlogistinator : AFlameThrower
    {
        public Phlogistinator()
        {
            Name = "phlogistinator";
            Name = "Phlogistinator"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Build 'Mmmph' by dealing damage."),
new PositiveAttribute("Alt-Fire on full 'Mmmph': Taunt to gain crit for several seconds."),
new PositiveAttribute("Invulnerable while 'Mmmph' taunting."),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("No airblast"),
new DescriptionAttribute("Being a revolutionary appliance capable of awakening the fire element phlogiston that exists in all combustible creatures, which is to say, all of them."),
}); 
            // no compression blast
            AlternateModes = new List<Weapon>
            {
                new FlameThrowerMaxExposure(),
                //TODO phlog crits for 10 seconds
            };
        }
    }

}