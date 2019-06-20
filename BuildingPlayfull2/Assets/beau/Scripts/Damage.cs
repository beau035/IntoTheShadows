using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health;
    public float damage;
    public GameObject Death;



    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(Death, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("hit retrieved");
            health -= damage;
            
        }
    }
}
