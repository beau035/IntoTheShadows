using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Animator animator;
    public GameObject Bullet;
    public GameObject ShotParticle;
    public float cooldownTime;
    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                    nextFireTime = Time.time + cooldownTime;
                    GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                    Destroy(bullet, 3);
                    GameObject particle = Instantiate(ShotParticle, transform.position, transform.rotation) as GameObject;
                    Destroy(particle, 1);

                    animator.SetTrigger("Attack 0");
            }
        }
    }
}
