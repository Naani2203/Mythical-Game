using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarTrigger : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="Player")
        {
            other.gameObject.GetComponent<PlayerPickUp>().GemSpawn();
        }
    }
    
}
