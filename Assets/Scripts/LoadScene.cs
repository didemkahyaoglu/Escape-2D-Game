using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static LoadScene instance;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
