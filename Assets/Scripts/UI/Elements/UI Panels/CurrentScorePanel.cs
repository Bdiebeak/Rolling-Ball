using RollingBall.Game.Score;
using TMPro;
using UnityEngine;

namespace RollingBall.UI
{
    public class CurrentScorePanel : CanvasGroupPanel
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        public ScoreCounter scoreCounter;

        private void LateUpdate() => scoreText.SetText($"{scoreCounter.CurrentScore:F2}".Replace(',', '.'));
    }
}