using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWindowController : MonoBehaviour
{
    [SerializeField] private GameObject endWindow;
    private void Start()
    {
        endWindow.SetActive(false);
    }

    public void ShowEndWindow()
    {
        endWindow.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(3);
        endWindow.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        endWindow.SetActive(false);
    }
}
