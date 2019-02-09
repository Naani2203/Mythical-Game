using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafOpened : StateMachineBehaviour
{

  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<LeafBehaviour>().LeafOpened();
        
    }


}
