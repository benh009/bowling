namespace Bowling.Test
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void AddThrow_ValidThrow_NotNullThrow()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(1));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(game.Frames[0].Throws[0].PinsDown, 1);
        }

        [TestMethod]
        public void AddThrow_ValidThrow_NotNullSecondThrow()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(1));
            game.AddThrow(new ThrowInput(2));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(game.Frames[0].Throws[0].PinsDown, 1);
            Assert.AreEqual(game.Frames[0].Throws[1].PinsDown, 2);
        }

        [TestMethod]
        public void AddThrow_ValidThrow_NotNullThirdThrow()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(1));
            game.AddThrow(new ThrowInput(2));
            game.AddThrow(new ThrowInput(3));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(game.Frames[0].Throws[0].PinsDown, 1);
            Assert.AreEqual(game.Frames[0].Throws[1].PinsDown, 2);
            Assert.AreEqual(game.Frames[1].Throws[0].PinsDown, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddThrow_InValidThrow_ThrowException()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(11));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddThrow_InValidSumThrow_ThrowException()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(9));
            game.AddThrow(new ThrowInput(9));
        }


        [TestMethod]
        public void AddThrow_ValidCompletGame_NotNullScore()
        {
            // arrange
            var game = new Game();

            // act
            int i = 0;
            while (i < 20)
            {
                game.AddThrow(new ThrowInput(1));
                i++;
            }

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(20, game.Frames[9].GetScore());
        }

        [TestMethod]
        public void AddThrow_ValidCompletGame_ScoreZero()
        {
            // arrange
            var game = new Game();

            // act
            int i = 0;
            while (i < 20)
            {
                game.AddThrow(new ThrowInput(0));
                i++;
            }

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(0, game.Frames[9].GetScore());
        }

        [TestMethod]
        public void AddThrow_ValidCompletGame_Score300()
        {
            // arrange
            var game = new Game();

            // act
            int i = 0;
            while (i < 12)
            {
                game.AddThrow(new ThrowInput(10));
                i++;
            }

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(300, game.Frames[9].GetScore());
        }

        [TestMethod]
        public void AddThrow_ValidCompletGameSpare_Score110()
        {
            // arrange
            var game = new Game();

            // act
            int i = 0;
            while (i < 10)
            {
                game.AddThrow(new ThrowInput(1));
                game.AddThrow(new ThrowInput(9));
                i++;
            }
            game.AddThrow(new ThrowInput(1));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Console.WriteLine(game.ToString());
            Assert.AreEqual(110, game.Frames[9].GetScore());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddThrow_InValidGameOver_ThrowException()
        {
            // arrange
            var game = new Game();

            // act
            int i = 0;
            while (i < 21)
            {
                game.AddThrow(new ThrowInput(1));
                i++;
            }
        }

        [TestMethod]
        public void AddThrow_ValidFistFrame_CheckFirstFrame()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(1));
            game.AddThrow(new ThrowInput(2));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(1, game.Frames[0].Throws[0].PinsDown);
            Assert.AreEqual(2, game.Frames[0].Throws[1].PinsDown);
            Assert.AreEqual(3, game.Frames[0].GetScore());
        }

        [TestMethod]
        public void AddThrow_Strike_CheckSecondFrame()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(10));
            game.AddThrow(new ThrowInput(4));
            game.AddThrow(new ThrowInput(1));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(4, game.Frames[1].Throws[0].PinsDown);
            Assert.AreEqual(1, game.Frames[1].Throws[1].PinsDown);
            Assert.AreEqual(20, game.Frames[1].GetScore());
        }

        [TestMethod]
        public void AddThrow_ValidSecondFrame_CheckSecondFrame()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(1));
            game.AddThrow(new ThrowInput(2));
            game.AddThrow(new ThrowInput(3));
            game.AddThrow(new ThrowInput(4));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
            Assert.AreEqual(3, game.Frames[1].Throws[0].PinsDown);
            Assert.AreEqual(4, game.Frames[1].Throws[1].PinsDown);
            Assert.AreEqual(10, game.Frames[1].GetScore());
        }

        [TestMethod]
        public void AddThrow_ValidThrows_NotNullScore()
        {
            // arrange
            var game = new Game();

            // act
            game.AddThrow(new ThrowInput(5));
            game.AddThrow(new ThrowInput(2));
            game.AddThrow(new ThrowInput(10));
            game.AddThrow(new ThrowInput(7));
            game.AddThrow(new ThrowInput(0));
            game.AddThrow(new ThrowInput(4));

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(game.ToString()));
        }

    }
}