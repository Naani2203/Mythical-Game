using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private AudioSource _Audio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _Audio.Play();
            Destroy(gameObject);

        }
    }
}
