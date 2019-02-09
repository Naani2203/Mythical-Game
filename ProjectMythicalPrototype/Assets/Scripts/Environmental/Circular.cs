using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    [SerializeField]
    private float _Speed;
    [SerializeField]
    private float _Width;
    [SerializeField]
    private float _Depth;
    private float _RealSpeed;

	void Update ()
    {
        _RealSpeed += Time.deltaTime * _Speed;

        float x = Mathf.Sin(_RealSpeed)*_Width;
        float y = transform.position.y;
        float z = Mathf.Cos(_RealSpeed)*_Depth;
        transform.position = new Vector3(x, y, z);
	}
}
