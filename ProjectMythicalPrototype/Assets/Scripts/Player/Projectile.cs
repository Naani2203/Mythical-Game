using System.Collections;
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
    [SerializeField] protected float _KnockBack = 5f;

    private Rigidbody _Rigidbody;
    private SphereCollider _Collider;

    public void Shoot(Vector3 initialVelocity, Collider collider)
    {
        Destroy(gameObject, _LifeTime);

        _Rigidbody = GetComponent<Rigidbody>();
        _Rigidbody.velocity = transform.forward * _Velocity + initialVelocity;

        _Collider = GetComponent<SphereCollider>();

        Physics.IgnoreCollision(_Collider, collider, true);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                             Quaternion.LookRotation(_Rigidbody.velocity.normalized),
                             Time.deltaTime * RotationLerpSpeed);
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
