using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpearAttack : StateMachineBehaviour
{
    public float attackOffset;
    private float _Temp;
    private Vector3 _Target;
    private float _Speed;
    private NavMeshAgent _Navmeshagent;
    private AudioSource _Source;
    private AudioClip _Dash;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SlowMoController._IsAttackSloMo = true;
        _Target = animator.gameObject.GetComponent<Spearguy>().target;
        _Speed = animator.gameObject.GetComponent<Spearguy>().dashSpeed;
        _Target-= (Vector3.back*attackOffset);
        _Source = animator.gameObject.GetComponent<AudioSource>();
        _Dash = animator.gameObject.GetComponent<Spearguy>().DashClip;
        _Navmeshagent = animator.gameObject.GetComponent<NavMeshAgent>();
        animator.SetBool("isAttack", true);
        _Temp = _Navmeshagent.speed;
        _Source.clip = _Dash;
        _Source.PlayDelayed(0.1f);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (animator.GetBool("isAttack")==true)
      {
            animator.SetBool("isAttack", false);

            _Navmeshagent.speed = _Speed;           
            _Navmeshagent.SetDestination(_Target);
           
       }
        if(animator.gameObject.transform.position == _Target)
        {
            animator.SetBool("isSpotted", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SlowMoController._IsAttackSloMo = false;
        _Navmeshagent.speed = _Temp;
       
    }

}
