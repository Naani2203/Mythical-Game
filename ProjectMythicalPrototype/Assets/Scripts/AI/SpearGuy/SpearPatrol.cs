using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpearPatrol : StateMachineBehaviour {

    public List<Transform> movementPoints;
   
    private Transform _Enemy;
    public float _Speed;
    private int _I;
    private NavMeshAgent _NavAgent;
    private float _Distance = 1;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _I = 0;
        _Enemy = animator.gameObject.GetComponent<Transform>();
     
        _NavAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        movementPoints = animator.gameObject.GetComponent<Spearguy>().movementPoints;
        animator.SetBool("isPatrol", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isPatrol") == true)
        {
            if (Vector3.Distance(movementPoints[_I].position, _Enemy.position) < _Distance)
            {
                _I++;
                if (_I >= movementPoints.Count)
                {
                    _I = 0;
                }
            }
            _NavAgent.SetDestination(movementPoints[_I].position);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPatrol", false);
    }

}
