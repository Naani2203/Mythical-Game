using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformstay : MonoBehaviour
{
    private Quaternion _OriginalTransform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _OriginalTransform = this.transform.rotation;
            this.gameObject.transform.SetParent(collision.collider.transform);
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            this.gameObject.transform.SetParent(null);
            
        }
    }
}
