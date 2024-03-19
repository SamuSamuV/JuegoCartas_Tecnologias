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

    public void eassyMode()
    {
        SceneManager.LoadScene(1);
    }

    public void difficultMode()
    {
        SceneManager.LoadScene(1);

    }
}