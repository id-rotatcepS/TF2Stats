namespace StatsData
{

    public class DamageCalculations
    {
        private WeaponVM v;
        private decimal closeOffset;
        private Damage d;
        public DamageCalculations(WeaponVM v)
        {
            this.v = v;
            d = v.Damage;
            closeOffset = d?.Offset ?? 23.5m;
        }

        public decimal CloseOffset { private get => closeOffset; set => closeOffset = value; }

        public int Far => Farx(d, maxRange);
        public int FarMinicritOrEquivalent => canMinicrit 
            ? FarMinicrit 
            : (canCrit ? FarCritx(d) 
            : Farx(d, maxRange));
        public int FarMinicrit => FarMinicritx(d, maxRange);
        public int FarCritOrEquivalent => canCrit 
            ? FarCrit
            : Farx(d, maxRange);
        public int FarCrit => FarCritx(d);
        public decimal FarDecimal => FarDecimalx(d, maxRange);
        public decimal FarCritDecimal => FarCritDecimalx(d);
        public decimal FarMinicritDecimal => FarMinicritDecimalx(d, maxRange);

        public int Close => CloseWithOffset(d, CloseOffset);
        public int CloseMinicritOrEquivalent => canMinicrit 
            ? CloseMinicrit
            : (canCrit ? CloseCritx(d) 
            : CloseWithOffset(d, CloseOffset));
        public int CloseMinicrit => CloseMinicritWithOffset(d, CloseOffset);
        public int CloseCritOrEquivalent => canCrit 
            ? CloseCrit 
            : CloseWithOffset(d, CloseOffset);
        public int CloseCrit => CloseCritx(d);
        public decimal CloseDecimal => CloseWithOffsetDecimal(d, CloseOffset);
        public decimal CloseCritDecimal => CloseCritDecimalx(d);
        public decimal CloseMinicritDecimal => CloseMinicritWithOffsetDecimal(d, CloseOffset);

        public int Building => Buildingx(d);

        private decimal? maxRange => v.MaxRange;
        private bool canMinicrit => v.CanMinicrit;
        private bool canCrit => v.CanCrit;

        //TODO adjust these based on calculations maybe... or delete them and inline the stuff again.
        public decimal ZeroRangeRamp => d?.ZeroRangeRamp ?? 1.0m; // TODO was d? and decimal? but I think I'm ok with this.
        public decimal LongRangeRamp => d?.LongRangeRamp ?? 1.0m;

        public decimal MinicritZeroRangeRamp => ZeroRangeRamp;
        public decimal MinicritLongRangeRamp => d?.CritIncludesRamp??false
            ? LongRangeRamp
            : 1.0m;

        public decimal CritZeroRangeRamp => d?.CritIncludesRamp??false
            ? ZeroRangeRamp
            : 1.0m;
        public decimal CritLongRangeRamp => d?.CritIncludesRamp??false
            ? LongRangeRamp
            : 1.0m;


        //private int Closex(Damage d)
        //{
        //    decimal x = d?.Offset ?? 23.5m;
        //    return CloseWithOffset(d, x);
        //}

        private int CloseWithOffset(Damage d, decimal offset)
            => Round(CloseWithOffsetDecimal(d, offset));
        private decimal CloseWithOffsetDecimal(Damage d, decimal offset)
        {
            // offset is distance from eye, so it's a REDUCTION in range... I assume the collision box size of 32 keeps the eyes apart by half each (so 32 total).
            // I assume the hit target is the middle of the collision box and the eyes are at the middle of the collision box ( just higher up )
            // I assume the offset is where the start of range is measured from (could be wrong, in which case all offsets become 0, but calculation still needs to happen)
            // so closest distance is (32-offset)
            // That means offsets of 32 are "as close as possible" and offsets of 0 are "as far as possible"
            decimal offsetRange = 32 - offset;

            return GetDamageAtRange(d, offsetRange);
        }

        private int Round(decimal d) => WeaponVMDetail.Round(d);

        private int CloseMinicritWithOffset(Damage d, decimal x)
            => Round(CloseMinicritWithOffsetDecimal(d, x));
        private decimal CloseMinicritWithOffsetDecimal(Damage d, decimal x)
        {
            decimal offsetRange = 32 - x;

            return GetDamageAtRange(d, offsetRange) * 1.35m;
        }

        private int CloseCritx(Damage d)
            => Round(CloseCritDecimalx(d));
        private decimal CloseCritDecimalx(Damage d)
        {
            if (d == null) return 0;
            if (d.CritIncludesRamp)
            {
                decimal x = 32;//TODO pass this in like others?
                decimal offsetRange = 32 - x;
                return GetDamageAtRange(d, offsetRange) * 3.0m;
            }
            return d.Base * 3.0m;
        }

        private int Buildingx(Damage d)
            => Round(BuildingDecimalx(d));
        private decimal BuildingDecimalx(Damage d)
        {
            if (d == null) return 0;
            return d.Base * d.BuildingModifier;
        }

        private int Farx(Damage d, decimal? maxRange)
            => Round(FarDecimalx(d, maxRange));
        private decimal FarDecimalx(Damage d, decimal? maxRange)
        {
            if (d == null) return 0;
            if (maxRange.HasValue)
            {
                decimal max = maxRange.Value;
                return GetDamageAtRange(d, max);
            }
            return d.Base * d.LongRangeRamp;
        }

        private decimal GetDamageAtRange(Damage d, decimal distance)
        {
            if (d == null) return 0;
            decimal medRange = 512m;
            if (distance < medRange)
            {
                // Max far is actually in the close range (512=0%, 0=100%)
                decimal percentOfClose = (medRange - distance) / medRange;
                decimal rampValue = PercentOfRamp(percentOfClose, d.ZeroRangeRamp);
                return d.Base * rampValue;
            }
            else if (distance < medRange * 2)
            {
                // Max far is not the entire long range ramp (1024=100%, 512=0%)
                decimal percentOfLong = (distance - medRange) / medRange;
                decimal rampValue = PercentOfRamp(percentOfLong, d.LongRangeRamp);
                return d.Base * rampValue;
            }
            else
                return d.Base * d.LongRangeRamp;
        }

        // we want percent of difference from 1.0
        private decimal PercentOfRamp(decimal percent, decimal rampValue)
        {
            if (rampValue > 1.0m)
            {
                decimal midIncr = rampValue - 1.0m;
                return 1.0m + (percent * midIncr);
            }
            else if (rampValue < 1.0m)
            {
                decimal midReduc = 1.0m - rampValue;
                return 1.0m - (percent * midReduc);
            }
            else
                return 1.0m;
        }

        private int FarMinicritx(Damage d, decimal? maxRange)
            => Round(FarMinicritDecimalx(d, maxRange));
        private decimal FarMinicritDecimalx(Damage d, decimal? maxRange)
        {
            if (d == null) return 0;
            decimal far = 1024m;
            if (maxRange.HasValue)
            {
                decimal max = maxRange.Value;
                decimal medRange = 512m;
                if (max < medRange)
                {
                    return GetDamageAtRange(d, max) * 1.35m;
                }
                // max uses usual range... probably
                if (max < far)
                    far = max;
            }

            return d.CritIncludesRamp 
                ? GetDamageAtRange(d, far) * 1.35m 
                : d.Base * 1.35m;
        }

        private int FarCritx(Damage d)
            => Round(FarCritDecimalx(d));
        private decimal FarCritDecimalx(Damage d)
        {
            if (d == null) return 0;
            return d.CritIncludesRamp 
                ? GetDamageAtRange(d, 1024m) * 3.0m
                : d.Base * 3.0m;
        }

    }

}
