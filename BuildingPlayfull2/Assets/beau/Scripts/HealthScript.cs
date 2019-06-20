using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float damage;
    public GameObject blackScreen;
    public GameObject youDied;
    public Animator animator;
    public Animator CharacterAnimator;
    public GameObject player;


    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("you died");
            youDied.SetActive(true);
            player.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Damage done");
            health -= damage;
            animator.SetTrigger("DamageDealt");
            CharacterAnimator.SetTrigger("DamageAni");
        }
    }


}
