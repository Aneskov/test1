namespace Ayes.Test.Domain
{
    class Baccarat
    {
        public class ScoreCalculator
        {
            private int _rawScore;

            public int Score
                => _rawScore < 10 ? _rawScore : _rawScore - 10;

            public void Append(ECardValue cardValue)
                => _rawScore += EvaluateScore(cardValue);
        }

        private static int EvaluateScore(ECardValue cardValue) =>
            cardValue switch
            {
                ECardValue.Ace => 1,
                ECardValue.Two => 2,
                ECardValue.Three => 3,
                ECardValue.Four => 4,
                ECardValue.Five => 5,
                ECardValue.Six => 6,
                ECardValue.Seven => 7,
                ECardValue.Eight => 8,
                ECardValue.Nine => 9,
                _ => 0
            };
    }
}
