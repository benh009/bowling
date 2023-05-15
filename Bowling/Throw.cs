namespace Bowling
{
    public class Throw
    {
        public ThrowType ThrowType { get; }
        public int PinsDown { get; }
        public Throw LastThrow { get; }
        public bool IsFinal { get; set; }
        public const string StrikeString = "X";
        public const string SpareString = "/";

        public Throw(int pinsDown, ThrowType throwType, Throw lastThrow, bool isFinal = false) : this(pinsDown, throwType)
        {
            this.IsFinal = isFinal;
            LastThrow = lastThrow;
            CheckValidateSumPinDown();
        }

        public Throw(int pinsDown, ThrowType throwType)
        {
            PinsDown = pinsDown;
            ThrowType = throwType;
            CheckValidatePinDown();
        }

        public override string ToString()
        {
            var toStringStrike = ToStringStrike();
            if (toStringStrike != null)
            {
                return toStringStrike;
            }

            var toStringSpare = ToStringSpare();
            if (toStringSpare != null)
            {
                return toStringSpare;
            }

            return $"{PinsDown}";
        }

        private string ToStringStrike()
        {
            if (PinsDown == Game.NumberOfPins)
            {
                if (ThrowType == ThrowType.First)
                {
                    return StrikeString;
                }
                if (IsFinal)
                {
                    if (ThrowType == ThrowType.Second && LastThrow.PinsDown == Game.NumberOfPins)
                    {
                        return StrikeString;
                    }
                    else if (ThrowType == ThrowType.Third && LastThrow.PinsDown != 0)
                    {
                        return StrikeString;
                    }
                }
            }

            return null;

        }
        private string ToStringSpare()
        {
            if (ThrowType == ThrowType.Third && PinsDown + LastThrow.PinsDown == Game.NumberOfPins)
            {
                return SpareString;
            }

            if (ThrowType == ThrowType.Second && PinsDown + LastThrow.PinsDown == Game.NumberOfPins)
            {
                if (LastThrow.PinsDown != Game.NumberOfPins)
                {
                    return SpareString;
                }
            }
            return null;
        }

        private void CheckValidateSumPinDown()
        {
            if (LastThrow == null)
            {
                return;
            }
            if (IsFinal && LastThrow.PinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && ThrowType == ThrowType.Second && LastThrow.PinsDown + PinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && ThrowType == ThrowType.Third && LastThrow.PinsDown == Game.NumberOfPins && LastThrow.LastThrow.PinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && ThrowType == ThrowType.Third && LastThrow.PinsDown + LastThrow.LastThrow.PinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (PinsDown + LastThrow.PinsDown > Game.NumberOfPins)
            {
                throw new ArgumentException($"Sum of pinsDown must be between 0 and {Game.NumberOfPins}");
            }
        }

        private void CheckValidatePinDown()
        {
            if (PinsDown < 0 || PinsDown > Game.NumberOfPins)
            {
                throw new ArgumentException($"PinsDown must ne between 0 and {Game.NumberOfPins}");
            }
        }
    }
}
