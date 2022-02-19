using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private GameObject errorWindow;
    [SerializeField] private Animator animator;
    [SerializeField] private Button playButton;

    private void Start()
    {
        errorWindow.SetActive(false);
    }
    
    public IEnumerator StartAnimationErrorWindow()
    {
        StartAnimation();
        yield return new WaitForSeconds(2.75f);
        EndAnimation();
    }

    private void StartAnimation()
    {
        playButton.interactable = false;
        errorWindow.SetActive(true);
        animator.SetBool("IsShow", true);
        animator.SetBool("IsClose", true);
    }

    private void EndAnimation()
    {
        animator.SetBool("IsShow", false);
        animator.SetBool("IsClose", false);
        errorWindow.SetActive(false);
        playButton.interactable = true;
    }
}
