using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTakeoff : StateMachineBehaviour
{
    private Transform _Enemy;
    private float _Delay;
   
    public float _DelayTime;
    private float _Height;
    public float takeoffSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        _Enemy = animator.gameObject.transform;
        _Height = animator.gameObject.GetComponent<FlyingGuy>().flyingHeight;

    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _Enemy.position = Vector3.MoveTowards(_Enemy.position, new Vector3 (_Enemy.position.x,_Height, _Enemy.position.z),takeoffSpeed*Time.deltaTime);
        if(_Enemy.position.y == _Height)
        {
            animator.SetBool("isTakeoff", false);
        }
        if (_Delay < _DelayTime)
        {
            _Delay += Time.deltaTime;

        }
        if (_Delay >= _DelayTime)
        {
            animator.SetBool("isTakeoff", false);
            _Delay = 0;
        }
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
