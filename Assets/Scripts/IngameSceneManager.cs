using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameSceneManager : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
