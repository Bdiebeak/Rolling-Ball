using RollingBall.Game.SceneLoader;
using UnityEngine;
using UnityEngine.UI;

namespace RollingBall.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        private void OnEnable()
        {
            startButton.onClick.AddListener(StartButtonClickHandler);
        }
        
        private void OnDisable()
        {
            startButton.onClick.RemoveListener(StartButtonClickHandler);
        }

        private void StartButtonClickHandler()
        {
            ScenesLoader.Load(Scenes.Level);
        }
    }
}