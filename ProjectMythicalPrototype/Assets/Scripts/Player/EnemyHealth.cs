using System;
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
    private Rigidbody _Rb;
  
    
    
    
	public float CurrentHealth 
	{ 
		get {return _CurrentHealth;} 											// returns current health from _CurrentHealth
		protected set {_CurrentHealth = Mathf.Clamp(value, 0f, _MaxHealth);} 	// sets _CurrentHealth to new value, protected scope
	}

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
        
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
	}

	public void Death()
    {
        _HealthBar.enabled = false;
    }
}
