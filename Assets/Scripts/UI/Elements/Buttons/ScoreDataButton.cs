using RollingBall.Game.Score;
using TMPro;
using UnityEngine;

namespace RollingBall.UI
{
    public class ScoreDataButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI dateText;

        public void UpdateText(ScoreData newData)
        {
            scoreText.SetText($"SCORE {newData.Score:F2}".Replace(',', '.'));
            dateText.SetText($"DATE {newData.DateTime.ToShortDateString()}");
        }
    }
}