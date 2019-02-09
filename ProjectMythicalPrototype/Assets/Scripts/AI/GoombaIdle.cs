using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaIdle : StateMachineBehaviour
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.gameObject.GetComponent<Goombaa>().InRange==true)
        {
            animator.SetBool("isFollow", true);
            
        }
    }


}
