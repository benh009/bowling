using System.Text;

namespace Bowling
{
    public class Game
    {
        public const int MaxNumberOfFrames = 10;
        public const int NumberOfPins = 10;
        public IList<Frame> Frames { get; set; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public void AddThrow(ThrowInput throwInput)
        {
            var lastFrame = Frames.LastOrDefault();
            if (lastFrame == null)
            {
                CreateFirstFrame(throwInput.PinsDown);
            }
            else if (lastFrame.IsFinish())
            {
                CreateNextFrame(throwInput.PinsDown, lastFrame);
            }
            else
            {
                if (Frames.Count == MaxNumberOfFrames)
                {
                    AddThrowInLastFrame(lastFrame, throwInput);
                }
                else
                {
                    lastFrame.AddThrow(new Throw(throwInput.PinsDown, ThrowType.Second, lastFrame.Throws[0]));
                }
            }
        }

        private void AddThrowInLastFrame(Frame lastFrame, ThrowInput throwInput)
        {
            if (lastFrame.Throws.Count() == 1)
            {
                lastFrame.AddThrow(new Throw(throwInput.PinsDown, ThrowType.Second, lastFrame.Throws[0], true));
            }
            else
            {
                lastFrame.AddThrow(new Throw(throwInput.PinsDown, ThrowType.Third, lastFrame.Throws[1], true));
            }
        }

        private void CheckNumberFrame()
        {
            if (Frames.Count() >= MaxNumberOfFrames)
            {
                throw new ArgumentException($"Max {MaxNumberOfFrames} Frames for a game");
            }
        }

        private void CreateFirstFrame(int pinsDown)
        {
            var frame = new Frame();
            Frames.Add(frame);
            frame.AddThrow(new Throw(pinsDown, ThrowType.First, null));
        }
        private void CreateNextFrame(int pinsDown, Frame previousFrame)
        {
            CheckNumberFrame();
            var frame = new Frame(previousFrame);
            Frames.Add(frame);

            var throwValue = new Throw(pinsDown, ThrowType.First);
            previousFrame.NextFrame = frame;
            if (Frames.Count == MaxNumberOfFrames)
            {
                frame.IsFinal = true;
                throwValue.IsFinal = true;
            }
            frame.AddThrow(throwValue);
        }

        public override string ToString()
        {
            int frameNumber = 1;
            var stringBuilder = new StringBuilder();
            foreach (var frame in Frames)
            {
                stringBuilder.AppendLine($"Frame Number : {frameNumber}");
                stringBuilder.AppendLine($"{frame}");
                stringBuilder.AppendLine();
                frameNumber++;
            }
            return stringBuilder.ToString();
        }
    }
}
