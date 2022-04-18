using System;

namespace RollingBall.Game.Score
{
    [Serializable] 
    public struct ScoreData
    {
        public float Score { get; private set; }
        public DateTime DateTime { get; private set; }

        public ScoreData(float score, DateTime dateTime)
        {
            Score = score;
            DateTime = dateTime;
        }
    }
}