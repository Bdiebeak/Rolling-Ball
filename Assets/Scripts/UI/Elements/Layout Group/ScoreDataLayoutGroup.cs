using RollingBall.Game.Score;

namespace RollingBall.UI
{
    public class ScoreDataLayoutGroup : CustomLayoutGroup<ScoreData, ScoreDataButton>
    {
        // WORK TEST
        private IScoreRepository _repository;

        private void Start()
        {
            _repository = new ScoreRepository(new ScorePlayerPrefsProvider());
            RefillLayoutGroup(_repository.GetAll());
        }

        protected override void OnElementCreated(ScoreDataButton element, ScoreData data)
        {
            element.UpdateText(data);
        }
    }
}