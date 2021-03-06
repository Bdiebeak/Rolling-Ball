using UnityEngine;

namespace RollingBall.Player.Camera
{
    public class CursorBlocker : MonoBehaviour
    {
        [SerializeField] private bool shouldBlockCursor;
        [SerializeField] private bool shouldHideCursor;

        private void OnEnable()
        {
            ChangeCursorBlockedState(shouldBlockCursor);
            ChangeCursorVisibility(shouldHideCursor);
        }

        private void OnDisable()
        {
            ChangeCursorBlockedState(false);
            ChangeCursorVisibility(true);
        }

        public void ChangeCursorBlockedState(bool newState) => Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        public void ChangeCursorVisibility(bool newState) => Cursor.visible = newState;
    }
}