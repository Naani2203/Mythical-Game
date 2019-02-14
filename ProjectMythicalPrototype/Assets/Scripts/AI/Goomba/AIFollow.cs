﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class AIFollow : StateMachineBehaviour
{
    private Transform _Player;
    private NavMeshAgent _NavAgent;
    private AudioSource _Audio;

 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        animator.SetBool("isFollow", true);
        _Player = GameObject.Find("Player").transform;
        _NavAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        _Audio = animator.gameObject.GetComponent<AudioSource>();
        _Audio.clip = animator.gameObject.GetComponent<Goombaa>().AggroSound;
        _Audio.Play();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _NavAgent.SetDestination(_Player.position);
        if(animator.GetComponent<Goombaa>().InRange==false)
        {
        animator.SetBool("isFollow", false);

        }
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

}
