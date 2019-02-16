using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablebyPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject _OriginalObject;
    [SerializeField]

    private GameObject _BrokenObject;
    private Rigidbody _Rb;
    private AudioSource _Audio;

    private void Awake()
    {
        _Audio = GetComponent<AudioSource>();
        _Rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            _Audio.Play();
            _OriginalObject.SetActive(false);
            _BrokenObject.SetActive(true);
        }
    }
}
