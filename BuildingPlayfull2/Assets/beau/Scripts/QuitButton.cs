using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuitButton : MonoBehaviour
{
    public Animator animator;

    public void OnClick()
    {
        animator.SetTrigger("FadeOutQuit");
        Debug.Log("pressed Quit");

    }

    public void OnFadeComplete ()
    {

            Debug.Log("quit");
            Application.Quit();
        
    }
}