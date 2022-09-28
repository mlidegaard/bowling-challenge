namespace bowling_challenge.Models
{
    public class BowlingGame
    {
        private readonly int numberOfFramesToPlay = 10;
        private ScoreBoard scoreBoard = new ScoreBoard();
        private List<Frame> frames = new List<Frame>();

        public BowlingGame()
        {
            FrameNumber = 1;
            InitialiseFrames();
        }

        public int FrameNumber { get; private set; }
        public bool CanContinueToNextFrame => FrameNumber < numberOfFramesToPlay + 1;

        public void RollBall(int knockedPins)
        {
            CurrentFrame.KnockDownPins(knockedPins);

            if (!CurrentFrame.IsAllowedToRollAgain)
            {                
                FrameNumber++;
            }
        }

        public int GetScore()
        {
            var framesThatHaveRolls = frames.Where(x => x.ListOfRolls.Count() > 0);
            return scoreBoard.CalculateScore(framesThatHaveRolls);
        }

        private Frame CurrentFrame => frames[FrameNumber - 1];

        private void InitialiseFrames()
        {
            for (int i = 0; i < numberOfFramesToPlay; i++)
            {
                frames.Add(new Frame(i + 1));
            }
        }
    }
}
