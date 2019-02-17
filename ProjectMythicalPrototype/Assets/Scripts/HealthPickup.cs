using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
   
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _HealthPickup;
    [SerializeField]
    private GameObject _Particle;

    private void Awake()
    {
        _Audio=GameObject.Find("PickupFX").GetComponent<AudioSource>();

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(_Particle, transform.position, Quaternion.identity);
            _Audio.clip = _HealthPickup;
            _Audio.Play();
            Destroy(gameObject);

        }
    }
}
