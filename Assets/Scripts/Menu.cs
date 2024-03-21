using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject difficultyPanel;

    public void Play()
    {
        difficultyPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadEassyMode()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDifficultMode()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadEstadistics()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }
}