using RollingBall.Game.Score;
using RollingBall.Helpers.Patterns;

namespace RollingBall.Helpers
{
    public class UnitOfWork : MonoBehaviourSingleton<UnitOfWork>
    {
        private IScoreRepository _scoreRepository;

        public IScoreRepository ScoreRepository => _scoreRepository;

        public override void Awake()
        {
            base.Awake();
            
            var scoreDataProvider = new ScorePlayerPrefsProvider();
            _scoreRepository = new ScoreRepository(scoreDataProvider);
        }
    }
}