using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompForceTrigger : MonoBehaviour
{
    [SerializeField]
    private float _StompForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * _StompForce, ForceMode.Impulse);

        }
    }

}

