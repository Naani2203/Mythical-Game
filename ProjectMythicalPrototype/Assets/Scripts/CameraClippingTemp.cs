using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClippingTemp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<MeshRenderer>().enabled = true;
    }
}
