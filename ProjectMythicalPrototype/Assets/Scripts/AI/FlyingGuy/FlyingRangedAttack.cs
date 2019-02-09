using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRangedAttack : StateMachineBehaviour
{
    [SerializeField]
    private float _Speed;
    private GameObject _Bullet;
    private Transform _Player;
    private Vector3 _Target;
    private Transform _FirePos;
    private Vector3 _FlyPos;
    private AudioSource _Audio;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _Audio = animator.gameObject.GetComponent<AudioSource>();
        _Player = GameObject.Find("Player").transform;
        _Bullet = animator.gameObject.GetComponent<FlyingGuy>().Projectile;
        _Target = _Player.transform.position;
        _FirePos = animator.gameObject.GetComponent<FlyingGuy>().firePos;
        animator.gameObject.GetComponent<FlyingGuy>().target = _Target;
        _Audio.Play();
        Instantiate(_Bullet, _FirePos.position, Quaternion.identity);
       
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isRangedAttack", false);
	}

}
