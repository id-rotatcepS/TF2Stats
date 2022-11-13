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

    // S.C. primary probably doesn't belong in this file, but it's the only example of this exact calculation that is equivalent of the time-based
    public class ShortCircuit : Weapon
    {
        //TODO wiki went with base + falloff which doesn't really make any sense and they also didn't show mini-crit range
        /// <summary>
        /// myobs: pb	lr	pmc	lmc	pbc	lrc
        /// myobs: 10	9	14	13	10	9
        /// wiki: 10 point blank, 15 mc point blank
        /// </summary>
        public ShortCircuit()
        {
            Name = "Short Circuit"; // arc-thrower
            ActivationTime = 0;
            Melee = new Melee()
            {
                Damage = new Damage(9.26m)//10) // 9.26 @wd
                {
                    Offset = Damage.OFFSET_HITSCAN_SHORTCIRCUIT,
                    ZeroRangeRamp = 1.12m,
                    LongRangeRamp = 1,//TODO not accurate, there is some small variation

                    BuildingModifier = 0.07m// -93%
                },
                MaxRange = 275
            };
            FireRate = 0.15m;

            CanCrit = false;

            AlternateModes = new List<Weapon> {
                new ShortCircuitAlt()
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
            Name = "alt short circuit(orb blast)";

            Projectile = new Projectile(400)//wd (guessed)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_ORB,//23.5,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,

                    BuildingModifier = 0.10m
                },
                Penetrating = true,
                Propelled = true,
                MaxRangeTime = 1024 / 400,
                //TODO Doesn't have a splash, has a GIANT projectile size (should modify accuracy), visually looks small + area.
            };
            FireRate = 0.5m;

            CanCrit = false;

            Effect = new Effect()
            {
                Name = "Vaporize Projectile"//TODO does it have a movement impairment, too?
            };
        }
    }

    /// <summary>
    /// myobs: 30	24	40	34	75	75
    /// wiki: pb: 25 (75 burn/build); long: (N/A)/25 (75 burn/build) (M/R); pb mc: 34 (102 burn); long mc: 34 (102 burn); pb crit: 75 (225 burn)
    /// </summary>
    public class DragonsFury : Weapon
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
        //TODO wiki long range says 90%, I said 92%, really both are wrong, it's probably 52.8%, but limited by Max Range.
        //((526-512)/512)percent of long range(0.02734375). 1-(percent * (1-.528)) = .98709 (98.7%) equivalent long range ramp.
        // results in a value that would round to 25. obs is 24, wiki says 23.  Maybe 526 is not accurate.
        public DragonsFury()
        {
            Name = "Dragon's Fury"; //"fireball launcher";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(25)
                {
                    Offset = Damage.OFFSET_DRAGONSFURY,
                    ZeroRangeRamp = 1.2m,
                    LongRangeRamp = 0.92m, // Not really, probably standard, but small max range gives us this percent of base.
                    BuildingModifier = 3.0m
                },
                Penetrating = true,
                Propelled = true,//Debatable with the high speed and short path, but "the Dragon's Fury's projectile is considered a modified rocket"
                MaxRangeTime = 526.0m / 3000.0m, // My calc: 12.5 (524.5) above medium range converts .528 lr to equiv .92 max range
            };
            FireRate = 0.8m;

            Effect = new AfterburnEffect(2, 10);//TODO times? has a larger minimum, additive I think?

            AlternateModes = new List<Weapon>
            {
                // TODO burning target triples (not crits) and actually involves a smaller projectile
                new CompressionBlast()//TODO special variation due to cost
            };
        }
    }

    /// <summary>
    /// myobs: 38	75	52	101	115	225
    /// wiki: 38	75	51	101	113-225
    /// note on 51: inverse damage means lower number takes priority. try with a different shape target? but it's a projectile so shape shouldn't matter!
    /// </summary>
    public class CrusadersCrossbow : ABolt
    {
        //TODO I had 1.6. Wiki lists attack interval as 0.24 s, 1.5 reload (1.75 s with reload) 
        //TODO Wiki has nonsense crit & minicrit values of 113 & 51 on the low end when I've observed 115 & 52 (matches calc)
        public CrusadersCrossbow()
        {
            Name = "Crusader's Crossbow";

            Projectile = new Projectile(2400)
            {
                // damages buildings the same amount based on hang time.
                HitDamage = new Damage(38.4m)//38.4 functional min hang time.  theoretical min: 37.5=75/2
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
            FireRate = .24m;// 1.6m;

            AlternateModes = new List<Weapon>()
            {
                new CrusadersCrossbowMaxHang(),
                new CrusadersCrossbowHeal(),
                new CrusadersCrossbowHealMaxHang()
            };
        }
    }
    public class CrusadersCrossbowMaxHang : ABolt
    {
        public CrusadersCrossbowMaxHang()
        {
            Name = "crossbow (max time)";

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
            FireRate = 1.6m;
        }
    }

    public class CrusadersCrossbowHeal : ABolt
    {
        public CrusadersCrossbowHeal()
        {
            Name = "crossbow (heal)";

            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(-75) //TODO is this just theoretical or can we heal this small an amount?
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 1.6m;
        }
    }
    public class CrusadersCrossbowHealMaxHang : CrusadersCrossbowHeal
    {
        public CrusadersCrossbowHealMaxHang()
        {
            Name = "crossbow (heal, max time)";

            Projectile = new Projectile(2400)
            {
                HitDamage = new Damage(-150)
                {
                    //Offset = ,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

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
            FireRate = 12;

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
            Name = "Chargin' Targe";

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
            Name = "Splendid Screen";

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
            Name = "Tide Turner";

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
            Name = "Ball(sandman)";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(15)
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1.5m, // extra long range
                },

            };
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
            Name = "Bauble(wrap assassin)";

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
            Name = "Flying Guillotine";

            Projectile = new Projectile(3000)
            {
                HitDamage = new Damage(50)
                {
                    Offset = Damage.OFFSET_4_BALLS_CLEAVER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            //FireRate = 0.25;

            Effect = new BleedEffect(5);// TODO short time?
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
            Name = "Thermal Thruster";

            Projectile = new Projectile(651)
            {
                HitDamage = new Damage(67)
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

                //TODO knockback splash isn't damage splash Splash = new AOE(AOE.DEFAULT_RADIUS * ?)
            };
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
            Name = "thermal thruster terminal velocity";

            Projectile = new Projectile(3500)
            {
                HitDamage = new Damage(316)
                {
                    Offset = Damage.OFFSET_STOMP,//32,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },

            };
            FireRate = 15.0m;
        }
    }

    public class Mantreads : ActiveJumpAssist
    {
        public Mantreads()
        {
            Name = "Mantreads";

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
            Name = "mantreads terminal velocity";

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