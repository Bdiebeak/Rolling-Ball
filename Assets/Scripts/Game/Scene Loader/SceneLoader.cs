using UnityEngine.SceneManagement;

namespace RollingBall.Game.SceneLoader
{
    public static class SceneLoader
    {
        public static void Load(Scenes scene) => SceneManager.LoadScene(scene.ToString());
        public static void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}