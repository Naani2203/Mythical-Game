using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public float rollspeed;
    public float rollangle;
    public bool right;
    private Rigidbody _Rb;

    private void Start()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
	    if(right==true)
        {
            _Rb.velocity = new Vector3(rollspeed * Time.deltaTime, 0, 0);
            transform.RotateAround(transform.position, transform.forward, rollangle * Time.deltaTime*-1);
        }
        if (right == false)
        {
            _Rb.velocity = new Vector3(rollspeed * Time.deltaTime*-1, 0, 0);
            transform.RotateAround(transform.position, transform.forward, rollangle * Time.deltaTime );
        }
    }
}
