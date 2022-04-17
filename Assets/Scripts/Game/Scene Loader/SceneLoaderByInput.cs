using RollingBall.Player.Input;
using UnityEngine;

namespace RollingBall.Game.SceneLoader
{
    public class SceneLoaderByInput : MonoBehaviour
    {
        private void Update()
        {
            if (PlayerInputHandler.Instance == null) return;
            
            if (PlayerInputHandler.Instance.RestartLevel) SceneLoader.Restart();
            if (PlayerInputHandler.Instance.ReturnToMainMenu) SceneLoader.Load(Scenes.MainMenu);
        }
    }
}