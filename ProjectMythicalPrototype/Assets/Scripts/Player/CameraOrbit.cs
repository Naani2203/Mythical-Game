using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField]
    private float _HeightOffset;
    [SerializeField]
    private float _DistanceOffset;
    [SerializeField]
    private float _TurnSpeed ;
    [SerializeField]
    private Transform _Player;
    [SerializeField]
    private float _ClampValue;
    private float _StartPos;

    private Vector3 _OffsetX;
    private Vector3 _OffsetY;

    void Start()
    {
        _OffsetY = new Vector3(0, 0, _DistanceOffset);
        _OffsetX = new Vector3(0 , _HeightOffset , _DistanceOffset);
        _StartPos = _OffsetX.y;
        _ClampValue -= _OffsetX.y;

    }
    private void Update()
    {
      if(Input.GetAxis("RVertical")>0)
        {
            _OffsetX.y = Mathf.Clamp(_OffsetX.y+ _TurnSpeed * Time.deltaTime,_ClampValue, _StartPos); 
        }
        if (Input.GetAxis("RVertical") < 0)
        {
            _OffsetX.y = Mathf.Clamp(_OffsetX.y - _TurnSpeed * Time.deltaTime, _ClampValue, _StartPos);
        }
        if (Input.GetAxis("RVertical") == 0)
        {
            _OffsetX.y = Mathf.Lerp(_OffsetX.y,_StartPos,0.050f);
        }
    }

    void LateUpdate()
    {
        _OffsetX = Quaternion.AngleAxis(Input.GetAxis("RHorizontal") * _TurnSpeed, Vector3.up) *_OffsetX ;
        transform.position = _Player.position + _OffsetX ;
        transform.LookAt(_Player.position);

    }
}

