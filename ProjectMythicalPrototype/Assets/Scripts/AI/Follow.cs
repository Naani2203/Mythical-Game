using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public float speed;
    public NavMeshAgent NavMeshAgent;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        //Vector3.MoveTowards(transform.position, player.position, speed);
        NavMeshAgent.SetDestination(player.position);
	}
}
