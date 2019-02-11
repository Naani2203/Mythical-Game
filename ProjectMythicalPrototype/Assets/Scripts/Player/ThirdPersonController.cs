using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public GameObject GroundSensor;
    private Rigidbody _Rigidbody;

    public bool Interact;

    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _HoovesSFX;
    [SerializeField]
    private AudioClip _JumpSFX;
    [SerializeField]
    private AudioClip _LandSFX;
    [SerializeField]
    private AudioClip _Phrase01;

    [Header("Movement")]
    [SerializeField] protected float _MoveSpeed = 6f;
    private Vector3 _MoveInput;
    private Vector3 _RotationalInput;
    private Vector3 _Rotation;
    private Vector3 _MoveForward;
    private Vector3 _MoveSideways;
    public static bool _CanMove;

    [Header("Jump")]
    [SerializeField] protected float _JumpVelocity = 7f;
    [SerializeField] protected float _FallMltiplier = 2.5f;
    //[SerializeField] protected float _LowJumpModifier = 2.5f;
    [SerializeField] protected float _Smoothtime = 2.5f;
    protected float _GroundSensorRadius = 0.3f;
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
    }


    private void Update()
    {

        _MoveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _MoveForward = _MoveInput.x * transform.forward;
        _MoveSideways = _MoveInput.z * transform.right;
        _RotationalInput = new Vector3(Input.GetAxisRaw("RHorizontal"), 0.0f, 0);


        _CamTemp = _CamTransform.TransformVector(_MoveInput).normalized;
        _CamTemp = new Vector3(_CamTemp.x, 0f, _CamTemp.z);


        Collider[] contactColliders = Physics.OverlapSphere(GroundSensor.transform.position, _GroundSensorRadius);


        if (contactColliders.Length > 2 && _IsJumpPad == false)
        {
            _IsGrounded = true;
            _Velocity.y = 0;
            _CanMove = true;
            _IsJumping = false;
            JumpPad._IsJumpPadd = false;
        }
        else
        {
            _IsGrounded = false;
            _CanMove = false;
        }


        if (_MoveInput != Vector3.zero && _IsAlive == true && (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Interact") == false))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_CamTemp * -1), 0.15F);
            _Audio.clip = _HoovesSFX;
            _Audio.Play();
        }
        else
        {
            transform.Rotate(Vector3.zero);
        }

        #region Jump

        if (Input.GetButtonDown("Jump"))
        {
            if (_IsGrounded == true)
            {
                _CanJump = true;
                _Audio.clip = _JumpSFX;
                _Audio.Play();
            }
        }

        if (_Rigidbody.velocity.y < 0)
        {
            _Rigidbody.velocity += Vector3.up * Physics.gravity.y * (_FallMltiplier - 1) * Time.deltaTime;
        }

        //if (_Rigidbody.velocity.y > 1 && JumpPad._IsJumpPadd == false)
        //{
        //    _Rigidbody.velocity += Vector3.up * Physics.gravity.y * (_LowJumpModifier - 1) * Time.deltaTime;
        //}

        #endregion Jump

        SetAnimValues();
        _IsAlive = _Health.IsAlive;
        _IsHurt = _Health.IsHurt;

        if (Input.GetKeyDown("joystick button 3") == true)
        {
            _Anim.SetTrigger("Interact");
            Debug.Log("interact triggered");
            if (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Interact") == false)
            {
                Interact = false;
            }
        }


        if ((_Anim.GetBool("IsAlive") == false && _IsGrounded == true) || (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Interact") == true))
        {
            _Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            _Rigidbody.constraints &= ~RigidbodyConstraints.FreezePosition;
            _Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }


    private void FixedUpdate()
    {
        if (_MoveInput != Vector3.zero)
        {
            _Velocity = _CamTemp * _MoveSpeed * -1;

        }
        _Velocity = new Vector3(Mathf.Clamp(_CamTemp.x * _MoveSpeed * -1, -_MoveSpeed, _MoveSpeed), _CanJump ? _JumpVelocity : _Rigidbody.velocity.y, Mathf.Clamp(_CamTemp.z * _MoveSpeed * -1, -_MoveSpeed, _MoveSpeed));
        
        _Rigidbody.velocity = _Velocity;

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
            //_Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, _JumpVelocity, _Rigidbody.velocity.z);
            // _Velocity.y = _JumpVelocity;
            _CanJump = false;
            _IsJumping = true;

        }
    }
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
            KnockBack();
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


    private void KnockBack()
    {
        _Rigidbody.AddForce(_Rigidbody.velocity = Vector3.right * -10);
    }
}
