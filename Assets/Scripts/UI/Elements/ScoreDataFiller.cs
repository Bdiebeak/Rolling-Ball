using RollingBall.Game.Score;
using TMPro;
using UnityEngine;

namespace RollingBall.UI
{
    public class ScoreDataFiller : MonoBehaviour
    {
        public string scoreTextPrefix = "SCORE ";
        [SerializeField] private TextMeshProUGUI scoreText;
        [Space]
        public string dateTextPrefix = "DATE ";
        [SerializeField] private TextMeshProUGUI dateText;

        public void UpdateText(ScoreData newData)
        {
            if (scoreText) scoreText.SetText($"{scoreTextPrefix}{newData.Score:F2}".Replace(',', '.'));
            if (dateText) dateText.SetText($"{dateTextPrefix}{newData.DateTime.ToShortDateString()}");
        }
    }
}