using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollingBall.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupPanel : MonoBehaviour
    {
        [Tooltip("Should be assigned in Panel which can be closed by button. Can be null.")]
        [SerializeField] private Button closeButton;
        private CanvasGroup _canvasGroup;

        public event Action activated;
        public event Action deactivated;

        private void Awake() => InitializeCanvasGroup();
        private void InitializeCanvasGroup() => _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable() => SubscribeOnRequiredEvents();
        private void SubscribeOnRequiredEvents()
        {
            if (closeButton) closeButton.onClick.AddListener(DeactivateCanvasGroup);
        }

        private void OnDisable() => UnsubscribeOnRequiredEvents();
        private void UnsubscribeOnRequiredEvents()
        {
            if (closeButton) closeButton.onClick.RemoveListener(DeactivateCanvasGroup);
        }

        [ContextMenu("Activate")]
        public void ActivateCanvasGroup()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            
            activated?.Invoke();
        }

        [ContextMenu("Deactivate")]
        public void DeactivateCanvasGroup()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            
            deactivated?.Invoke();
        }
    }
}