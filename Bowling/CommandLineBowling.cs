using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class CommandLineBowling
    {
        public void Run(string[] args)
        {
            try
            {
                Console.WriteLine($"Your values : {string.Join(" ", args)}");
                Console.WriteLine("===============================================");
                Console.WriteLine("===============================================\n");
                var parser = new ParserCommandLineArguments();
                var throws = parser.Parse(args);
                var gameRunner = new GameRunner();
                Console.WriteLine(gameRunner.Run(throws));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error !!!! :");
                Console.WriteLine(e.Message);
            }
        }
    }
}
