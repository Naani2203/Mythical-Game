using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFollow : StateMachineBehaviour
{
    private Transform _FlyingGuy;
    private Transform _Player;
    private float _Temp;
    [SerializeField]
    private float _FollowSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _FlyingGuy = animator.gameObject.GetComponent<Transform>();
        _Player = GameObject.Find("Player").transform;
        _Temp = animator.gameObject.GetComponent<FlyingGuy>().flyingHeight; ;
       
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _FlyingGuy.position = Vector3.MoveTowards(_FlyingGuy.position, new Vector3(_Player.position.x, _Temp, _Player.position.z), _FollowSpeed * Time.deltaTime);
        if(_FlyingGuy.position == new Vector3 (_Player.position.x,_Temp,_Player.position.z))
        {
            animator.SetBool("canFollow", false);
        }
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetBool("isInrange")==false)
        {
            animator.SetBool("isSpotted", true);
        }
        else if(animator.GetBool("isInrange")==true)
        {
            animator.SetBool("isDelay", true);
            
        }
	
	}

}
