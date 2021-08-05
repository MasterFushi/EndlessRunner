using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{   

    void Awake()
    {
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void StartMenu() {
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
