
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [Header("Health")]

    [SerializeField]
    private float _MaxHealth = 3.0f;
    [SerializeField]
    private float _CurrentHealth;
    [SerializeField]
    private Image _HealthBar;
    [SerializeField]
    private List<AudioClip> _AudioClips;

    private AudioSource _Audio;
    private Rigidbody _Rb;
    private int _Random;

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
        _Audio = GetComponent<AudioSource>();
        CurrentHealth = _MaxHealth;
    }

    private void Update()
    {
        if(_HealthBar!=null)
        {
        _HealthBar.fillAmount = (_CurrentHealth / _MaxHealth);

        }
    }

    public float CurrentHealth
    {
        get { return _CurrentHealth; }
        protected set { _CurrentHealth = Mathf.Clamp(value, 0f, _MaxHealth); }
    }

    //-------------------------------- ACTOR DAMAGED --------------------------------

    public void Damage(float damageAmount)
    {
        if(CurrentHealth <= damageAmount)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= damageAmount;
        }
        
        Debug.Log(gameObject.name + " takes " + damageAmount + " damage.");

        if (_Rb != null)
        {
            _Rb.AddForce(transform.forward * -1f * 2000f);
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }


        //-------------------------------- AUDIO --------------------------------
        if(_AudioClips.Count>0)
        {
        _Random = Random.Range(1, _AudioClips.Count);
        _Audio.clip = _AudioClips[(int)_Random];
        _Audio.Play();
        }

    }

    public void Death()
    {
        if(_HealthBar!=null)
        _HealthBar.enabled = false;
    }
}






