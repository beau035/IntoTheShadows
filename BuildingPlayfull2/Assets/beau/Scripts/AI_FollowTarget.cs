using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_FollowTarget : MonoBehaviour
{
    public GameObject Player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Player.transform.position;
    }
}
// if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)