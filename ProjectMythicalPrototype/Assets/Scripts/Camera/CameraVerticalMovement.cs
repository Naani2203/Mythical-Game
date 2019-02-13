using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalMovement : MonoBehaviour
{
    [SerializeField]
    private float _ClampValue;
    private float _StartPos;
    [SerializeField]
    private float _LookSpeed;
    private void Start()
    {
        _StartPos = transform.position.y;
    }

    void Update ()
    {
	    if(Input.GetAxis("RVertical")!=0)
        {
            transform.Translate(0,_LookSpeed * Time.deltaTime,0);
        }
        Mathf.Clamp(transform.position.y, _StartPos, _ClampValue);
	}
    
	
}
