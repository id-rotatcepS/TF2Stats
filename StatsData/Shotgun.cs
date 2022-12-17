using System.Collections.Generic;

namespace StatsData
{
    /// <summary>
    /// 9-90	3-22	12-121	8-49	18-180	18-144
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public abstract class AShotgun : Weapon
    {
        //TODO wiki spread 30:1, but calc is 28:1 (28.148repeating)
        //TODO wiki all pellets far 30, but calc is 32, need evidence
        public AShotgun(decimal baseDamage = 60, int fragments = 10, decimal spread = Damage.SPREAD_SHOTGUN_SCATTERGUN, decimal zeroRange = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP)
        {
            Name = "Shotgun";
            Notes = "wiki 0.51 reload more, but derivatives all use 0.50\n" +
                "Wiki Long range all pellets is as if 50%, not 52.8%??\n" +
                "Spread based on 0.0675 - wiki shotgun discussion proof shows that yet mistakenly still uses 0.0625\n";
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
                    ZeroRangeRamp = zeroRange ,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP
                },
                Fragmentation = new Fragmentation(spread)
                {
                    Fragments = fragments,
                    FragmentType = "pellet",
                }
            };
            FireRate = 0.625m;

            Ammo = new Ammo(6, 32)
            {
                ReloadFirst = 1.0m, // subclasses - TODO undocumented difference from stocks?
                ReloadAdditional = 0.5m,
                //TODO wiki says 0.51 for stocks, but that's vs. 0.5, just rounding diff.
            };
        }
    }

    // Heavy or Engineer
    public class Shotgun : AShotgun
    {
        public Shotgun()
        {
            Name = "Shotgun";
            Name = "Shotgun"; Level = 1; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n60 damage (96 dps) 150%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.5 sec (first in 1 sec), 32 carried"),
});
            Ammo.ReloadFirst = 0.87m; // Heavy & Engineer

            //TODO lazy way to show these differences.
            AlternateModes = new List<Weapon>
            {
                new PyroShotgun(),
                new SoldierShotgun(),
            };
        }
    }
    public class PyroShotgun : AShotgun
    {
        public PyroShotgun()
        {
            Name = "Shotgun (pyro)";

            Ammo.ReloadFirst = 1.035m;

            //TODO taunt kill: Hadouken
        }
    }
    public class SoldierShotgun : AShotgun
    {
        public SoldierShotgun()
        {
            Name = "Shotgun (soldier)";

            Ammo.ReloadFirst = 1.005m;
        }
    }
    public class xShotgun : Weapon
    {
        public xShotgun()
        {
            Name = "shotgun";

            Hitscan = new Hitscan()
            {
                Damage = new Damage(60)
                {
                    Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
                    ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
                    LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
                },
                Fragmentation = new Fragmentation(Damage.SPREAD_SHOTGUN_SCATTERGUN)
                {
                    Fragments = 10,
                    FragmentType = "pellet",
                },

            };
            FireRate = 0.625m;
        }
    }

    /// <summary>
    /// 90	3-19	121	8-41	180	18-108
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class ReserveShooter : AShotgun
    {
        public ReserveShooter()
        {
            Name = "reserve shooter";
            Name = "Reserve Shooter"; Level = 10; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Mini-crits targets launched airborne by explosions, grapple hooks or rocket packs"),
new PositiveAttribute("This weapon deploys 20% faster"),
new NegativeAttribute("-34% clip size"),
});
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo.Loaded = 4;

        }
    }

    /// <summary>
    /// 108	3-18	145	6-13	216	14-43
    /// wiki: 104-108	3-10	146	97	216
    /// </summary>
    public class PanicAttack : AShotgun
    {
        // +50% bullets per shot; -20% damage penalty; spread gimmick
        //TODO (probably just from stock issue) wiki far max 36, calc is 38
        public PanicAttack()
            :base(72, 
                 15)
        {
            Name = "panic attack";
            Name = "Panic Attack"; Level = 1 - 99; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+50% bullets per shot"),
new PositiveAttribute("This weapon deploys 50% faster"),
new PositiveAttribute("Fires a fixed shot pattern"),
new NegativeAttribute("-20% damage penalty"),
new NegativeAttribute("Successive shots become less accurate"),
});
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(72)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 15,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            AlternateModes = new List<Weapon>
            {
                new PanicAttack6thShot()
            };
        }
    }

    public class PanicAttack6thShot : AShotgun
    {
        public PanicAttack6thShot()
             : base(72,
                 15, 
                 0.0945m)//TODO umm.. where's this from? math vs. basis instead?
        {
            Name = "6th shot";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(72)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0945)
            //    {
            //        Fragments = 15,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;
        }
    }

    /// <summary>
    /// 76	5-19	103	7-48	153	15-122
    /// wiki: 74-76	3-10	100	70	153
    /// </summary>
    public class FamilyBusiness : AShotgun
    {
        //TODO obs/wiki close max is 76, calc is 76.5=77  (and long wiki is 26, calc is 27 - relates to stock tho)
        //TODO maybe default .5 round of "toEven" is what game uses? I'm manually using "awayfromzero"
        public FamilyBusiness()
            :base(51)
        {
            Name = "family business";
            Name = "Family Business"; Level = 10; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+33% clip size"),
new PositiveAttribute("+15% faster firing speed"),
new NegativeAttribute("-15% damage penalty"),
});
            Notes += "obs/wiki agree close is 76, not (60*85%=51) 51*150%=76.5 rounds to 77.  That does match 'Round To Even' rule, however.\n";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(51)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.528,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            FireRate = 0.53125m;

            Ammo.Loaded = 8;
        }
    }

    /// <summary>
    /// 90	3-22	121	8-49	180	18-90
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class FrontierJustice : AShotgun
    {
        public FrontierJustice()
        {
            Name = "frontier justice";
            Name = "Frontier Justice"; Level = 5; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Gain 2 revenge crits for each sentry kill and 1 for each sentry assist when your sentry is destroyed."),
new NegativeAttribute("-50% clip size"),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("Revenge crits are lost on death"),
}); 
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo.Loaded = 3;
        }
    }

    /// <summary>
    /// 90	3-16	121	8-65	180	18-126
    /// wiki: 86-90	3-10	121	81	180
    /// </summary>
    public class Widowmaker : AShotgun
    {
        public Widowmaker()
        {
            Name = "widowmaker";
            Name = "Widowmaker"; Level = 5; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On hit: damage dealt is returned as ammo"),
new PositiveAttribute("No reload necessary"),
new PositiveAttribute("10% increased damage to your sentry's target"),
new NegativeAttribute("Per Shot: -30 ammo"),
new NegativeAttribute("Uses metal for ammo"),
}); 
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(60)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo = new Ammo(200)
            {
                AmmoType = "Metal",
                AmmoUsed = 30,
            };

            AlternateModes = new List<Weapon>()
            {
                new WidowmakerSentryTarget()
            };
        }
    }
    public class WidowmakerSentryTarget : AShotgun
    {
        public WidowmakerSentryTarget()
            :base(66)
        {
            Name = "sentry target";

            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(66)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SHOTGUN,
            //        ZeroRangeRamp = Damage.NORMAL_HITSCAN_ZERO_RANGE_RAMP,
            //        LongRangeRamp = Damage.NORMAL_LONG_RANGE_RAMP,//0.533333333333333,
            //    },
            //    Fragmentation = new Fragmentation(0.0675)
            //    {
            //        Fragments = 10,
            //        FragmentType = "pellet",
            //    },

            //};
            //FireRate = 0.625;

            Ammo = new Ammo(200)
            {
                AmmoType = "Metal",
                AmmoUsed = 30,
            };

        }
    }

}