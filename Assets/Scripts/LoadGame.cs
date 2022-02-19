using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Text choosenLevel;
    [SerializeField] private Text choosenColor;
    [SerializeField] private Text choosenSkin;
    [SerializeField] private Text choosenLives;

    private AnimatorController animatorController;

    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>();
    }

    public void LoadGameScene()
    {
        if (choosenLevel.text == "Easy" && choosenColor.text != "" && choosenSkin.text != "" && choosenLives.text != "")
        {
            SceneManager.LoadScene(3);
        }
        
        else if (choosenLevel.text == "Hard" && choosenColor.text != "" && choosenSkin.text != "" && choosenLives.text != "")
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            StartCoroutine(animatorController.StartAnimationErrorWindow());
        }
    }
    
}
