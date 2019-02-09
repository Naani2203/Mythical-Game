using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private Transform _Target;
    [SerializeField]
    private float _JumpForce;
    private float _DisplacementY;
    private Vector3 _DisplacementXZ;
    public static bool _IsJumpPadd;
    private Rigidbody _Rb;
    private Transform _Player;
    private Vector3 _VeloY;
    private Vector3 _VeloXZ;
    private Vector3 _LaunchVelocity;
    [SerializeField]
    private float _H;
    [SerializeField]
    private Animator _Anim;
    private AudioSource _AudioSource;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
       if(_IsJumpPadd==true)
        {
            if (_Player != null)
            {
                //_LaunchVelocity = CalculateLaunchVelocity();
                //_Rb.velocity = _LaunchVelocity;
                //ThirdPersonController._CanMove = false;
                //if ((_Player.position.x - _Target.position.x) <= 2f && (_Player.position.z - _Target.position.z) <= 2f)
                //{
                //    _IsJumpPadd = false;
                //    _Rb.velocity = _Rb.velocity;
                //}
                
                
            }
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Player")
        {
            _Player = collision.gameObject.GetComponent<Transform>();
            _Rb = collision.gameObject.GetComponent<Rigidbody>();
            _Rb.AddForce(transform.up* _JumpForce,ForceMode.Impulse);
            _Anim.SetTrigger("_IsActivated");
            _IsJumpPadd = true;
            _AudioSource.Play();
        }
    }   
        Vector3 CalculateLaunchVelocity()
    {
        if(_Player!=null)
        {

        _DisplacementY = _Target.position.y - _Player.transform.position.y;
        _DisplacementXZ.x = _Target.position.x - _Player.transform.position.x;
        _DisplacementXZ.y = 0;
        _DisplacementXZ.z = (_Target.position.z - _Player.transform.position.z);
        _VeloY = Vector3.up * (Mathf.Sqrt(-2 * 22f * _H));
        _VeloXZ = ( _DisplacementXZ / ((Mathf.Sqrt((-2 * _H / 22f)) + (Mathf.Sqrt(2 * _DisplacementY - _H) / 22f))));
       
        }
        return _VeloY + _VeloXZ;
    }
}
