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

    private Vector3 _OffsetX;
    private Vector3 _OffsetY;

    void Start()
    {
        _OffsetX = new Vector3(0 , _HeightOffset , _DistanceOffset);
        _OffsetY = new Vector3(0, 0, _DistanceOffset);

    }

    void LateUpdate()
    {
      
        _OffsetX = Quaternion.AngleAxis(Input.GetAxis("RHorizontal") * _TurnSpeed, Vector3.up) *_OffsetX ;
        _OffsetY = Quaternion.AngleAxis(Input.GetAxis("RVertical") * _TurnSpeed, Vector3.right) * _OffsetY;
        transform.position = _Player.position + _OffsetX ;
        transform.LookAt(_Player.position);
    }
}

