﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class Projectile : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] protected float _Velocity = 20f;
    [SerializeField] protected float _LifeTime = 2f;
    [SerializeField] protected float RotationLerpSpeed = 10f;

    [Header("Damage")]
    [SerializeField] protected float _Damage = 10f;
    [SerializeField] protected float _Radius = 2.5f;

    [SerializeField]
    private GameObject _ProjectileParticle;
    private GameObject _Particle;

    private Rigidbody _Rigidbody;
    private SphereCollider _Collider;


    public void Shoot(Vector3 initialVelocity, Collider collider)
    {
        _Particle = Instantiate(_ProjectileParticle, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject, _LifeTime);
        Destroy(_Particle.gameObject, _LifeTime);

        _Rigidbody = GetComponent<Rigidbody>();
        _Rigidbody.velocity = transform.forward * _Velocity + initialVelocity;

        _Collider = GetComponent<SphereCollider>();

        _Rigidbody.useGravity = false;
        Physics.IgnoreCollision(_Collider, collider, true);

        
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                             Quaternion.LookRotation(_Rigidbody.velocity.normalized),
                             Time.deltaTime * RotationLerpSpeed);

        _Particle.transform.rotation = Quaternion.Lerp(transform.rotation,
                           Quaternion.LookRotation(_Rigidbody.velocity.normalized),
                           Time.deltaTime * RotationLerpSpeed);

        _Particle.transform.position = gameObject.transform.position;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _Radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyHealth hitActor = colliders[i].GetComponent<EnemyHealth>();
            if (hitActor != null)
            {
                hitActor.Damage(_Damage);
            }
        }

        Destroy(gameObject);
    }
}
