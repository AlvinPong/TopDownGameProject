using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string NextScene = "";
    public string CurrentScene = "";
    public string MainMenuScene = "";

    public void NextLevel()
    {
        if (NextScene == "") return;
        SceneManager.LoadScene(NextScene);
    }
    public void MainMenu()
    {
        if (MainMenuScene == "") return;
        SceneManager.LoadScene(MainMenuScene);
    }
    public void Retry()
    {
        if (CurrentScene == "") return;
        SceneManager.LoadScene(CurrentScene);
    }
}
