namespace Bowling
{
    public class Throw
    {
        public ThrowType ThrowType { get; }
        public int PinsDown { get; }
        public int? LastThrowPinsDown { get; }
        public bool IsFinal { get; set; }
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
            if (IsFinal && PinsDown == Game.NumberOfPins)
            {
                return "X";
            }

            if (ThrowType == ThrowType.First && PinsDown == Game.NumberOfPins)
            {
                return "X";
            }

            if (ThrowType == ThrowType.Third && PinsDown + LastThrowPinsDown == Game.NumberOfPins)
            {
                return "/";
            }

            if (ThrowType == ThrowType.Second && PinsDown + LastThrowPinsDown == Game.NumberOfPins)
            {
                return "/";
            }
            return $"{PinsDown}";
        }

        private void CheckValidateSumPinDown(int pinsDown, int lastThrowPinsDown)
        {
            if (IsFinal && lastThrowPinsDown == Game.NumberOfPins)
            {
                return;
            }

            if (IsFinal && lastThrowPinsDown + pinsDown == Game.NumberOfPins)
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
