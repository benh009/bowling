namespace Bowling
{
    public class GameRunner
    {
        public void Run(IEnumerable<ThrowInput> throwInputs)
        {
            var game = new Game();
            int throwsNumber = 1;
            foreach (var throwInput in throwInputs)
            {
                Console.WriteLine($"Throw Number : {throwsNumber}  Value : {throwInput.PinsDown}");
                Console.WriteLine($"=================================\n");
                game.AddThrow(throwInput);
                Console.WriteLine(game);
                throwsNumber++;
            }
        }
    }
}
