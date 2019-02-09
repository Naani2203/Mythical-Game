using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpearSpotted : StateMachineBehaviour
{

    private Transform _Player;
    private float _Delay, _Delaytime;
    private NavMeshAgent _NavAgent;
    private AudioSource _AudioSource;
    private AudioClip _Scream;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _Delay = 0;
        _AudioSource = animator.gameObject.GetComponent<AudioSource>();
        _Scream = animator.gameObject.GetComponent<Spearguy>().Scream;
        _Player = GameObject.Find("Player").transform;
        _NavAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        _AudioSource.clip = _Scream;
        _Delaytime = animator.gameObject.GetComponent<Spearguy>().attackDelay;
        animator.SetBool("isSpotted", true);
        _AudioSource.Play();
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Spearguy>().target = _Player.position;
        if (_Delay<_Delaytime)
        {
            _Delay += Time.deltaTime;
            _NavAgent.gameObject.transform.rotation = Quaternion.Slerp(_NavAgent.gameObject.transform.rotation, Quaternion.LookRotation(_Player.position),Time.deltaTime);
        }
        if(_Delay>=_Delaytime)
        {
            if (animator.GetBool("isInrange"))
            {
                animator.SetBool("isAttack", true);
            }
            else
            {
                animator.SetBool("isPatrol", true);
            }
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isSpotted", false);
        _Delay = 0;
    }

}
