using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _HealthPickup;

    private void Awake()
    {
        _Audio=GameObject.Find("PickupFX").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _Audio.clip = _HealthPickup;
            _Audio.Play();
            Destroy(gameObject);

        }
    }
}
