using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public float turnSpeed;
    public Rigidbody rb;
    public Animator animator;
    public Component audioScource;
    public float currentSpeed = 0;
    public bool isWalking;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioScource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        HandleRotationTnput();

        if(currentSpeed > 0)
        {
            isWalking = true;
            currentSpeed -= 0.9f;
        }

        else
        {
            isWalking = false;
        }

        if(currentSpeed >= 1)
        {
            currentSpeed = 1;
        }

        if (rb.velocity.magnitude < maxSpeed)
        {
            if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey("w")))
            {
                rb.AddForce(0, 0, speed, ForceMode.Impulse);
                animator.SetBool("IsWalking", true);
                GetComponent<AudioSource>().enabled = true;
                currentSpeed += 1f;
            }

            if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey("s")))
            {
                rb.AddForce(0, 0, -speed, ForceMode.Impulse);
                animator.SetBool("IsWalking", true);
                GetComponent<AudioSource>().enabled = true;
                currentSpeed += 1f;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey("a")))
            {
                rb.AddForce(-speed, 0, 0, ForceMode.Impulse);
                animator.SetBool("IsWalking", true);
                GetComponent<AudioSource>().enabled = true;
                currentSpeed += 1f;
            }

            if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey("d")))
            {
                rb.AddForce(speed, 0, 0, ForceMode.Impulse);
                animator.SetBool("IsWalking", true);
                GetComponent<AudioSource>().enabled = true;
                currentSpeed += 1f;
            }
            
            if(!isWalking)
            {
                animator.SetBool("IsWalking", false);
                GetComponent<AudioSource>().enabled = false;
            }
        }
    }


    void HandleRotationTnput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }
}
