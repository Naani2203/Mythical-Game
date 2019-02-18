using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClippingTemp : MonoBehaviour
{
    private MeshRenderer _Mesh;

    private void OnTriggerEnter(Collider other)
    {
        _Mesh = other.GetComponent<MeshRenderer>();
        if(_Mesh!=null)
        {
            _Mesh.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _Mesh = other.GetComponent<MeshRenderer>();
        if (_Mesh != null)
        {
            _Mesh.enabled = true;
        }
    }
}
