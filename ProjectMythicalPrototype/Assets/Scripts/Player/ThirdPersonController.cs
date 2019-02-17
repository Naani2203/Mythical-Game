﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public GameObject GroundSensor;
    private Rigidbody _Rigidbody;

    public bool Interact;

    [Header("Audio")]
    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _Phrase01;

    [Header("Movement")]
    [SerializeField]
    protected float _MoveSpeed = 6f;
    private Vector3 _MoveInput;
    private Vector3 _RotationalInput;
    private Vector3 _Rotation;
    private Vector3 _MoveForward;
    private Vector3 _MoveSideways;
    public static bool _CanMove;
    public static bool CanMoveJumpPad;


    [Header("Jump")]
    [SerializeField] protected float _JumpVelocity = 7f;
    [SerializeField] protected float _FallMltiplier = 2.5f;
    [SerializeField] protected float _Smoothtime = 2.5f;
    protected float _GroundSensorRadius = 0.8f;
    private bool _CanJump = false;
    private bool _IsGrounded;
    private bool _IsJumping;
    private bool _IsJumpPad = false;
    private Vector3 _V;
    private Vector3 _Velocity;
    private Vector3 _MVelocity;

    //Values for animations:
    private bool _IsAlive;
    private bool _IsHurt;

    //Camera
    private Transform _CamTransform;
    private Vector3 _CamTemp;

    //Health
    private ActorHealth _Health;
    private Animator _Anim;

    protected void Start()
    {
        _Health = GetComponent<ActorHealth>();
        _Rigidbody = GetComponent<Rigidbody>();
        _Anim = GetComponent<Animator>();
        _CamTransform = Camera.main.transform;
        _Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _IsAlive = true;
        _Audio.clip = _Phrase01;
        _Audio.Play();
        Interact = false;
        _CanMove = true;
    }

    private void Update()
    {
        //-------------------------------- MOVEMENT---------------------------------------------
        _MoveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _MoveForward = _MoveInput.x * transform.forward;
        _MoveSideways = _MoveInput.z * transform.right;
        _RotationalInput = new Vector3(Input.GetAxisRaw("RHorizontal"), 0.0f, 0);

        //-------------------------------- CAMERA---------------------------------------------
        _CamTemp = _CamTransform.TransformVector(_MoveInput).normalized;
        _CamTemp = new Vector3(_CamTemp.x, 0f, _CamTemp.z);

        //-------------------------------- GROUND CHECK---------------------------------------------
        Collider[] contactColliders = Physics.OverlapSphere(GroundSensor.transform.position, _GroundSensorRadius);
        //-------------------------------- JUMPPAD ---------------------------------------------
        if (contactColliders.Length > 2 && _IsJumpPad == false)
        {
            _IsGrounded = true;
            _Velocity.y = 0;
            CanMoveJumpPad = true;
            _IsJumping = false;
            JumpPad._IsJumpPadd = false;
        }
        else
        {
            _IsGrounded = false;
            CanMoveJumpPad = false;
        }

        //-------------------------------- JUMP ---------------------------------------------
        if (Input.GetButtonDown("Jump"))
        {
            if (_IsGrounded == true)
            {
                _CanJump = true;
            }
        }

        if (_Rigidbody.velocity.y < 0)
        {
            _Rigidbody.velocity += Vector3.up * Physics.gravity.y * (_FallMltiplier - 1) * Time.deltaTime;
        }


        //-------------------------------- ANIMATION VALUES ---------------------------------------------
        SetAnimValues();
        _IsAlive = _Health.IsAlive;
        _IsHurt = _Health.IsHurt;

        //-------------------------------- INTERACT ---------------------------------------------
        if (Input.GetKeyDown("joystick button 3") == true)
        {
            _Anim.SetTrigger("Interact");
            Debug.Log("interact triggered");
            if (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Interact") == false)
            {
                Interact = false;
            }
        }

        if (_IsAlive == true
            && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Interact") == false)
            && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("ProjectileAttack") == false)
            && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") == false)
            && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack02") == false)
            && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack03") == false))
        {
            _CanMove = true;
        }
        else
        {
            _CanMove = false;
        }

        //-------------------------------- NO ROTATION AND MOVEMENT ON ACTIONS---------------------------------------------
        if (_CanMove && _MoveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_CamTemp * -1 * Time.deltaTime), 0.15F);
        }
        else
        {
            transform.Rotate(Vector3.zero);
        }

        //-------------------------------- NO MOVEMENT ON DEATH OR INTERACT ---------------------------------------------
        if (_CanMove)
        {
            _Rigidbody.constraints &= ~RigidbodyConstraints.FreezePosition;
            _Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            _Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void FixedUpdate()
    {
        //-------------------------------- MOVEMENT ---------------------------------------------
        if (_MoveInput != Vector3.zero)
        {
            _Velocity = _CamTemp * _MoveSpeed * -1;

        }
        _Velocity = new Vector3(Mathf.Clamp(_CamTemp.x * _MoveSpeed * -1, -_MoveSpeed, _MoveSpeed), _CanJump ? _JumpVelocity : _Rigidbody.velocity.y, Mathf.Clamp(_CamTemp.z * _MoveSpeed * -1, -_MoveSpeed, _MoveSpeed));

        _Rigidbody.velocity = _Velocity;

        //-------------------------------- JUMPING ---------------------------------------------
        if (_MoveInput == Vector3.zero)
        {
            _V = _Rigidbody.velocity;

            if (_IsGrounded == true || _IsJumpPad == true)
            {
                _V.x *= 0f;
                _V.z *= 0f;

                _Rigidbody.velocity = _V;
            }
        }
        if (JumpPad._IsJumpPadd == true)
        {
            _Velocity.y = Mathf.Clamp(_Rigidbody.velocity.y, -_JumpVelocity, _JumpVelocity);

        }

        if (_CanJump == true && JumpPad._IsJumpPadd == false)
        {
            _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, _JumpVelocity, _Rigidbody.velocity.z);
            _Velocity.y = _JumpVelocity;
            _CanJump = false;
            _IsJumping = true;

        }
    }


    //-------------------------------- ANIMATION VALUES ---------------------------------------------
    private void SetAnimValues()
    {
        _Anim.SetFloat("SideMovement", _MoveInput.z * _MoveSpeed);
        _Anim.SetFloat("ForwardMovement", _MoveInput.x * _MoveSpeed);
        _Anim.SetFloat("SpeedMult", _MoveSpeed);
        _Anim.SetBool("IsAlive", _IsAlive);
        _Anim.SetBool("IsGrounded", _IsGrounded);
        _Anim.SetFloat("Velocity", _Velocity.y);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _Health.Damage(5);
            _Rigidbody.AddForce(other.gameObject.transform.forward * -4000f);
            _Anim.SetTrigger("IsHurt");
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
}
