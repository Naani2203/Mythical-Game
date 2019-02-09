using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    private float _TimeToDestroy;
	// Use this for initialization
	void Start ()
    {
        Destroy(this, _TimeToDestroy);  	
	}

}
