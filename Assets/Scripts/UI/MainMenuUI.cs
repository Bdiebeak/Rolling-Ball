using RollingBall.Game.SceneLoader;
using UnityEngine;
using UnityEngine.UI;

namespace RollingBall.UI
{
    /// <summary>
    /// Something like Mediator for MainMenu.
    /// </summary>
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button recordsButton;
        [SerializeField] private Button infoButton;
        [Space] 
        [SerializeField] private CanvasGroupPanel buttonsPanel;
        [SerializeField] private CanvasGroupPanel recordsPanel;
        [SerializeField] private CanvasGroupPanel infoPanel;
        
        private void OnEnable() => SubscribeOnRequiredEvents();
        private void SubscribeOnRequiredEvents()
        {
            startButton.onClick.AddListener(StartButtonClickHandler);
            recordsButton.onClick.AddListener(RecordsButtonClickHandler);
            infoButton.onClick.AddListener(InfoButtonClickHandler);

            recordsPanel.deactivated += ShowButtonsPanel;
            infoPanel.deactivated += ShowButtonsPanel;
        }

        private void OnDisable() => UnsubscribeOnRequiredEvents();
        private void UnsubscribeOnRequiredEvents()
        {
            startButton.onClick.RemoveListener(StartButtonClickHandler);
            recordsButton.onClick.RemoveListener(RecordsButtonClickHandler);
            infoButton.onClick.RemoveListener(InfoButtonClickHandler);

            recordsPanel.deactivated -= ShowButtonsPanel;
            infoPanel.deactivated -= ShowButtonsPanel;
        }

        private void StartButtonClickHandler() => ScenesLoader.Load(Scenes.Level);
        private void RecordsButtonClickHandler()
        {
            recordsPanel.ActivateCanvasGroup();
            buttonsPanel.DeactivateCanvasGroup();
        }

        private void InfoButtonClickHandler()
        {
            infoPanel.ActivateCanvasGroup();
            buttonsPanel.DeactivateCanvasGroup();
        }

        private void ShowButtonsPanel() => buttonsPanel.ActivateCanvasGroup();
    }
}