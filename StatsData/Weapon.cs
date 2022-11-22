using System.Collections.Generic;

namespace StatsData
{
    // Note, we are trying to use decimal most everywhere instead of double to get expected calculation results.
    // "If numbers must add up correctly or balance, use decimal. This includes any financial storage or calculations, scores, or other numbers that people might do by hand.
    //  If the exact value of numbers is not important, use double for speed.This includes graphics, physics or other physical sciences computations where there is already a number of significant digits."
   
    public class Weapon
    {
        public bool UseSimpleOverrides = true;

        public string Name { get; protected set; }
        public List<Weapon> AlternateModes { get; protected set; }

        public decimal FireRate { get; protected set; }
        public decimal ActivationTime { get; protected set; } = 0; // rev up, scope

        // Switch times holster/draw

        public Effect Effect { get; protected set; }

        public AOE AreaOfEffect { get; protected set; } // banner, medic target heal & target maintain
        public Melee Melee { get; protected set; } // melee; medic target hit & activate AOE (but does connect use hitbox or hitscan?)
        public Hitscan Hitscan { get; protected set; }
        public Projectile Projectile { get; protected set; }
        //public decimal Accuracy { get; }
        // public decimal MaxRange {get;} // projectile max lifetimeVsSpeed, AOE, melee,

        public Ammo Ammo { get; protected set; }

        public int Level { get; protected set; }
        public string WeaponType { get; protected set; }
        public List<WeaponAttribute> Attributes { get; protected set; }
        //https://wiki.teamfortress.com/wiki/Critical_hits#Special_cases
        public bool CanCrit { get; internal set; } = true;
        // for A few things like heal bolts or things that upgrade it to crits
        public bool CanMinicrit { get; internal set; } = true;
    }

    public class Damage
    {
        public const decimal WIKI_LONG_RANGE_RAMP = 0.528m;
        public const decimal NORMAL_LONG_RANGE_RAMP 
            //= .5;
            = WIKI_LONG_RANGE_RAMP;

        public const decimal NORMAL_HITSCAN_ZERO_RANGE_RAMP = 1.5m;
        public const decimal SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP = 1.75m;
        public const decimal NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP = 1.2m;
        //TODO custom value needs to get argued with people - alternatively: 1.25 with an offset, but same difference effectively.
        public const decimal NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP = 1.246m;// had in several places, but not quite high enough for liberty launcher math: 1.24444444444444m;//original simple number: 1.25m;
        public const decimal NORMAL_ENERGY_PROJECTILE_ZERO_RANGE_RAMP = 1.2m;

        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 0.0625 (30:1) per https://wiki.teamfortress.com/wiki/Talk:Shotgun#Bullet_spread_on_either_this_page_or_the_page_for_the_Scattergun_.28and_potentially_a_lot_of_other_weapon_pages.29_is_WRONG
        /// but the linked image (https://imgur.com/a/ZmWeqe9) says 0.0675 (28:1), same as reddit post!
        /// I think they accidentally conflated it with the firing rate.
        /// I have not done the legwork of extracting and decrypting the tf/scripts files they're talking about.
        /// </summary>
        public const decimal SPREAD_SHOTGUN_SCATTERGUN = 0.0675m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// </summary>
        public const decimal SPREAD_SMG_REVOLVER = 0.025m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// </summary>
        public const decimal SPREAD_SNIPER = 0;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// </summary>
        public const decimal SPREAD_PISTOL = 0.04m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// </summary>
        public const decimal SPREAD_MINIGUN = 0.08m;


        // based on source code leak from 2017 https://youtu.be/UFtZMIWt0WI?t=32
        // x (forward), y (right), z (up) relative to class's eyes.  Note each class has different view heights (z).
        // crouched: rockets, flares, cowmangler, bison: z is set to 8
        public static readonly decimal OFFSET_1_ROCKETS_FLARES =23.5m;//,12, -3
        //cowm bison, pomson; huntsman, crossbow, rescue ranger, grappling hoook
        public static readonly decimal OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE = 23.5m;//,8,-3
        public static readonly decimal OFFSET_3_GRENADE_STICKY_JARS = 23.5m;//,8, -6 // I had 16 for grenade & sticky but I dont' know why
        // technically this set is different values based on player's origin, not eyes
        public static readonly decimal OFFSET_4_BALLS_CLEAVER = 32;//,0, -15
        public static readonly decimal OFFSET_5_SYRINGES = 16;//,6, -8
        public static readonly decimal OFFSET_6_FLAMETHROWER = 0; //12,0
        public static readonly decimal OFFSET_7_ORIGINAL = 23.5m;//0, -3
        public static readonly decimal OFFSET_8_LUNCHBOX_TOSS = 0;//0, -8  (corrected to 0 x in description vs. 8 in video)
        // not known:
        public static readonly decimal OFFSET_DRAGONSFURY = OFFSET_6_FLAMETHROWER; // I had 0
        // not known:
        public static readonly decimal OFFSET_ORB = OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE;
        // gas passer I assume is a "jar"

        // made up to fit my theories:
        public static readonly decimal OFFSET_HITSCAN = 30;
        public static readonly decimal OFFSET_HITSCAN_MINIGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_SHOTGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_SCATTERGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_REVOLVER = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_PISTOL = OFFSET_HITSCAN;//22?
        public static readonly decimal OFFSET_HITSCAN_SMG = OFFSET_HITSCAN;

        public static readonly decimal OFFSET_HITSCAN_MELEE = OFFSET_HITSCAN;

        public static readonly decimal OFFSET_HITSCAN_SHORTCIRCUIT = OFFSET_HITSCAN;

        // don't really care:
        public static readonly decimal OFFSET_MEDIGUN = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_SHIELDBASH = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_STOMP = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_HITSCAN_SNIPER = OFFSET_HITSCAN;

        public Damage(decimal baseDamage)
        {
            Base = baseDamage;
        }
        public decimal Base { get;  } // building damage

        //public DamageType DamageType { get;  set; } // bullet/fire/etc.
        // push modifier
        // self push modifier

        public decimal ZeroRangeRamp { get;  set; } = 1.0m; // theoretical, not practical
        public decimal Offset { get;  set; } = 0;
        public decimal PointBlankRamp => ZeroRangeRamp;//FIXME
        public decimal LongRangeRamp { get;  set; } = 1.0m;

        public decimal BuildingModifier { get;  set; } = 1.0m;
    }

    public class Melee
    {
        // origin? but verified in src leak weapon_dodbasemelee.cpp:
        //Vector vecSrc	= pPlayer->Weapon_ShootPosition();
        //Vector vecEnd = vecSrc + vForward * 48;
        public static readonly decimal DEFAULT_RANGE = 48;

        public Damage Damage { get; set; }
        public decimal MaxRange { get; set; } = DEFAULT_RANGE;
    }

    public class Hitscan
    {
        // melee range

        public Fragmentation Fragmentation { get; set; }
        public Damage Damage { get; set; }
        public Recoil Recoil { get; set; }
        public bool Penetrating { get; set; } = false;

        public AOE Splash { get; set; }
    }

    public class Effect// bleed/afterburn/sap/milk/minicrit length max/min, type
    {
        public string Name { get; set; }
        public Damage Damage { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public decimal DamageRate { get; set; }
        //public DamageType DamageType { get;  set; }
    }

    //"The bleeding and afterburn mechanics do not crit, but will mini-crit if the attacking player is mini-crit boosted or if the target is under a mini-crit debuff."
    public class AfterburnEffect : Effect
    {
        public AfterburnEffect(decimal time)
            : this(time, time)
        {
        }

        public AfterburnEffect(decimal time, decimal time2)
        {
            Name = "Afterburn";
            //if (time2 == time)
            //    Name = $"Afterburn({time} s)";
            //else
            //    Name = $"Afterburn({time} - {time2} s)";
            Minimum = time;
            Maximum = time2;

            Damage = new Damage(4);
            DamageRate = 0.5m;
        }
    }

    //"The bleeding and afterburn mechanics do not crit, but will mini-crit if the attacking player is mini-crit boosted or if the target is under a mini-crit debuff."
    public class BleedEffect : Effect
    {
        public BleedEffect(decimal time)
        {
            //Name = $"Bleed({time} s)";
            Name = "Bleed";

            Minimum = time;
            Maximum = time;

            Damage = new Damage(4);
            DamageRate = 0.5m;
        }
    }
    /// <summary>
    ///   Effects that apply to buildings, not players.  Usually effects don't effect buildings.
    /// </summary>
    public class BuildingEffect : Effect
    {

    }

    public class AOE
    {
        public const decimal DEFAULT_SPLASH = 146;//Hu
        public const decimal DEFAULT_BANNER = 450;
        public AOE() : this(DEFAULT_SPLASH)
        {

        }
        public AOE(decimal radius)
        {
            Radius = radius;
        }
        public decimal Radius { get; }
    }
    public class BannerAOE : AOE
    {
        public BannerAOE() 
            : base(AOE.DEFAULT_BANNER) 
        { }
    }
    public class Projectile
    {
        public Projectile(decimal speed)
        {
            Speed = speed;
        }
        public Damage HitDamage { get; set; }
        public AOE Splash { get; set; }

        public decimal MaxRangeTime { get; set; } = 0;
        public decimal Spread { get; set; } = 0;

        public decimal Speed { get; }
        //size
        public bool Propelled { get; set; } = false; // rockets vs. arched // or PhysicsType to include flame puffs
        public decimal ArmTime { get; set; } = 0;
        public bool Penetrating { get; set; } = false;
        /// <summary>
        /// Whether airblast/orb affect it
        /// </summary>
        public bool Influenceable { get; set; } = true;
    }

    public class Fragmentation
    {
        public Fragmentation(decimal spread)
        {
            Spread = spread;
        }
        public int Fragments { get;  set; } = 1;
        public decimal Spread { get; }
        public string FragmentType { get;  set; } = "Pellet";
        // int centerFragments
        // spread pattern
    }
    public class Recoil
    {
        public static readonly decimal DEFAULT_RECOVERY = 1.25m;
        public Recoil(decimal spread)
        {
            Spread = spread;
        }
        public decimal Recovery { get; set; } = DEFAULT_RECOVERY;
        public decimal Spread { get;  }
    }

    public class Ammo // /Recharge
    {
        public int InitialLoaded { get; set; }
        public int Loaded { get; set; }
        public int Carried { get; set; }
        public decimal Reload { get; set; } // or recharge
        public decimal ReloadFirst { get; set; }
        public decimal ReloadAdditional { get; set; }
        public string ReloadUsing { get; set; } // or Recharge type "Time/Damage"
        public string AmmoType { get; set; }
        public string FireType { get; set; }
    }

    public abstract class WeaponAttribute
    {
        public string Text { get; protected set; }
    }
    public class NegativeAttribute : WeaponAttribute
    {

    }
    public class PositiveAttribute : WeaponAttribute
    {

    }
    public class NeutralAttribute : WeaponAttribute
    { 
    }
}