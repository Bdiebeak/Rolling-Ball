using UnityEngine.SceneManagement;

namespace RollingBall.Game.SceneLoader
{
    public static class ScenesLoader
    {
        public static void Load(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}