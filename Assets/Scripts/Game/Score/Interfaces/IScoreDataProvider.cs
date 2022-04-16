using System.Collections.Generic;

namespace RollingBall.Game.Score
{
    public interface IScoreDataProvider
    {
        public IEnumerable<ScoreData> Load();
        public void Save(IEnumerable<ScoreData> data);
    }
}