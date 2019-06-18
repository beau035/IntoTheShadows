using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHit : MonoBehaviour
{
    public GameObject Hit;
    public Rigidbody rb;

   
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enviroment")
            {
                Debug.Log(Hit);
                Destroy(gameObject);
                Instantiate(Hit, transform.position, transform.rotation);
        }

            if (other.tag == "Enemy")
            {
                Debug.Log(Hit);
                Destroy(gameObject);
                Instantiate(Hit, transform.position, transform.rotation);
            }

        }

}

