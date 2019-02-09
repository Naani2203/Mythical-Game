using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPatrol : StateMachineBehaviour
{
    public List<Transform> movementPoints;
    
    private Transform _Enemy;
    [SerializeField]
    private float _Speed;
    private int i;
   
    private float distance = 1;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        i = 0;
        _Enemy = animator.gameObject.GetComponent<Transform>();
        movementPoints = animator.gameObject.GetComponent<FlyingGuy>().movementPoints;
        animator.SetBool("isPatrol", true);
       
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isPatrol") == true)
        {
            if (Vector3.Distance(movementPoints[i].position, _Enemy.position) < distance)
            {
                i++;
                if (i >= movementPoints.Count)
                {
                    i = 0;
                }
            }
           
            _Enemy.position = Vector3.MoveTowards(_Enemy.position, movementPoints[i].position, _Speed * Time.deltaTime);
        }
    }

}
