
namespace bowling_challenge.Models
{
    public class Frame
    {
        private readonly int numberOfPins = 10;
        private readonly int numberOfFrames = 10;
        private int rollNumber;

        public Frame(int frameNumber)
        {
            rollNumber = 1;
            FrameNumber = frameNumber;
            KnockedPinsByRollNumber = new Dictionary<int, int>();
        }

        public int FrameNumber { get; private set; }
        public Dictionary<int, int> KnockedPinsByRollNumber { get; private set; }

        public IEnumerable<int> ListOfRolls => KnockedPinsByRollNumber.Select(x => x.Value);
        public bool IsAllowedToRollAgain => (!AllPinsHaveBeenKnocked && rollNumber <= 2) || NeedThirdRollForBonus;
        public bool IsStrike => ListOfRolls.Take(1).Sum() == numberOfPins;
        public bool IsSpare => ListOfRolls.Take(2).Sum() == numberOfPins && ListOfRolls.Count() == 2;

        public void KnockDownPins(int knockedPins)
        {
            KnockedPinsByRollNumber.Add(rollNumber, knockedPins);
            rollNumber++;
        }

        private bool IsLastFrame => FrameNumber == numberOfFrames;
        private bool NeedThirdRollForBonus => IsLastFrame && (IsSpare || IsStrike) && rollNumber <= 3;
        private bool AllPinsHaveBeenKnocked => KnockedPinsByRollNumber.Sum(x => x.Value) >= 10;
    }
}
