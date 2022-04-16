using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    MainMenu,
    Level,
}

public static class ScenesLoader
{
    public static void Load(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
