using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
    public float angle;
    public Transform location;
	
	void Update ()
    {
        transform.RotateAround(location.position, Vector3.up, angle * Time.deltaTime);
	}
}
