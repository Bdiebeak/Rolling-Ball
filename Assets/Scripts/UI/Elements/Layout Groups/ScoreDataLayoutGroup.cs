using RollingBall.Game.Score;

namespace RollingBall.UI
{
    public class ScoreDataLayoutGroup : CustomLayoutGroup<ScoreData, ScoreDataFiller>
    {
        protected override void OnElementCreated(ScoreDataFiller element, ScoreData data) => element.UpdateText(data);
    }
}