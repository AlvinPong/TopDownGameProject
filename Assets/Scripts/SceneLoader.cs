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
    public string Map6 = "";
    public string DeathScene = "";
    public string VictoryScene = "";

    private SecondScene _secondScene;

    private ScoreManager _scoreManager;

    public int Cost = 100;
    private void Start()
    {
        _secondScene = GetComponent<SecondScene>();

        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }
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

    public void LoadMap1()
    {
        if (Map1 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map1);
    }
    public void LoadMap2()
    {
        if (Map2 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map2);
        _scoreManager.CoinAmount -= Cost;
    }
    public void LoadMap3()
    {
        if (Map3 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map3);
        _scoreManager.CoinAmount -= Cost;
    }
    public void LoadMap4()
    {
        if (Map4 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map4);
        _scoreManager.CoinAmount -= Cost;
    }
    public void LoadMap5()
    {
        if (Map5 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map5);
        _scoreManager.CoinAmount -= Cost;
    }

    public void LoadMap6()
    {
        if (Map6 == "") return;
        _secondScene.SavePlayerStats();
        SceneManager.LoadScene(Map6);
        _scoreManager.CoinAmount -= Cost;
    }

    public void LoadDeathScene()
    {
        if (DeathScene == "") return;
        SceneManager.LoadScene(DeathScene);
    }

    public void LoadVictoryScene()
    {
        if (VictoryScene == "") return;
        SceneManager.LoadScene(VictoryScene);
    }
}
