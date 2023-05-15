using Bowling;

try
{
    Console.WriteLine($"Your values : {string.Join(" ", args)}");
    Console.WriteLine("===============================================");
    Console.WriteLine("===============================================\n");
    var parser = new ParserCommandLineArguments();
    var throws = parser.Parse(args);
    var gameRunner = new GameRunner();
    gameRunner.Run(throws);
}
catch (Exception e)
{
    Console.WriteLine("Error !!!! :");
    Console.WriteLine(e.Message);
}

Console.ReadLine();

