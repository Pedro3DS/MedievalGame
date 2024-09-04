using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Start") && SceneManager.GetActiveScene().name == "StartScene")
        {
            StartCatGame();
        }
        if (Input.GetButtonDown("Start") && SceneManager.GetActiveScene().name == "LoseScene" || SceneManager.GetActiveScene().name == "WinScene")
        {
            RestartGame();
        }
        if (Input.GetButtonDown("Exit"))
        {
            ExitGame();
        }
    }
    public void StartCatGame()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
