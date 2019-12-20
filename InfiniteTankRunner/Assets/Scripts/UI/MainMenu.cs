using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayGameForest()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelOneForest()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwoDesert()
    {
        SceneManager.LoadScene(2);
    }
}