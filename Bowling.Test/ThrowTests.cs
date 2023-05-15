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
            var throwValue = new Throw(10, ThrowType.First, null, isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_Final2Strike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Second, new Throw(10, ThrowType.First,null, isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_Final3Strike_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Third, new Throw(10, ThrowType.First, null, isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FirstSpare_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(9, ThrowType.Second, new Throw(1, ThrowType.First));

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }


        [TestMethod]
        public void ToString_FirstSpareAfter0_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Second, new Throw(0, ThrowType.First));

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalSpare_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(9, ThrowType.Second, new Throw(1, ThrowType.First, null, isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalSpareAfter0_0()
        {
            // arrange    // act
            var throwValue = new Throw(0, ThrowType.Second, new Throw(10, ThrowType.First, null, isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual("0", throwValue.ToString());
        }

        [TestMethod]
        public void ToString_FinalStrikeAfterSpare_Strike()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Third, new Throw(9, ThrowType.Second, new Throw(1, ThrowType.First, null, isFinal: true), isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual(Throw.StrikeString, throwValue.ToString());
        }


        [TestMethod]
        public void ToString_FinalSpareAfter0_Spare()
        {
            // arrange    // act
            var throwValue = new Throw(10, ThrowType.Third, new Throw(0, ThrowType.Second, new Throw(10, ThrowType.First, null, isFinal: true), isFinal: true), isFinal: true);

            // assert
            Assert.AreEqual(Throw.SpareString, throwValue.ToString());
        }
    }
}
