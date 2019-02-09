using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private bool _Original;
    private bool _Swap;

    // Use this for initialization
    void Start ()
    {
        _Original = true;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_Swap==true)
        {
            Swap();
        }
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            
            _Swap = true;
        }
    }

    void Swap()
    {
        if(_Original==false)
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
            
            _Original = true;
        }
        else if (_Original == true)
        {
            camera2.SetActive(true);
            camera1.SetActive(false);
            _Original = false;
        }
        _Swap = false;
    }
}
