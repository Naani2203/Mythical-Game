using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablebyPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject _OriginalObject;
    [SerializeField]
    private GameObject _BrokenObject;
    [SerializeField]
    private GameObject _HealthPickup;
    [SerializeField]
    private EnemyHealth _EnemyHealth;
    private bool _IsBroken;


    private Rigidbody _Rb;
    private AudioSource _Audio;

    private bool _IsTouchingPlayer;
    private bool _IsTouchingProjectile;

    private void Awake()
    {
        _IsBroken = false;
        _Audio = GetComponent<AudioSource>();
        _Rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(_IsBroken==false && _EnemyHealth.CurrentHealth<=0)
        {
            ExplodePot();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //_IsTouchingProjectile = true;
            //Break();
        }
        //else
        //{
        //    _IsTouchingProjectile = false;
        //}

        //if (other.CompareTag("Player"))
        //{
        //    _IsTouchingPlayer = true;
        //}
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Projectile"))
    //    {
    //        _IsTouchingProjectile = false;
    //    }

    //    if (other.CompareTag("Player"))
    //    {
    //        _IsTouchingPlayer = false;
    //    }
    //}

    //public void Break()
    //{
    //    //if (_IsTouchingProjectile || _IsTouchingPlayer)
    //    //{
            
    //        _Audio.Play();
    //    //}
    //        Instantiate(_HealthPickup, transform.position,Quaternion.identity);
    //        _OriginalObject.SetActive(false);
    //        _BrokenObject.SetActive(true);
    //}
    private void ExplodePot()
    {
        _Audio.Play();
        Instantiate(_HealthPickup, transform.position, Quaternion.identity);
        _OriginalObject.SetActive(false);
        _BrokenObject.SetActive(true);
        _IsBroken = true;
    }
}
