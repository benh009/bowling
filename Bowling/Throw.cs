namespace Bowling
{
    public class Throw
    {
        public ThrowType ThrowType { get; }
        public int PinsDown { get; }
        public int? LastThrowPinsDown { get; }
        public bool IsFinal { get; set; }
        public const string StrikeString = "X";
        public const string SpareString = "/";

        public Throw(int pinsDown, ThrowType throwType, int lastThrowPinsDown, bool isFinal = false) : this(pinsDown, throwType)
        {
            this.IsFinal = isFinal;
            CheckValidatePinDown(lastThrowPinsDown);
            CheckValidateSumPinDown(pinsDown, lastThrowPinsDown);
            LastThrowPinsDown = lastThrowPinsDown;
        }

        public Throw(int pinsDown, ThrowType throwType)
        {
            CheckValidatePinDown(pinsDown);
            PinsDown = pinsDown;
            ThrowType = throwType;
        }

        public override string ToString()
        {
            if (PinsDown == Game.NumberOfPins)
            {
                if (ThrowType == ThrowType.First)
                {
                    return StrikeString;
                }
                if (IsFinal)
                {
                    if (ThrowType == ThrowType.Second && LastThrowPinsDown == Game.NumberOfPins)
                    {
                        return StrikeString;
                    }
                    else if (ThrowType == ThrowType.Third)
                    {
                        return StrikeString;
                    }
                }
            }

            if (ThrowType == ThrowType.Third && PinsDown + LastThrowPinsDown == Game.NumberOfPins)
            {
                return SpareString;
            }

            if (ThrowType == ThrowType.Second && PinsDown + LastThrowPinsDown == Game.NumberOfPins)
            {
                if (LastThrowPinsDown != Game.NumberOfPins)
                {
                    return SpareString;
                }
            }
            return $"{PinsDown}";
        }

        private void CheckValidateSumPinDown(int pinsDown, int lastThrowPinsDown)
        {
            if (IsFinal && lastThrowPinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && ThrowType == ThrowType.Second && lastThrowPinsDown + pinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && ThrowType == ThrowType.Third)
            {
                return;
            }

            if (pinsDown + lastThrowPinsDown > Game.NumberOfPins)
            {
                throw new ArgumentException($"Sum of pinsDown must be between 0 and {Game.NumberOfPins}");
            }
        }

        private void CheckValidatePinDown(int pinsDown)
        {
            if (pinsDown < 0 || pinsDown > Game.NumberOfPins)
            {
                throw new ArgumentException($"PinsDown must ne between 0 and {Game.NumberOfPins}");
            }
        }
    }
}
