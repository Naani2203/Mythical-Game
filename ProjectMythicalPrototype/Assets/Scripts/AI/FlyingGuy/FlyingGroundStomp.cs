using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGroundStomp : StateMachineBehaviour
{
    private Transform _FlyingGuy;
    private Vector3 _Player;
    private float _Temp;
    private float _Delay;
    private Rigidbody _Rb;
    private AudioSource _Audio;
    private bool _Check;
    [SerializeField]
    private float _DelayTime;
    [SerializeField]
    private float _GroundStompSpeed;
    [SerializeField]
    private float _GroundStompForce;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _FlyingGuy = animator.gameObject.GetComponent<Transform>();
        _Player = GameObject.Find("Player").transform.position;
        _Temp = animator.gameObject.GetComponent<FlyingGuy>().flyingHeight;
        _Audio = animator.gameObject.GetComponent<AudioSource>();
        _Rb = animator.gameObject.GetComponent<Rigidbody>();
        _Check = true;
        _Audio.PlayDelayed(1);

    }

     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_Check==true)
        {
            _FlyingGuy.position = Vector3.MoveTowards(_FlyingGuy.position, new Vector3(_Player.x, _Temp, _Player.z), _GroundStompSpeed * Time.deltaTime);
        }
        if (_FlyingGuy.position == new Vector3(_Player.x, _Temp, _Player.z))
        {
            _Check = false;
            
        }
        if(_Check==false)
        {
            
            _Rb.AddForce(0, -1 * _GroundStompForce , 0);
        }
        if (_Delay < _DelayTime)
        {
            _Delay += Time.deltaTime;

        }
        if (_Delay >= _DelayTime)
        {
            animator.SetBool("isGroundStomp", false);
            _Delay = 0;
        }
   
     }
    

}
