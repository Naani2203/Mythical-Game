﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Variables")]
    [SerializeField]
    private float _AttackRange = 3.5f;
    [SerializeField]
    private float _ShootDamage = 2;

    private int _AttackNumber = 1;
    private float _DamageAmount = 1;
    const float _Attack01Damage = 1;
    const float _Attack02Damage = 2;
    const float _Attack03Damage = 3;
    private bool _IsInAttackAnim;
    private bool _InContact;

    private Animator _Anim;
    private EnemyHealth _Enemy;
    private FireProjectile _ProjectileAttack;
    private GameObject _EnemyInContact;

    [Header("Audio")]
    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _Attack01;
    [SerializeField]
    private AudioClip _Attack02;
    [SerializeField]
    private AudioClip _AttackOgre;
    [SerializeField]
    private AudioClip _Shoot;
    [SerializeField]
    private AudioClip _HitImpact;

    [Header("Projectile Attack")]
    [SerializeField]
    private GameObject _ProjectileWeapon;
    [SerializeField]
    private GameObject _HitImpactParticle;


    [SerializeField]
    private CameraShaker _Camera;

    [SerializeField]
    private GameObject _Weapon;


    private void Awake()
    {
        _Anim = GetComponent<Animator>();
        _ProjectileAttack = _ProjectileWeapon.GetComponent<FireProjectile>();
    }

    private void Update()
    {

        if (_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") == false && _Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack02") == false && _Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack03") == false)
        {
            _IsInAttackAnim = false;
        }
        else
        {
            _IsInAttackAnim = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (_IsInAttackAnim == false)
            {
                SetRandomAttack();
                _Anim.SetTrigger("Attack");
                _Anim.SetInteger("AttackNum", _AttackNumber);
                _Audio.clip = _Attack01;
                _Audio.Play();

                RaycastHit hit;

                if (Physics.SphereCast(_Weapon.transform.position, 3, _Weapon.transform.forward, out hit, _AttackRange))
                {
                    if(hit.collider.gameObject.CompareTag("Enemy") )
                    {
                        Attack(hit.point, hit.transform);
                        Instantiate(_HitImpactParticle, hit.point, Quaternion.identity);
                        _Camera.CameraShake(0.05f, 0.08f);
                    }
                }
                if (_InContact == true)
                {
                    AttackOnContact(_EnemyInContact);
                }
            }
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            if (_Anim.GetCurrentAnimatorStateInfo(0).IsName("ProjectileAttack") == false)
            {
                _Anim.SetTrigger("Fire");
                _Audio.clip = _Shoot;
                _Audio.Play();
                _DamageAmount = _ShootDamage;
                _ProjectileAttack.Fire();
            }
        }
    }

    private void Attack(Vector3 hitPos, Transform other)
    {
        var otherUnit = other.GetComponent<EnemyHealth>();
        if (otherUnit != null)
        {
            otherUnit.Damage(_DamageAmount);
        }
    }

    public void AttackOnContact(GameObject other)
    {
        var otherUnit = other.GetComponent<EnemyHealth>();
        if (otherUnit != null)
        {
            _Audio.clip = _HitImpact;
            _Audio.Play();
            otherUnit.Damage(_DamageAmount);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _InContact = true;
            _EnemyInContact = other.gameObject;
        }
        else
        {
            _InContact = false;
            _EnemyInContact = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _InContact = false;
            _EnemyInContact = null;
        }
    }

    private void SetRandomAttack()
    {
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            _DamageAmount = _Attack01Damage;
            _AttackNumber = 1;
        }
        if (random == 2)
        {
            _DamageAmount = _Attack02Damage;
            _AttackNumber = 2;
        }
        if (random == 3)
        {
            _DamageAmount = _Attack03Damage;
            _AttackNumber = 3;
        }
    }
}