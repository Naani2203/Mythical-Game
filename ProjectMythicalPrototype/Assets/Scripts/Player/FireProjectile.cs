using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private Projectile _Projectile;

    private Rigidbody _Rigidbody;
    private CapsuleCollider _Collider;
    private AudioSource _Audio;

    private void Start()
    {
        _Rigidbody = GetComponentInParent<Rigidbody>();
        _Collider = GetComponentInParent<CapsuleCollider>();
        _Audio = GetComponentInParent<AudioSource>();

    }

    public void Fire()
    {
        Projectile spawnedProjectile = Instantiate(_Projectile, transform.position, transform.rotation);
        spawnedProjectile.Shoot(_Rigidbody.velocity, _Collider);

        _Audio.Play();
    }
}

