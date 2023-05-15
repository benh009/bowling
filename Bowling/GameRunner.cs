using System.Text;

namespace Bowling
{
    public class GameRunner
    {
        private readonly Game _game;

        public GameRunner()
        {
            _game = new Game();
        }

        public string Run(IEnumerable<ThrowInput> throwInputs)
        {
            int throwsNumber = 1;
            var stringBuilder = new StringBuilder();
            foreach (var throwInput in throwInputs)
            {
                stringBuilder.AppendLine($"Throw Number : {throwsNumber}  Value : {throwInput.PinsDown}");
                stringBuilder.AppendLine($"=================================\n");
                stringBuilder.AppendLine();
                _game.AddThrow(throwInput);
                stringBuilder.AppendLine(_game.ToString());
                throwsNumber++;
            }
            return stringBuilder.ToString();
        }
    }
}
