using StatsData;
using System.Collections.Generic;

namespace StatsData
{

    public abstract class ASniperRifle : Weapon
    {
        public ASniperRifle(decimal baseDamage = 50)
        {
            Name = "sniper rifle";
            ActivationTime = 1.3m;// sec pre-charge delay;
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_SNIPER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                //Recoil = new Recoil(0) // aka Damage.SPREAD_SNIPER
                //{
                //    Recovery = 0
                //},
                // Penetrates teammates, but not enemies
            };
            FireRate = 1.5m;
        }
    }
    public class SniperRifle : ASniperRifle
    {
        public SniperRifle()
        {
            AlternateModes = new List<Weapon>
            {
                new ChargedSniperRifle()
            };
        }
    }
    public class ChargedSniperRifle : ASniperRifle
    {
        public ChargedSniperRifle()
            : base(150)
        {
            Name = "sniper rifle (fully charged)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
        }
    }



    public class SydneySleeper : ASniperRifle
    {
        public SydneySleeper()
        {
            Name = "sydney sleeper";
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)
            //    {
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    Recoil = new Recoil(0)
            //    {

            //    },

            //};
            //FireRate = 1.5;
            AlternateModes = new List<Weapon>
            {
                new ChargedSniperRifle()//TODO custom
            };
        }
    }

    public class BazaarBargain : ASniperRifle
    {
        public BazaarBargain()
        {
            Name = "bazaar bargain";
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)
            //    {
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //    Recoil = new Recoil(0)
            //    {

            //    },

            //};
            //FireRate = 1.5;

            //TODO Charged and Heads and Charged Heads as modes
            AlternateModes = new List<Weapon>
            {
                new ChargedSniperRifle()
                //    new ChargedBazaarBargain()
                //   new MaxHeadsChargedBazaarBargain(), 
            };

        }
    }

    public class Machina : ASniperRifle
    {
        public Machina()
            : base(50)//FIXME pretty sure this is wrong?
        {
            Name = "machina";
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)//FIXME pretty sure this is wrong?
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    //Recoil = new Recoil(0)
            //    //{
            //    //    Recovery = 0
            //    //},
            //};
            //FireRate = 1.5;

            AlternateModes = new List<Weapon>
            {
                // Full charge penetrates, but regular shot doesn't
                new ChargedMachina() //172.5
            };

        }
    }
    public class ChargedMachina : ASniperRifle
    {
        public ChargedMachina()
        //:base(172.5) // custom because it's penetrating
        {
            Name = "machina (fully charged)";
            ActivationTime = 2.0m + 1.3m;// sec pre-charge delay;
            Hitscan = new Hitscan()
            {
                Damage = new Damage(172.5m)
                {
                    Offset = Damage.OFFSET_HITSCAN_SNIPER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                // Full charge penetrates, but regular shot doesn't
                Penetrating = true,
                //Recoil = new Recoil(0)
                //{
                //    Recovery = 0
                //},
            };
            //FireRate = 1.5;

        }
    }

    public class HitmansHeatmaker : ASniperRifle
    {
        public HitmansHeatmaker()
            : base(40)
        {
            Name = "hitman's heatmaker";
            //ActivationTime = 1.3;// sec pre-charge delay, none with focus;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(40)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 1.5;
            //TODO Charged as a mode
            AlternateModes = new List<Weapon>
            {
                new ChargedSniperRifle()
                //new ChargedHitmansHeatmaker()
                //new HitmansHeatmakerHeadshot()
                //new ChargedHitmansHeatmakerHeadshot()
            };
        }
    }

    public class Classic : ASniperRifle
    {
        public Classic()
            : base(45)
        {
            Name = "classic";
            ActivationTime = 0;// no delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(45)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    //Recoil = new Recoil(0)
            //    //{
            //    //    Recovery = 0
            //    //},

            //};
            //FireRate = 1.5;
            //TODO Charged as a mode
            AlternateModes = new List<Weapon>
            {
                new ChargedSniperRifle()
                //new ChargedClassic()
                //new ChargedClassicHeadshot()
            };
        }
    }

}