using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsData.GameFiles
{
    public class CtxToWeapon
    {
		//public static void PopulateWeapon(Weapon w)
  //      {
		//	object ctx;
		//	//printname
		//	//WeaponType secondary, melee
		//	//MeleeWeapon "1" (true) "0"
		//	//Range "4096"
		//	//TimeIdle "5.0"
		//	//TimeIdleEmpty "0.25"
		//	//ProjectileType projectile_bullet
		//	w.Hitscan.Damage = ctx.Damage;
		//	w.Hitscan.Fragmentation.Spread = ctx.Spread;
		//	w.Hitscan.Recoil.Spread = ctx.Spread;
		//	w.Hitscan.Fragmentation.Fragments = ctx.BulletsPerShot;
		//	w.FireRate = ctx.TimeFireDelay;
		//	w.Ammo.Reload = ctx.TimeReload;
		//	// number or string. (12, "-1")
		//	w.Ammo.Loaded = ctx.clip_size;
		//	// default_clip  (12, "1")

		//	// gasjar: 200 (and damage: 5??)
		//	w.Projectile.Splash.Radius = ctx.DamageRadius;
		//}
		/*
	// Attributes Base.
	"printname"		"#TF_Weapon_Pistol"
	"BuiltRightHanded"	"0"
	"weight"		"2"
	"WeaponType"		"secondary"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"
		
	// Attributes TF.
	"Damage"		"15"
	"Range"			"4096"
	"BulletsPerShot"	"1"
	"Spread"		"0.04"
	"TimeFireDelay"		"0.15"
	"TimeIdle"		"5.0"
	"TimeIdleEmpty"		"0.25"
	"TimeReload"		"0.5"
	"ProjectileType"	"projectile_bullet"
	"BrassModel"		"models/weapons/shells/shell_pistol.mdl"
	"UseRapidFireCrits"	"1"
	"TracerEffect"		"bullet_pistol_tracer01"

	// Ammo & Clip.
	"primary_ammo"		"TF_AMMO_SECONDARY"
	"secondary_ammo"	"None"
	clip_size		12
	default_clip		12
         */
		/*
	// Attributes Base.
	"printname"			"#TF_Weapon_Bat"
	"BuiltRightHanded"		"0"
	"MeleeWeapon"			"1"
	"weight"			"1"
	"WeaponType"		"melee"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"
	
	// Attributes TF.
	"Damage"			"35"
	"TimeFireDelay"			"0.5"
	"TimeIdle"			"5.0"

	// Ammo & Clip
	"primary_ammo"			"TF_AMMO_GRENADES1"
	"secondary_ammo"		"None"
		 
		 */
		/*
	// Attributes Base.
	"printname"			"#TF_Weapon_GasJar"
	"BuiltRightHanded"		"0"
	"MeleeWeapon"			"0"
	"weight"			"5"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"
	
	// Attributes TF.
	"Damage"			"5"
	"DamageRadius"			"200"
	"TimeFireDelay"			"0.8"
	"TimeIdle"			"5.0"
	"HasTeamSkins_Viewmodel"			"1"
	"ProjectileType"		"projectile_jar_gas"

	// Ammo & Clip
	"primary_ammo"			"TF_AMMO_GRENADES1"
	"secondary_ammo"		"None"
	clip_size			"-1"
	default_clip			"1"

		 */
		/*
	// Attributes Base.
	"printname"		"#TF_Weapon_FlameThrower"
	"BuiltRightHanded"	"0"
	"weight"		"3"
	"WeaponType"		"primary"
	"ITEM_FLAG_NOITEMPICKUP" 	"1"
	
	// Attributes TF.
	"Damage"		"170"	// per second
	"Range"			"0"
	"BulletsPerShot"	"1"
	"Spread"		"0.0"
	"TimeFireDelay"	"0.04"
	"UseRapidFireCrits"	"1"
	"HasTeamSkins_Viewmodel"			"1"


	// Ammo & Clip.
	"primary_ammo"		"TF_AMMO_PRIMARY"
	"secondary_ammo"	"None"
	clip_size		-1
		 
		 */
	}
}
