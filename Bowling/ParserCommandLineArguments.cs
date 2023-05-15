namespace Bowling
{
    public class ParserCommandLineArguments
    {
        public IEnumerable<ThrowInput> Parse(string[] args)
        {
            if (args.Length > 0)
            {
                var throws = new List<ThrowInput>();
                foreach (var throwString in args)
                {
                    int throwInt;
                    var isInteger = Int32.TryParse(throwString, out throwInt);
                    if (!isInteger)
                    {
                        throw new ArgumentException($"Please enter only integer");
                    }
                    throws.Add(new ThrowInput(throwInt));
                }
                return throws;
            }
            else
            {
                throw new ArgumentException("No arguments. Please enter value like this : \"5 2 10 7 0 4\" ");
            }
        }
    }
}
