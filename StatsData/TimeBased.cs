using System.Collections.Generic;

namespace StatsData
{
  
    /*
     * Shortcircuit primary is ranged but has a short max
     * Dragon's fury similar
     * 
     * Flamethrower is time-based damage with a short max
     * balls and crossbow are time-based, I think, with no max, and balls just get activate bonus at long range
     * 
     * Shield bash could be either, but logically it's time-based (charge reduction based, showing same info probably)
     * 
     * Shortcircuit alt is time-limited but constant damage
     * others?
     */

    // Short Circuit primary probably doesn't belong in this file, but it's the only example of this exact calculation that is equivalent of the time-based
    public class ShortCircuit : Weapon
    {
        //TODO wiki went with base + falloff which doesn't really make any sense and they also didn't show mini-crit range
        //TODO minicrit more testing... math & game files max range 256 say I should be able to get 12 if I'm far enough away. 13 means I was more like 170 away... that's like an additional melee distance which is hard to believe.
        /// <summary>
        /// myobs: pb	lr	pmc	lmc	pbc	lrc
        /// myobs: 10	9	14	13	10	9
        /// wiki: 10 point blank, 15 mc point blank
        /// 
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Range: 256
        /// tf_weapon_mechanical_arm
        /// </summary>
        public ShortCircuit()
        {
            // arc-thrower
            Name = "Short Circuit"; Level = 5; WeaponType = "Robot Arm"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Alt-Fire: Launches a projectile-consuming energy ball. Costs 65 metal."),
new PositiveAttribute("No reload necessary"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Per Shot: -5 ammo"),
new NegativeAttribute("Uses metal for ammo"),
});
            Notes += "7 damage but point blank ~150% ramp up for 10 damage, max range is still 125% ramp up for 9 damage";
            ActivationTime = 0;
            Melee = new Melee()
            {
                Damage = new Damage(7)//9.26m)//10) // 9.26 @wd  // tf_weapon_mechanical_arm Damage=7, TimeFireDelay=0.15, Spread=0.04
                {
                    Offset = Damage.OFFSET_HITSCAN_SHORTCIRCUIT,
                    //ZeroRangeRamp = 1.12m,
                    //LongRangeRamp = 1,//TODO not accurate, there is some small variation
                    // if we use damage=7 and do a typical ramp up of like 1.5 and max "long range" of 256, does it match results?? YES - well 10.5 point blank with 1.5 ramp up - as close as other weapons sometimes are.
                    ZeroRangeRamp = Damage.PISTOL_HITSCAN_ZERO_RANGE_RAMP,//replaces pistol, also rounding needs to result in 10, not 10.5=11.
                    //LongRangeRamp = 1.0m,//realistically, Damage.NORMAL_LONG_RANGE_RAMP, but not relevant since max range doesn't even get to Mid range.

                    //BuildingModifier = 0.07m// -93%
                    BuildingModifier = 0.20m// typical energy weapon modifier works with base 7 damage to round to 1 damage vs. building same as wiki
                },
                MaxRange = 256 // from tf_weapon_mechanical_arm.ctx
            };
            FireRate = 0.15m;

            //"The Short Circuit is unable to deal critical damage, but can deal mini-crits under respective buffs or enemy debuffs."
            CanCrit = false;

            AlternateModes = new List<Weapon> {
            };
            SeparateModes = new List<Weapon>
            {
                new ShortCircuitAlt()
            };

            Ammo = new Ammo(200)
            {
                AmmoType = "Metal",
                AmmoUsed = 5,
            };
        }
    }

    /// <summary>
    /// myobs: 15	15	20	20	15	15
    /// wiki: 15 point blank, 20 point blank mc
    /// </summary>
    public class ShortCircuitAlt : Weapon
    {
        //TODO building modifier Test - wiki talks about it but no number. not sure where I got it. 
        public ShortCircuitAlt()
        {
            Name = "electrical airblast";

            Projectile = new Projectile(400)//wd (guessed)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_ORB,//23.5,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,

                    BuildingModifier = 0.20m//TODO test for actual value( is it really 3?) had 0.10m but based on what? Wiki just says "insignificant" and doesn't supply a number.
                },
                Penetrating = true,
                Propelled = true,
                MaxRangeTime = 1024 / 400,
                //TODO Doesn't have a splash, has a GIANT projectile size (should modify accuracy), visually looks small + area.
            };
            FireRate = 0.5m;

            //"The Short Circuit is unable to deal critical damage, but can deal mini-crits under respective buffs or enemy debuffs."
            CanCrit = false;

            Effect = new Effect()
            {
                Name = "Vaporize Projectile"
            };

            Ammo = new Ammo(200)
            {
                AmmoType = "Metal",
                AmmoUsed = 65,
            };
        }
    }

    /// <summary>
    /// myobs: 30	24	40	34	75	75
    /// wiki: pb: 25 (75 burn/build); long: (N/A)/25 (75 burn/build) (M/R); pb mc: 34 (102 burn); long mc: 34 (102 burn); pb crit: 75 (225 burn)
    /// </summary>
    public class ADragonsFury : Weapon
    {
        /* https://www.teamfortress.tv/44242/where-can-i-find-weapon-script-txt-files
         * tf_weapon_rocketlauncher_fireball.txt - Flamethrower
WeaponData
{
	// Attributes Base.
	"printname"		"#TF_Weapon_RocketLauncher"
	"BuiltRightHanded"	"0"
	"weight"		"3"
	"WeaponType"		"primary"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"

	// Primary Attributes.
	"Damage"		"90"
	"Range"			"0"
	"BulletsPerShot"	"1"
	"Spread"		"0.0"
	"PunchAngle"		"1.5"
	"TimeFireDelay"		"0.8"
	"TimeIdle"		"0.8"
	"TimeIdleEmpty"		"0.8"
	"TimeReloadStart"	"0.1"
	"TimeReload"		"0.83"
	"primary_ammo"		"TF_AMMO_PRIMARY"
	"ProjectileType"	"tf_projectile_balloffire"
	"HasTeamSkins_Viewmodel"	"1"

	// Secondary Attributes.
	"secondary_ammo"	"None"

	// Buckets.
	"bucket"		"0"
	"bucket_position"	"0"	

	"ExplosionEffect"		"ExplosionCore_wall"
	"ExplosionPlayerEffect"		"ExplosionCore_MidAir"
	"ExplosionWaterEffect"		"ExplosionCore_MidAir_underwater"

	"ExplosionSound"	"BaseExplosionEffect.Sound"

	// Muzzleflash
	"MuzzleFlashParticleEffect" "muzzle_dragons_fury"

	// Animation.
	//"viewmodel"     -viewmodel is now defined in _items_main.txt
	//"playermodel"   -playermodel is now defined in _items_main.txt
	"anim_prefix"		"gl"

	// Sounds.
	// Max of 16 per category (ie. max 16 "single_shot" sounds).
	SoundData
	{
		"single_shot"	"Weapon_RPG.Single"
		"double_shot"	"Weapon_FlameThrower.AirBurstAttack"
//		"reload"		"Weapon_RPG.WorldReload"
		"burst"			"Weapon_RPG.SingleCrit"	
	}

	// Weapon Sprite data is loaded by the Client DLL.
	TextureData
	{
		"weapon"
		{
				"file"		"sprites/bucket_rl"
				"x"		"0"
				"y"		"0"
				"width"		"200"
				"height"		"128"
		}
		"weapon_s"
		{	
				"file"		"sprites/bucket_rl"
				"x"		"0"
				"y"		"0"
				"width"		"200"
				"height"		"128"
		}
		"ammo"
		{
				"file"		"sprites/a_icons1"
				"x"		"55"
				"y"		"60"
				"width"		"73"
				"height"	"15"
		}
		"crosshair"
		{
				"file"	"vgui/replay/thumbnails/circle"
				"x"		"0"
				"y"		"0"
				"width"		"64"
				"height"	"64"
		}
		"autoaim"
		{
				"file"		"sprites/crosshairs"
				"x"		"0"
				"y"		"48"
				"width"		"24"
				"height"	"24"
		}
	}
}
        */
        //TODO wiki is wrong in that 90% of 75 is not 69.
        //TODO possible my obs is wrong in that I got 24 far, not the 23 on wiki.
        //TODO wiki long range says 90%, I said 92%, really both are wrong, it's probably 52.8%, but limited by Max Range.
        //((526-512)/512)percent of long range(0.02734375). 1-(percent * (1-.528)) = .98709 (98.7%) equivalent long range ramp.
        // results in a value that would round to 25. obs is 24, wiki says 23.  Maybe 526 is not accurate.
        public ADragonsFury(decimal baseDamage = 25)
        {
            Name = "fireball launcher";

            Notes += "TODO I could use max range 549 to get observed 24 (72 burning) at max range vs. 52.8% long range\n" +
                "max range 592 gets wiki's 23 (71 burning) at max range vs. 52.8% long range; but wiki claims 526 max\n";

            Projectile = new Projectile(3000)
            {
                // calculations show the following:
                // to match wiki (23 far, 69 far on fire): 600 or 592 max range, using either 52.8% or 50% long range
                // to match obs (24 far, 72 far on fire): 548 max range, 50% long range.  547 works, too.
                // (to use wiki's range of 526, not even 0% long range works for wiki or observed (except it works for not-on-fire as match of observed))
                // turns out to get obs numbers with long of 0 to 52.8 has to be max range of 530-562
                // turns out to get wiki numbers with long of 0 to 52.8 has to be max range of 550-606

                HitDamage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_DRAGONSFURY,
                    ZeroRangeRamp = 1.2m,
                    LongRangeRamp = 
                    //Damage.NORMAL_LONG_RANGE_RAMP,
                    // most compatible number: 50%
                    .5m,
                    //0.92m, // Not really, probably standard, but small max range gives us this percent of base.
                    BuildingModifier = 3.0m
                },
                Penetrating = true,
                Propelled = true,//Debatable with the high speed and short path, but "the Dragon's Fury's projectile is considered a modified rocket"
                MaxRangeTime =
                // smallest value to match observed with 50%
                547m/3000m,
                // 600m/3000m,//=0.2s would be convenient.
                //592m / 3000m, // 592 is minimum (600 works) maxrange to get at 23 (wiki), 69 burning (wiki), with 52.8%
                //578m / 3000m, // 578 is minimum maxrange to get at 23 (wiki), results in 71 burning (69 on wiki), with 52.8%
                //549m / 3000m, // 549 is minimum maxrange to get at 24 (my obs), 72 burning, with 52.8%
                //526.0m / 3000.0m, // My calc: 12.5 (524.5) above medium range converts .528 lr to equiv .92 max range
            };
            FireRate = 0.8m;

            Effect = new AfterburnEffect(3)
            {
                Name = "Afterburn(additive); Pyro Afterburn (1s)"
            };

            Ammo = new Ammo(40)
            {
            };
        }
    }

    public class DragonsFury : ADragonsFury
    {
        public DragonsFury()
        {
            Name = "Dragon's Fury"; Level = 1 - 100; WeaponType = "Flame Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NeutralAttribute("Uses a shared pressure tank for Primary Fire and Alt-Fire.<br/><br/>Primary Fire: Launches a fast moving projectile that briefly ignites enemies<br/><br/>Alt-Fire: Release a blast of air that pushes enemies and projectiles, and extinguishes teammates that are on fire."),
new PositiveAttribute("Extinguishing teammates restores 20 health"),
new PositiveAttribute("Deals 300% damage to burning players"),
new PositiveAttribute("+50% repressurization rate on hit"),
new NegativeAttribute("-50% repressurization rate on Alt-Fire"),
new DescriptionAttribute("This powerful, single-shot flamethrower rewards consecutive hits with faster reloads and bonus damage."),
});
            Notes += "obs falloff 24 (calc/wiki 23); minicrit obs/wiki close 40 (calc 41); wiki mc burning 100-121 (calc 101-122) \n" +
                "Interestingly it's 'based on' a 90dmg rocket...which is how much it gets on burning point blank hits";

            AlternateModes = new List<Weapon>
            {
                new DragonsFuryBurning(),
                new DragonsFuryRampage(),
                new DragonsFuryPostHit(),
            };
            SeparateModes = new List<Weapon>
            {
                new DragonsFuryCompressionBlast(),
            };
        }
    }

    internal class DragonsFuryCompressionBlast : CompressionBlast
    {
        public DragonsFuryCompressionBlast()
        {
            FireRate = 1.6m;

            Ammo = new Ammo(40)
            {
                AmmoUsed = 5,
            };
        }
    }

    internal class DragonsFuryPostHit : ADragonsFury
    {
        public DragonsFuryPostHit()
        {
            Name = "(after hit)";

            FireRate = 0.53m;
        }
    }
    internal class DragonsFuryRampage : ADragonsFury
    {
        public DragonsFuryRampage()
            :base(75)
        {
            Name = "rampage (consecutive hits)";

            //TODO smaller projectile
            Projectile.HitDamage.BuildingModifier = 1.0m;

            FireRate = 0.53m;
        }
    }

    internal class DragonsFuryBurning : ADragonsFury
    {
        // burning target triples (not crits) and actually involves a smaller projectile
        public DragonsFuryBurning()
            :base(75)
        {
            Name = "(burning)";

            //TODO smaller projectile

            Projectile.HitDamage.BuildingModifier = 1.0m;
        }
    }


    /// <summary>
    /// myobs: 38	75	52	101	115	225
    /// wiki: 38	75	51	101	113-225
    /// note on 51: inverse damage means lower number takes priority. try with a different shape target? but it's a projectile so shape shouldn't matter!
    /// </summary>
    public class CrusadersCrossbow : ABolt
    {
        //TODO I had 1.6 FireRate. Wiki lists attack interval as 0.24 s, 1.5 reload (1.75 s with reload) 
        public CrusadersCrossbow()
        {
            Name = "Crusader's Crossbow"; Level = 15; WeaponType = "Crossbow"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NegativeAttribute("No headshots"),
new NegativeAttribute("-75% max primary ammo on wearer"),
new DescriptionAttribute("Fires special bolts that heal teammates and deals damage<br>based on distance traveled<br>This weapon will reload automatically when not active"),
});
            Notes += "TODO Wiki has nonsense crit & minicrit values of 113 & 51 on the low end when I've observed 115 & 52 (matches calc)\n";
            Projectile = new Projectile(2400)
            {
                // damages buildings the same amount based on hang time.
                HitDamage = new Damage(38.4m)//38.4 functional min hang time.  theoretical min: 37.5=75/2
                //tf_weapon_crossbow Damage=75 Range=0 TimeFireDelay=0.23 TimeReload=1.5
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

                // "far" is actually min hang time
                //observed minicrit far: 38; observed crit far: 115
                //observed = 38 far
                // 115/3 =   38.33333333333333 far
                // 52/1.35 = 38.51851851851852 far  (/38 = 0.7407407407407407)

                // 38.4
                // 38.4 * 3 = 115.2
                // 38.4*1.35 = 51.84

                // 75/2 = 37.5, but maybe 0 time not possible for minimum offset, similar to huntsman minimum draw strength


            };
            // TODO: (where's this number from?) single shot reload - usually is functionally its rate, but this one is different.
            FireRate = .24m;// 1.6m;//TODO would rather use file value 0.23

            AlternateModes = new List<Weapon>()
            {
                new CrusadersCrossbowMaxHang(),
            };
            SeparateModes = new List<Weapon>
            {
                new CrusadersCrossbowHeal(),
            };

            Ammo = new Ammo(1, 38)
            {
                Reload = 1.5m,
            };

        }
    }
    public class CrusadersCrossbowMaxHang : ABolt
    {
        public CrusadersCrossbowMaxHang()
        {
            Name = "(max time)";

            Projectile = new Projectile(2400)
            {
                // damages buildings the same amount based on hang time.
                HitDamage = new Damage(75)
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

                // "close" is actually max hang time
                //observed minicrit close: 101; observed crit close: 225;
                // observed= 75 close
                // 225/3   = 75 close
                // 101/1.35= 74.81481481481481 close (75*1.35=101.25..101)
            };
            FireRate = .24m;// 1.6m;

            Ammo = new Ammo(1, 38)
            {
                Reload = 1.5m,
            };
        }
    }

    public class CrusadersCrossbowHeal : ABolt
    {
        public CrusadersCrossbowHeal()
        {
            Name = "(heal)";

            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(-75) //TODO is this just theoretical or can we heal this small an amount?
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = .24m;// 1.6m;

            CanCrit = false;
            CanMinicrit = false;

            AlternateModes = new List<Weapon>()
            {
                new CrusadersCrossbowHealMaxHang()
            };

            Ammo = new Ammo(1, 38)
            {
                Reload = 1.5m,
            };
        }
    }
    public class CrusadersCrossbowHealMaxHang : ABolt
    {
        public CrusadersCrossbowHealMaxHang()
        {
            Name = "(heal, max time)";

            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(-150)
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = .24m;// 1.6m;

            CanCrit = false;
            CanMinicrit = false;

            Ammo = new Ammo(1, 38)
            {
                Reload = 1.5m,
            };
        }
    }

    //public class CrusadersCrossbow : Bolts
    //{
    //    public CrusadersCrossbow()
    //    {
    //        Name = "Crusader's Crossbow";

    //        Projectile = new Projectile(2400)
    //        {
    //            HitDamage = new Damage(50)
    //            {
    //                //Offset = ,
    //                ZeroRangeRamp = 0.75,
    //                LongRangeRamp = 1.5,
    //            },

    //        };
    //        FireRate = 1.6;

    //        AlternateModes = new List<Weapon>()
    //        {
    //            new CrusadersCrossbowHeal()
    //        };
    //    }
    //}
    //public class CrusadersCrossbowHeal : Bolts
    //{
    //    public CrusadersCrossbowHeal()
    //    {
    //        Name = "crossbow (heal)";

    //        Projectile = new Projectile(2400)
    //        {
    //            HitDamage = new Damage(-100)
    //            {
    //                //Offset = ,
    //                ZeroRangeRamp = 0.75,
    //                LongRangeRamp = 1.5,
    //            },

    //        };
    //        FireRate = 1.6;
    //    }
    //}


    public abstract class ShieldBash : Weapon
    {
        public ShieldBash()
        {
            Name = "charge shields";

            Projectile = new Projectile(750)
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_SHIELDBASH,//32,
                    ZeroRangeRamp = 0.314m,
                    LongRangeRamp = 1,
                },
                MaxRangeTime = 1125.0m / 750.0m,
            };
            ChargeTime = Projectile.MaxRangeTime;
            FireRate = 12;
            //"unable to deal critical damage, but can deal mini-crits under respective buffs or enemy debuffs."
            CanCrit = false;
        }
    }

    /// <summary>
    /// 16	50	21	68	16	50
    /// wiki: pb 50; long: n/a; .. long mc: 68; pb c: n/a
    /// </summary>
    public class CharginTarge : ShieldBash
    {
        public CharginTarge()
        {
            Name = "Chargin' Targe"; Level = 1 - 99; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% fire damage resistance on wearer"),
new PositiveAttribute("+30% explosive damage resistance on wearer"),
new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a critical melee strike after impacting an enemy at distance."),
});
            Projectile = new Projectile(750)//wd
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_SHIELDBASH,//32,
                    ZeroRangeRamp = 0.314m,
                    LongRangeRamp = 1,
                },
                MaxRangeTime = 1125.0m / 750.0m,

            };
            ChargeTime = Projectile.MaxRangeTime;
            FireRate = 12;
        }
    }

    /// <summary>
    /// myobs: 27	85	36	115	27	85
    /// wiki: pb 85; long: n/a; .. long mc: 115; pb c: n/a
    /// </summary>
    public class SplendidScreen : ShieldBash
    {
        public SplendidScreen()
        {
            Name = "Splendid Screen"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+20% fire damage resistance on wearer"),
new PositiveAttribute("+20% explosive damage resistance on wearer"),
new PositiveAttribute("+70% increase in charge impact damage"),
new PositiveAttribute("+50% increase in charge recharge rate"),
new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a critical melee strike after impacting an enemy."),
}); 
            Projectile = new Projectile(750)//wd
            {
                HitDamage = new Damage(85)
                {
                    Offset = Damage.OFFSET_SHIELDBASH,//32,
                    ZeroRangeRamp = 0.314m,
                    LongRangeRamp = 1,
                },
                MaxRangeTime = 1125.0m / 750.0m,
            };
            ChargeTime = Projectile.MaxRangeTime;
            FireRate = 8;
        }
    }

    /// <summary>
    /// 16	50	21	68	16	50
    /// wiki: pb 50; long: n/a; .. long mc: 68; pb c: n/a
    /// </summary>
    public class TideTurner : ShieldBash
    {
        public TideTurner()
        {
            Name = "Tide Turner"; Level = 1 - 100; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+15% fire damage resistance on wearer"),
new PositiveAttribute("+15% explosive damage resistance on wearer"),
new PositiveAttribute("Full turning control while charging"),
new PositiveAttribute("Melee kills refill 75% of your charge meter."),
new NegativeAttribute("Taking damage while shield charging reduces remaining charging time"),
new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a mini-crit melee strike after impacting an enemy at distance."),
}); 
            Projectile = new Projectile(750)//wd
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_SHIELDBASH,//32,
                    ZeroRangeRamp = 0.314m,
                    LongRangeRamp = 1,
                },
                MaxRangeTime = 1125.0m / 750.0m,
            };
            ChargeTime = Projectile.MaxRangeTime;
            FireRate = 12;
        }
    }

    public abstract class ThrowableWeapon : Weapon
    {
        public ThrowableWeapon()
        {
            Name = "throwable weapons";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 0.25m;
        }
    }

    /// <summary>
    /// myobs: 15	23	20	30	45	68
    /// wiki: 15	23	20	30	45	; long crit: 68
    /// </summary>
    public class SandmanBall : ThrowableWeapon
    {
        public SandmanBall()
        {
            Name = "Ball";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1.5m, // extra long range (time-based long range)
                },

            };
            //TODO ChargeTime = 
            //FireRate = 0.25;
        }
    }

    /// <summary>
    /// myobs: 54	54	;	78	;	67
    /// wiki: pb: 15; pb mc: 20; pb crit: 45
    /// note on 15: +"4-24";     weapon demonstration: 23, 33, 29; self: 4, 12, 8
    /// note on 45: +"4-24";     weapon demonstration: 52, moonshot 54
    /// </summary>
    public class WrapAssassinBauble : ThrowableWeapon
    {
        public WrapAssassinBauble()
        {
            Name = "Bauble";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                Splash = new AOE(AOE.DEFAULT_SPLASH * 0.33m)
            };
            //TODO ChargeTime = 
            //FireRate = 0.25;
        }
    }

    /// <summary>
    /// 54	54	73	73	154	154
    /// wiki: 50	50	68	68	150
    /// note on first value: All of these are likely what I got minus one bleed (jarate for minicrit point blank probably rounds both... like bauble's splash damage, but this is just one bleed)... Check the bleed interval and if it adds up correctly.
    /// </summary>
    public class FlyingGuillotine : ThrowableWeapon
    {
        public FlyingGuillotine()
        {
            Name = "Flying Guillotine";/*Level*/WeaponType = "Cleaver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Throw at your enemies to make them bleed! Long distance hits reduce recharge time"),
new NegativeAttribute("No random critical hits"),
});
            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(50) // Note Weird Values: tf_weapon_cleaver MeleeWeapon=1 WeaponType=item1 Damage=5 DamageRadius=200 TimeFireDelay=0.8
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            //TODO ChargeTime = 
            //FireRate = 0.25;

            Effect = new BleedEffect(5);
        }
    }

    public abstract class ActiveJumpAssist : Weapon
    {
        public ActiveJumpAssist()
        {
            Name = "active jump assist";
            Projectile = new Projectile(0)//TODO min speed?
            {
                HitDamage = new Damage(0)//TODO Value?
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = -1;
        }
    }

    public class ThermalThruster : ActiveJumpAssist
    {
        /*
         * https://www.teamfortress.tv/44242/where-can-i-find-weapon-script-txt-files
         * (this doesn't make a lot of sense?)
tf_weapon_rocketpack.txt - Jetpack

	WeaponData
{
	// Attributes Base.
	"printname"			"#TF_Weapon_RocketPack"
	"BuiltRightHanded"		"0"
	"MeleeWeapon"			"1"
	"weight"				"1"
	"WeaponType"			"melee"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"

	// Attributes TF.
	"Damage"				"35"
	"TimeFireDelay"			"0.5"
	"TimeIdle"				"5.0"

	// Ammo & Clip
	"primary_ammo"			"TF_AMMO_GRENADES1"
	"secondary_ammo"		"None"
	clip_size				"-1"
	default_clip			"2"

	// Buckets.	
	"bucket"				"1"
	"bucket_position"		"0"

	// Model & Animation
	"viewmodel"			"models/weapons/c_models/c_rocketpack/c_rocketpack.mdl"
	"playermodel"			"models/weapons/c_models/c_rocketpack/c_rocketpack.mdl"

	// Sounds for the weapon. There is a max of 16 sounds per category (i.e. max 16 "single_shot" sounds)
	SoundData
	{
		"melee_miss"		"Weapon_FireAxe.Miss"
		"melee_hit"			"Weapon_FireAxe.HitFlesh"
		"melee_hit_world"	"Weapon_FireAxe.HitWorld"
		"burst"				"Weapon_FireAxe.MissCrit"
	}

	// Weapon Sprite data is loaded by the Client DLL.
	TextureData
	{
		"weapon"
		{
				"file"		"sprites/bucket_fireaxe"
				"x"		"0"
				"y"		"0"
				"width"		"200"
				"height"		"128"
		}
		"weapon_s"
		{	
				"file"		"sprites/bucket_fireaxe"
				"x"		"0"
				"y"		"0"
				"width"		"200"
				"height"		"128"
		}

		"ammo"
		{
				"file"		"sprites/a_icons1"
				"x"		"55"
				"y"		"60"
				"width"		"73"
				"height"	"15"
		}

		"crosshair"
		{
				"file"	"vgui/replay/thumbnails/sniper"
				"x"		""
				"y"		"0"
				"width"		"64"
				"height"	"64"
		}	

		"autoaim"
		{
				"file"		"sprites/crosshairs"
				"x"		"0"
				"y"		"48"
				"width"		"24"
				"height"	"24"
		}
	}
}
        */

        public ThermalThruster()
        {
            Name = "Thermal Thruster"; Level = 1 - 100; WeaponType = "Rocket Pack"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Push enemies back when you land (force and radius based on velocity)"),
new DescriptionAttribute("Death from above! Fires a short-duration blast that launches the Pyro in the direction they are aiming. Deal 3x falling damage to anyone you land on!"),
}); 
            Projectile = new Projectile(651)
            {
                HitDamage = new Damage(67) // tf_weapon_rocketpack Damage=35 (like bat) WeaponType=melee MeleeWeapon=1 TimeFireDelay=0.5 clip_size=-1 default_clip=2
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

                //TODO knockback splash isn't damage splash Splash = new AOE(AOE.DEFAULT_RADIUS * ?)
            };
            //TODO ChargeTime = 
            FireRate = 3.0m;
            AlternateModes = new List<Weapon>()
            {
                new ThermalThrusterTerminalVelocity()
            };
        }
    }

    public class ThermalThrusterTerminalVelocity : ActiveJumpAssist
    {
        public ThermalThrusterTerminalVelocity()
        {
            Name = "terminal velocity";

            Projectile = new Projectile(3500)
            {
                HitDamage = new Damage(316)
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            //TODO ChargeTime = 
            FireRate = 15.0m;
        }
    }

    public class Mantreads : ActiveJumpAssist
    {
        public Mantreads()
        {
            Name = "Mantreads"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("-75% reduction in push force taken from damage"),
new PositiveAttribute("Deals 3x falling damage to the player you land on"),
new PositiveAttribute("-75% reduction in airblast vulnerability"),
new PositiveAttribute("200% increased air control when blast jumping."),
});
            Projectile = new Projectile(651)
            {
                HitDamage = new Damage(75)
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 3.0m;

            AlternateModes = new List<Weapon>()
            {
                new MantreadsTerminalVelocity()
            };
        }
    }

    public class MantreadsTerminalVelocity : ActiveJumpAssist
    {
        public MantreadsTerminalVelocity()
        {
            Name = "terminal velocity";

            Projectile = new Projectile(3500)
            {
                HitDamage = new Damage(360)
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 15.0m;

        }
    }

    
}