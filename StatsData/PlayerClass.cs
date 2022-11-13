namespace StatsData
{
    public abstract class PlayerClass
    {
        public string Name { get; protected set; }
        public int Slot { get; protected set; }
        public ClassType ClassType {get;protected set;}
        public int Speed { get; protected set; }
        public int Health { get; protected set; }
        public int ViewHeight { get; protected set; }
        //Box ImpactBox { get; protected set; }
        //Box BodyHitScanBox { get; protected set; }
        public int BodyHitScanWidth { get; protected set; }
        //Box HeadHitScanBox { get; protected set; }

    }
    public enum ClassType
    {
        Defense,
        Offense,
        Support
    }

    public class Scout : PlayerClass
    {
        public Scout()
        {
            Name = nameof(Scout);
            Slot = 1;
            ClassType = ClassType.Offense;
            Health = 125;
            ViewHeight= 65;
            BodyHitScanWidth = 25;
            Speed = 400;
            //SelfDamage;
            //SelfDamageRocketJumping;
            //BodyHitScanBox;
            //HeadHitScanBox;
        }
    }
    public class Soldier : PlayerClass
    {
        public Soldier()
        {
            Name = nameof(Soldier);
            Slot = 2;
            ClassType = ClassType.Offense;
            Health = 200;
            ViewHeight = 68;
            BodyHitScanWidth = 37;
            Speed = 240;
        }
    }
    public class Pyro : PlayerClass
    {
        public Pyro()
        {
            Name = nameof(Pyro);
            Slot = 3;
            ClassType = ClassType.Offense;
            Health = 175;
            ViewHeight = 68;
            BodyHitScanWidth = 37;
            Speed = 300;
        }
    }
    public class Demoman : PlayerClass
    {
        public Demoman()
        {
            Name = nameof(Demoman);
            Slot = 4;
            ClassType = ClassType.Defense;
            Health = 175;
            ViewHeight = 68;
            BodyHitScanWidth = 37;
            Speed = 280;
        }
    }
    public class Heavy : PlayerClass
    {
        public Heavy()
        {
            Name = nameof(Heavy);
            Slot = 5;
            ClassType = ClassType.Defense;
            Health = 300;
            ViewHeight = 75;
            BodyHitScanWidth = 49;
            Speed = 230;
        }
    }
    public class Engineer : PlayerClass
    {
        public Engineer()
        {
            Name = nameof(Engineer);
            Slot = 6;
            ClassType = ClassType.Defense;
            Health = 125;
            ViewHeight = 68;
            BodyHitScanWidth = 37;
            Speed = 300;
        }
    }
    public class Medic : PlayerClass
    {
        public Medic()
        {
            Name = nameof(Medic);
            Slot = 7;
            ClassType = ClassType.Support;
            Health = 150;
            ViewHeight = 75;
            BodyHitScanWidth = 25;
            Speed = 320;
        }
    }
    public class Sniper : PlayerClass
    {
        public Sniper()
        {
            Name = nameof(Sniper);
            Slot = 9;
            ClassType = ClassType.Support;
            Health = 125;
            ViewHeight = 75;
            BodyHitScanWidth = 25;
            Speed = 300;
        }
    }
    public class Spy : PlayerClass
    {
        public Spy()
        {
            Name = nameof(Spy);
            Slot = 9;
            ClassType = ClassType.Support;
            Health = 125;
            ViewHeight = 75;
            BodyHitScanWidth = 25;
            Speed = 320;
        }
    }
}