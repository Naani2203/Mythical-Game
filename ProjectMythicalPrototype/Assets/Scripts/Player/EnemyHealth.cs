﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [Header("Health")]
	[SerializeField] private float _MaxHealth = 3.0f;
	[SerializeField] private float _CurrentHealth;
    [SerializeField] private float _KnockBackForce;
    [SerializeField] private Image _HealthBar;
    [SerializeField] private List<AudioClip> _AudioClips;
  
    private AudioSource _Audio;
    private Rigidbody _Rb;
    private int _Random;
  
    
    
    
	public float CurrentHealth 
	{ 
		get {return _CurrentHealth;} 											// returns current health from _CurrentHealth
		protected set {_CurrentHealth = Mathf.Clamp(value, 0f, _MaxHealth);} 	// sets _CurrentHealth to new value, protected scope
	}

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
        _Audio = GetComponent<AudioSource>();
        
    }

    protected void Start()
	{
		CurrentHealth = _MaxHealth;
	}
    private void Update()
    {
        _HealthBar.fillAmount = (_CurrentHealth / _MaxHealth);
    }

    //-------------------------------- ACTOR DAMAGED --------------------------------
    public void Damage(float damageAmount)
	{
		CurrentHealth -= damageAmount;
        Debug.Log(gameObject.name + " takes " + damageAmount + " damage.");

		if (CurrentHealth <= 0f) Death();
        if(_Rb!=null)
        _Rb.AddForce(transform.forward *-1f * _KnockBackForce);
      
        _Random = Random.Range(0, _AudioClips.Count);
        _Audio.clip = _AudioClips[(int)_Random];
        _Audio.Play();

        
	}

	public void Death()
    {
        
        _HealthBar.enabled = false;
        
    }
}
