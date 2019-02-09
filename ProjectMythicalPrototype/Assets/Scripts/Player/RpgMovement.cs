using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgMovement : MonoBehaviour
{
    [SerializeField]
    protected float _MoveSpeed = 5f;
    [SerializeField]
    protected KeyCode _JumpKey = KeyCode.Space;
    [SerializeField]
    protected float _JumpSpeed = 12f;

    private Rigidbody _RB;
    private float _ZInput;
    private float _XInput;
    private bool _JumpPressed;


    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
       
    }
    private void Update()
    {
        ReadMoveInputs();
        MouseBasedRotations();
    }

    private void FixedUpdate()
    {
        ApplyMovePhysics();
    }


    private void ReadMoveInputs()
    {
        _ZInput = Input.GetAxis("Vertical");
        _XInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(_JumpKey))
        {
            _JumpPressed = true;
        }
    }

    private void MouseBasedRotations()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0f, mouseX, 0f);    
    }

    private void ApplyMovePhysics()
    {
        var newVel = new Vector3(_XInput, 0, _ZInput) * _MoveSpeed;
        newVel = transform.TransformVector(newVel);


        newVel.y = _JumpPressed ? _JumpSpeed : _RB.velocity.y;
        _RB.velocity = newVel;
        _JumpPressed = false;
    }

}
