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

    private bool _IsTouchingPlayer;
    private bool _IsTouchingProjectile;

    private void Awake()
    {
        _Audio = GetComponent<AudioSource>();
        _Rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            _IsTouchingProjectile = true;
            Break();
        }
        else
        {
            _IsTouchingProjectile = false;
        }

        if (other.CompareTag("Player"))
        {
            _IsTouchingPlayer = true;
        }
        else
        {
            _IsTouchingPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            _IsTouchingProjectile = false;
        }

        if (other.CompareTag("Player"))
        {
            _IsTouchingPlayer = false;
        }
    }

    public void Break()
    {
        if (_IsTouchingProjectile || _IsTouchingPlayer)
        _Audio.Play();
        _OriginalObject.SetActive(false);
        _BrokenObject.SetActive(true);
    }
}
