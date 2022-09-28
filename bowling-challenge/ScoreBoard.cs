
namespace bowling_challenge.Models
{
    public class ScoreBoard
    {
        private IEnumerable<Frame> frames = new List<Frame>();

        public int CalculateScore(IEnumerable<Frame> frames)
        {
            this.frames = frames;

            var score = 0;

            foreach (Frame frame in frames)
            {
                if (frame.IsAllowedToRollAgain) // We don't score unfinished frames.
                {
                    score += 0;
                }
                else if (frame.IsSpare || frame.IsStrike)
                {
                    score += CalculateScoreWithBonus(frame);
                }
                else score += frame.KnockedPinsByRollNumber.Sum(x => x.Value);
            }

            return score;
        }

        private int CalculateScoreWithBonus(Frame frame)
        {
            var nextFrame = GetFrameOrNull(frame.FrameNumber + 1);
            var nextNextFrame = GetFrameOrNull(frame.FrameNumber + 2);

            return CalculateScoreWithBonus(frame, nextFrame, nextNextFrame);
        }

        private int CalculateScoreWithBonus(Frame currentFrame, Frame? nextFrame, Frame? nextNextFrame)
        {
            var rolls = new List<int>();

            rolls.AddRange(currentFrame.ListOfRolls);
            rolls.AddRange(nextFrame != default ? nextFrame.ListOfRolls : new List<int>());
            rolls.AddRange(nextNextFrame != default ? nextNextFrame.ListOfRolls : new List<int>());

            if (rolls.Count() >= 3)
            {
                return rolls.Take(3).Sum();
            }

            return 0;
        }

        private Frame? GetFrameOrNull(int frameNumber)
        {
            return (frames.Count() > (frameNumber - 1)) ? frames.ToList()[frameNumber - 1] : null;
        }
    }
}
