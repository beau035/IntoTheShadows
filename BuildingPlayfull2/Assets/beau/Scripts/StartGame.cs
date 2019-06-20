using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject spawner;
    public Animator animator;
    public GameObject blackScreen;

    public void BeginGame()
    {
        Debug.Log("start");
        player.SetActive(true);
        spawner.SetActive(true);
        Destroy(blackScreen);

    }
}
