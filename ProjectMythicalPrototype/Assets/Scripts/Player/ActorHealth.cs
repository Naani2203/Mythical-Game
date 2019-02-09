using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorHealth : MonoBehaviour
{

    private GameObject _Manager;
    public CheckpointManager CheckpointManager;

    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioClip _Hurt01;
    [SerializeField]
    private AudioClip _Hurt02;
    [SerializeField]
    private AudioClip _Hurt03;
    [SerializeField]
    private AudioClip _DeathSFX;

    [SerializeField]
    private GameObject _GameOverScreen;
    [SerializeField]
    private Image _PlayerHealthBar;

    [Header("Health")]
    [SerializeField] public float MaxHealth = 100.0f;
    public static float PlayerCurrentHealth = 100.0f;

    //Animation values
    public bool IsAlive;
    public bool IsHurt;


    public float CurrentHealth
    {
        get { return PlayerCurrentHealth; }
        set { PlayerCurrentHealth = Mathf.Clamp(value, 0f, MaxHealth); }
    }

    protected void Start()
    {
        PlayerCurrentHealth = MaxHealth;
        _Manager = GameObject.FindGameObjectWithTag("cpManager");
        CheckpointManager = _Manager.GetComponent<CheckpointManager>();
        IsAlive = true;
        IsHurt = false;
    }
    private void Update()
    {
        _PlayerHealthBar.fillAmount = PlayerCurrentHealth / MaxHealth;
    }

    //-------------------------------- ACTOR DAMAGED & DEATH --------------------------------
    public void Damage(float damageAmount)
    {
        PlayerCurrentHealth -= damageAmount;
        Debug.Log(gameObject.name + " takes " + damageAmount + " damage.");
        if (CurrentHealth <= 0f) Death();
        IsHurt = true;
        _Audio.clip = _Hurt01;
        _Audio.Play();
    }

    public void Death()
    {
        IsAlive = false;
        _Audio.clip = _DeathSFX;
        _Audio.Play();
        StartCoroutine(WaitForAnim());
    }

    public void ImmidiateDeath()
    {
        IsAlive = false;
        _Audio.clip = _DeathSFX;
        _Audio.Play();
        _GameOverScreen.SetActive(true);
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(3f);
        _GameOverScreen.SetActive(true);
    }

    //-------------------------------- HEALTH PICKUP --------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Health" )
        {
            if (CurrentHealth >= 85)
                CurrentHealth = MaxHealth;
            else
                CurrentHealth += 15;
        }
    }
}
