namespace Bowling.Test
{
    [TestClass]
    public class ParserCommandLineArgumentsTests
    {
        [TestMethod]
        public void Parse_ValidStrings_GetThrows()
        {
            // arrange
            var parser = new ParserCommandLineArguments();

            // act
            var throws = parser.Parse(new string[] { "1", "2", "5" });

            // assert
            Assert.IsNotNull(throws);
            Assert.IsTrue(throws.ToList().Count() == 3);
            Assert.IsTrue(throws.ToList()[0].PinsDown == 1);
            Assert.IsTrue(throws.ToList()[1].PinsDown == 2);
            Assert.IsTrue(throws.ToList()[2].PinsDown == 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_NotValidStrings_ThrowException()
        {
            // arrange
            var parser = new ParserCommandLineArguments();

            // act
            var throws = parser.Parse(new string[] { "a string" });

            // assert
            Assert.IsNull(throws);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_DecimalStrings_ThrowException()
        {
            // arrange
            var parser = new ParserCommandLineArguments();

            // act
            var throws = parser.Parse(new string[] { "2.1" });

            // assert
            Assert.IsNull(throws);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_NoStrings_ThrowException()
        {
            // arrange
            var parser = new ParserCommandLineArguments();

            // act
            var throws = parser.Parse(new string[] { });

            // assert
            Assert.IsNull(throws);
        }
    }
}
