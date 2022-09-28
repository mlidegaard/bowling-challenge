using bowling_challenge.Models;
using NUnit.Framework;

namespace bowling_challenge_tests
{
    internal class BowlingGameUnitTests
    {
        BowlingGame bowlingGame = new BowlingGame();

        [SetUp]
        public void Setup()
        {
            bowlingGame = new BowlingGame();
        }

        [Test]
        public void GameWithNoHits_ExpectZeroPoints()
        {
            for (int i = 0; i < 20; i++)
            {
                bowlingGame.RollBall(0);
            }

            Assert.AreEqual(0, bowlingGame.GetScore());
        }

        [Test]
        public void GameWithoutSparesAndStrikes_ExpectNoBonusPoints()
        {
            bowlingGame.RollBall(0);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);

            bowlingGame.RollBall(2);
            bowlingGame.RollBall(7);

            bowlingGame.RollBall(3);
            bowlingGame.RollBall(6);

            bowlingGame.RollBall(4);
            bowlingGame.RollBall(5);

            bowlingGame.RollBall(0);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);

            bowlingGame.RollBall(2);
            bowlingGame.RollBall(7);

            bowlingGame.RollBall(3);
            bowlingGame.RollBall(6);

            bowlingGame.RollBall(4);
            bowlingGame.RollBall(5);


            Assert.AreEqual(90, bowlingGame.GetScore());
        }

        [Test]
        public void OneSpareInFirstRound_ExpectBonusPointsForSpare()
        {
            bowlingGame.RollBall(1);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);

            Assert.AreEqual(20, bowlingGame.GetScore());
        }

        [Test]
        public void GameWithMultipleSpares_ExpectBonusPointsForAllSpares()
        {
            bowlingGame.RollBall(1);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);

            bowlingGame.RollBall(3);
            bowlingGame.RollBall(7);

            bowlingGame.RollBall(3);
            bowlingGame.RollBall(6);

            bowlingGame.RollBall(4);
            bowlingGame.RollBall(5);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);

            bowlingGame.RollBall(2);
            bowlingGame.RollBall(7);

            bowlingGame.RollBall(3);
            bowlingGame.RollBall(6);

            bowlingGame.RollBall(4);
            bowlingGame.RollBall(5);


            Assert.AreEqual(98, bowlingGame.GetScore());
        }

        [Test]
        public void GameWithSpareInLastFrame_ExpectLastRollToBeGrantedAndBonusPointsGiven()
        {
            for (int i = 0; i < 9; i++)
            {
                bowlingGame.RollBall(1);
                bowlingGame.RollBall(8);
            }

            bowlingGame.RollBall(5);
            bowlingGame.RollBall(5);

            bowlingGame.RollBall(5);
            Assert.AreEqual(96, bowlingGame.GetScore());
        }

        [Test]
        public void FullGameOfSpares_ExpectBonusPointsForAllSparesAndLastRollToBeGranted()
        {
            for (int i = 0; i < 10; i++)
            {
                bowlingGame.RollBall(1);
                bowlingGame.RollBall(9);
            }

            bowlingGame.RollBall(1);
            Assert.AreEqual(110, bowlingGame.GetScore());
        }

        [Test]
        public void OneStrikeInFirstRound_ExpectBonusPointsForStrike()
        {
            bowlingGame.RollBall(10);

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(8);


            Assert.AreEqual(28, bowlingGame.GetScore());
        }

        [Test]
        public void GameWithStrikeAsFirstRollLastFrame_ExpectTwoBonusRollsAndBonusPoints()
        {

            for (int i = 0; i < 9; i++)
            {
                bowlingGame.RollBall(1);
                bowlingGame.RollBall(8);
            }

            bowlingGame.RollBall(10);
            bowlingGame.RollBall(10);
            bowlingGame.RollBall(10);

            Assert.AreEqual(111, bowlingGame.GetScore());
        }

        [Test]
        public void FullGameOfStrikes_ExpectBonusPointsForAllStrikesAndLastTwoExtraRollsToBeGranted()
        {
            for (int i = 0; i < 12; i++)
            {
                bowlingGame.RollBall(10);
            }

            Assert.AreEqual(300, bowlingGame.GetScore());
        }

        [Test]
        public void SpareAsSecondLastStrikesForBonus_ExpectSpareToGiveExtraRollAndBonusPointsForStrike()
        {
            for (int i = 0; i < 9; i++)
            {
                bowlingGame.RollBall(0);
                bowlingGame.RollBall(0);
            }

            bowlingGame.RollBall(1);
            bowlingGame.RollBall(9);

            bowlingGame.RollBall(10);
            Assert.AreEqual(20, bowlingGame.GetScore());
        }

        [Test]
        public void MixedGame_ExpectBonusOfAMixOfStrikesAndSpares()
        {
            bowlingGame.RollBall(10);

            bowlingGame.RollBall(8);
            bowlingGame.RollBall(2);

            bowlingGame.RollBall(5);
            bowlingGame.RollBall(1);

            bowlingGame.RollBall(10);

            bowlingGame.RollBall(2);
            bowlingGame.RollBall(2);

            bowlingGame.RollBall(7);
            bowlingGame.RollBall(0);

            bowlingGame.RollBall(8);
            bowlingGame.RollBall(0);

            bowlingGame.RollBall(8);
            bowlingGame.RollBall(2);

            bowlingGame.RollBall(10);

            bowlingGame.RollBall(10);

            bowlingGame.RollBall(2);
            bowlingGame.RollBall(1);

            Assert.AreEqual(129, bowlingGame.GetScore());
        }
    }
}