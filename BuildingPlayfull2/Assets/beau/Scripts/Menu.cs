using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Eigen geschreven script. Dit is voor de play button zodat het spel begint zodra je erop klikt.

public class Menu : MonoBehaviour
{
    public Animator animator;


    public void StartGame()
    {
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeCompleted()
    {

        SceneManager.LoadScene("Level 1");

    }
}