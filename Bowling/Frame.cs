namespace Bowling
{
    public class Frame
    {
        public List<Throw> Throws { get; }

        public bool IsFinal { get; set; }

        private Frame PreviousFrame { get; }

        public Frame NextFrame { get; set; }

        public Frame(Frame previousFrame) : this()
        {
            PreviousFrame = previousFrame;
        }

        public Frame()
        {
            Throws = new List<Throw>();
        }

        public void AddThrow(Throw throwv)
        {
            Throws.Add(throwv);
        }

        public int? GetPreviousScore()
        {
            if (PreviousFrame == null)
            {
                return 0;
            }
            return PreviousFrame.GetScore();
        }

        public int? GetScore()
        {
            if (!ScoreIsComputable())
            {
                return null;
            }
            int? previousScore = GetPreviousScore();

            if (IsStrike())
            {
                var scoreAfterStrike = GetScoreAfterStrike();
                return scoreAfterStrike != null ? previousScore + Game.NumberOfPins + scoreAfterStrike : null;
            }
            else if (IsSpare())
            {
                var scoreAfterSpare = GetScoreAfterSpare();
                return scoreAfterSpare != null ? previousScore + Game.NumberOfPins + scoreAfterSpare : null;
            }
            else
            {
                return previousScore + Throws[0].PinsDown + Throws[1].PinsDown;
            }
        }

        public bool IsFinish()
        {
            if (IsStrike())
            {
                if (this.IsFinal)
                {
                    if (Throws.Count() < 3)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (IsSpare())
            {
                if (this.IsFinal)
                {
                    if (Throws.Count() < 3)
                    {
                        return false;
                    }
                }
                return true;
            }
            return Throws.Count() == 2;
        }

        public bool IsStrike()
        {
            return Throws[0].PinsDown == Game.NumberOfPins;
        }

        public bool IsSpare()
        {
            return Throws.Count() >= 2 && Throws[0].PinsDown + Throws[1].PinsDown == Game.NumberOfPins;
        }

        public bool ScoreIsComputable()
        {
            if (IsStrike() || IsSpare() || Throws.Count == 1)
            {
                if (IsStrike() && GetScoreAfterStrike() != null)
                {
                    return true;
                }
                else if (IsSpare() && GetScoreAfterSpare() != null)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public int? GetScoreAfterStrike()
        {
            if (IsFinal)
            {
                if (Throws.Count() == 3)
                {
                    return Throws[1].PinsDown + Throws[2].PinsDown;
                }
            }
            else if (NextFrame == null)
            {
                return null;
            }
            else if (NextFrame.IsFinal)
            {
                if (NextFrame.Throws.Count() >= 2)
                {
                    return NextFrame.Throws[0].PinsDown + NextFrame.Throws[1].PinsDown;
                }
            }
            else if (NextFrame.IsStrike())
            {
                if (NextFrame.NextFrame == null)
                {
                    return null;
                }
                return NextFrame.Throws[0].PinsDown + NextFrame.NextFrame.Throws[0].PinsDown;
            }
            else if (NextFrame.Throws.Count() == 2)
            {
                return NextFrame.Throws[0].PinsDown + NextFrame.Throws[1].PinsDown;
            }
            return null;
        }

        public int? GetScoreAfterSpare()
        {
            if (IsFinal)
            {
                if (Throws.Count() == 3)
                {
                    return Throws[2].PinsDown;
                }
            }
            else if (NextFrame == null)
            {
                return null;
            }
            else if (NextFrame.Throws.Count() >= 1)
            {
                return NextFrame.Throws[0].PinsDown;
            }
            return null;
        }

        public string DisplayScore()
        {
            return GetScore() == null ? "" : GetScore().ToString();
        }

        public override string ToString()
        {
            var throwsString = string.Join(",", Throws);
            return $"Throws : {throwsString}  Score : {DisplayScore()}";
        }
    }
}
