using System;

namespace RollingBall.Game.Score
{
    [Serializable] 
    public struct ScoreData
    {
        private float _score;
        private DateTime _dateTime;

        public float Score => _score;
        public DateTime DateTime => _dateTime;

        public ScoreData(float score, DateTime dateTime)
        {
            _score = score;
            _dateTime = dateTime;
        }
    }
}