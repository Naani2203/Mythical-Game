using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float _MoveSpeed = 6f;
    private Vector3 _MoveInput;
    private float _Vertical;
    private float _Horizontal;

    [Header("Jump")]
    [SerializeField] private float _JumpVelocity = 7f;
    [SerializeField] private float _FallMltiplier = 2.5f;
    //[SerializeField] private float _MaxVelocity = 2.5f;
    [SerializeField] private float _LowJumpModifier = 2.5f;
    [SerializeField] private float _Smoothtime = 2.5f;


    public GameObject GroundSensor;
    private Rigidbody _Rigidbody;
   
    private bool _CanJump = false;
    private Transform _CamTransform;
    private Vector3 _CamTemp;
    private float _GroundSensorRadius = 0.09f;

    private Vector3 _V;
    private Vector3 _Mv;
    private Vector3 _Velocity;
    private bool _IsGrounded;
    private bool _CanMove;
    private bool _IsJumping;
    private bool _IsJumpPad=false;
    private Vector3 _MVelocity;

    private ActorHealth _Health;


    protected void Start()
    {
        _Health = GetComponent<ActorHealth>();
        _Rigidbody = GetComponent<Rigidbody>();

        _CamTransform = Camera.main.transform;
    }

    private void Update()
    {
        //----------------------------------------------MOVEMENT----------------------------------------
        if(_CanMove)
        {
        _MoveInput = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;

        }

        _CamTemp = _CamTransform.TransformVector(_MoveInput).normalized;
        _CamTemp = new Vector3(_CamTemp.x, 0f, _CamTemp.z);
        

        Collider[] contactColliders = Physics.OverlapSphere(GroundSensor.transform.position , _GroundSensorRadius);   
       
            if (contactColliders.Length>2 && _IsJumpPad == false)
            {
                _IsGrounded = true;
                _CanMove = true;
                _IsJumping = false;
                
            }
            else
            {
                _IsGrounded = false;
            }


        if (_MoveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_MoveInput), 0.15F);
        }

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (_IsGrounded==true)
            {
                _CanJump = true;

            }
        }
        if (_Rigidbody.velocity.y < 0)
        {
            _Rigidbody.velocity += Vector3.up * Physics.gravity.y * (_FallMltiplier - 1) * Time.deltaTime;
        }
        if (_Rigidbody.velocity.y > 0 && _IsJumping == false && _IsJumpPad ==false)
        {
            _Rigidbody.velocity += Vector3.up * Physics.gravity.y * (_LowJumpModifier - 1) * Time.deltaTime;
        }
        #endregion Jump

        Debug.Log("Player isGrounded = " + _IsGrounded);
    }

    private void FixedUpdate()
    {   
        if (_MoveInput != Vector3.zero)
        {
          
            _Velocity = _CamTemp * _MoveSpeed ;
            _Rigidbody.velocity = Vector3.SmoothDamp(_Rigidbody.velocity, _Velocity, ref _MVelocity, _Smoothtime);         
        }
            
        if (_MoveInput == Vector3.zero)
        {
             _V = _Rigidbody.velocity;

            if (_IsGrounded==true|| _IsJumpPad==true)
            {
                _V.x *= 0.9f;
                _V.z *= 0.9f;

                _Rigidbody.velocity = _V;
            }

           
        }

        if (_CanJump==true && _IsJumpPad == false)
        {
            _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, _JumpVelocity, _Rigidbody.velocity.z);
            _CanJump = false;
            _IsJumping = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _Health.Damage(5);
            KnockBack();
        }
       
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "JumpPad")
        {
            
            _IsJumpPad = true;
            _CanJump = false;
            _IsGrounded = false;
            

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag== "JumpPad")
        {
            _IsJumpPad = false;
        }
    }

    private void KnockBack() 
    {
        _Rigidbody.AddForce(_Rigidbody.velocity = Vector3.right * -10);
    }

}
