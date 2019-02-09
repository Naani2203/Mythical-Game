using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpotted : StateMachineBehaviour
{
    [SerializeField]
    private float _Speed = 10f;

    private Vector3 _FlyPos;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

       

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {   
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isInrange") == true)
        {

            animator.SetBool("isDelay", true);
        }
        else
        {
            animator.SetBool("isPatrol", true);
        }
        animator.SetBool("isSpotted", false);
	
	}

}
