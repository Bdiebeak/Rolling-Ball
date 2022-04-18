using RollingBall.Game.Score;
using RollingBall.Helpers.Patterns;

namespace RollingBall.Helpers
{
    public class UnitOfWork : MonoBehaviourSingleton<UnitOfWork>
    {
        public IScoreRepository ScoreRepository { get; private set; }

        public override void Awake()
        {
            base.Awake();
            
            var scoreDataProvider = new ScorePlayerPrefsProvider();
            ScoreRepository = new ScoreRepository(scoreDataProvider);
        }
    }
}