namespace StatsData
{
    /// <summary>
    /// https://wiki.teamfortress.com/wiki/Hammer_unit
    ///     Maps, architecture and prop models: 1 foot = 16 HU. This means 1 unit is approximately equal to 1.905 centimeters.
    ///     This ratio is used to judge the speed of projectiles and players.
    ///     Skyboxes (which are 1/16th scale of ordinary maps) use 1 foot = 1 HU.
    ///     Human Character models and certain other models for Source Engine currently use 1 foot = 12 HU.
    /// </summary>
    public class HammerUnit
    {
        private readonly decimal hu;
        public const decimal HU_PER_FOOT = 16m;
        public const decimal CM_PER_HU = 1.905m;
        private const decimal CM_PER_METER = 100m;
        private const decimal METER_PER_CM = .01m;
        public const decimal HU_PER_METER = 1.0m/(METER_PER_CM*CM_PER_HU);

        public HammerUnit(decimal hu)
        {
            this.hu = hu;
        }

        public string GetDetail()
        {
            return string.Format("{1:0.##} m ({2:0.##} ft, {0:0.##} HU)", hu, GetMeters(), GetFeet());
        }

        public decimal GetMeters()
        {
            return hu / HU_PER_METER;
        }

        public decimal GetFeet()
        {
            return hu / HU_PER_FOOT;
        }
    }
}
