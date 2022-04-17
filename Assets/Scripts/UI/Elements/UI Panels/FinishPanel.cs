using TMPro;
using UnityEngine;

namespace RollingBall.UI
{
    public class FinishPanel : CanvasGroupPanel
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void ChangeScoreText(float newScore) => scoreText.SetText($"{newScore:F2}".Replace(',', '.'));
    }
}