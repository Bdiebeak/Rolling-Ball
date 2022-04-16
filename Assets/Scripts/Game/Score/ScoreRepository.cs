using System.Collections.Generic;
using System.Linq;

namespace RollingBall.Game.Score
{
    public class ScoreRepository : IScoreRepository
    {
        private List<ScoreData> _scoreList = new List<ScoreData>();
        private IScoreDataProvider _dataProvider;

        public ScoreRepository(IScoreDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Initialize();
        }

        private void Initialize() => _scoreList = _dataProvider.Load().ToList();

        public void Add(ScoreData element)
        {
            _scoreList.Add(element);
            _dataProvider.Save(_scoreList);
        }

        public IEnumerable<ScoreData> GetAll() => _scoreList;
    }
}