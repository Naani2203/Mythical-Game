using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDelay : StateMachineBehaviour
{
    [SerializeField]
    private float _Speed;
    private Vector3 _FlyPos;
    private float _RandCheck;
    private float _Delay;
    private float _DelayTime;
    private Transform _Player;
    private GameObject _PlayerGO;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _PlayerGO = GameObject.Find("Player");
        _Player = _PlayerGO.transform;
        
        
        _DelayTime = animator.gameObject.GetComponent<FlyingGuy>().attackDelay;
        _RandCheck = Random.Range(1, 10);
        if (_RandCheck <= 4)
        {
            animator.SetBool("isRangedAttack", true);
            animator.gameObject.GetComponent<FlyingGuy>().target = _Player.position;
        }
        else if (_RandCheck >= 5)
        {
            animator.SetBool("isGroundStomp", true);
            animator.gameObject.GetComponent<FlyingGuy>().target = _Player.position;
        }

        _FlyPos = new Vector3(animator.gameObject.transform.position.x, animator.gameObject.GetComponent<FlyingGuy>().flyingHeight, animator.gameObject.transform.position.z);
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.gameObject.transform.position = Vector3.MoveTowards(animator.gameObject.transform.position, _FlyPos, _Speed);
        if (_Delay < _DelayTime)
        {
            _Delay += Time.deltaTime;
            
        }
        if (_Delay >= _DelayTime)
        {
          

            Debug.Log(_Delay);
            _Delay = 0;
            animator.SetBool("isDelay", false);
        }
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
          
    }
}
