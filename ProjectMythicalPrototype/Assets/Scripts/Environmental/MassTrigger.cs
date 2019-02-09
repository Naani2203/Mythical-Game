using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassTrigger : MonoBehaviour
{
    [SerializeField]
    private float _MassAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().mass = _MassAmount;
        }
    }

}
