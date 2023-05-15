namespace Bowling.Test
{
    [TestClass]
    public class ThrowTests
    {

        [TestMethod]
        public void ToString_FirstStrike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.First);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalStrike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.First, 0, isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_Final2Strike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Second, 10, isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_Final3Strike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Third, 10, isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FirstSpare_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(9, ThrowType.Second, 1);

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }


        [TestMethod]
        public void ToString_FirstSpareAfter0_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Second, 0);

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalSpare_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(9, ThrowType.Second, 1, isFinal: true);

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalSpareAfter0_0()
        {
            // arrange    // act
            var throwValue = new Throw(0, ThrowType.Second, 10, isFinal: true);

            // assert
            Assert.AreEqual("0", throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalStrikeAfterSpare_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Third, 9, isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }
    }
}
