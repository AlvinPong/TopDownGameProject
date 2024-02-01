using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string NextScene = "";
    public string CurrentScene = "";
    public string MainMenuScene = "";
    public string Map1 = "";
    public string Map2 = "";
    public string Map3 = "";
    public string Map4 = "";
    public string Map5 = "";

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
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void LaodMap1()
    {
        if (Map1 == "") return;
        SceneManager.LoadScene(Map1);
    }
    public void LaodMap2()
    {
        if (Map2 == "") return;
        SceneManager.LoadScene(Map2);
    }
    public void LaodMap3()
    {
        if (Map3 == "") return;
        SceneManager.LoadScene(Map3);
    }
    public void LaodMap4()
    {
        if (Map4 == "") return;
        SceneManager.LoadScene(Map4);
    }
    public void LaodMap5()
    {
        if (Map5 == "") return;
        SceneManager.LoadScene(Map5);
    }
}
