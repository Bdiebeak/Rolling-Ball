using System.Collections.Generic;

namespace RollingBall.Game.Score
{
    public interface IScoreRepository
    {
        public void Add(ScoreData element);
        public IEnumerable<ScoreData> GetAll();
    }
}