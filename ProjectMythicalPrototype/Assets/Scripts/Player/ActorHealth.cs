using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorHealth : MonoBehaviour
{
    public CheckpointManager CheckpointManager;
    private GameObject _Manager;

    [SerializeField]
    private GameObject _GameOverScreen;
  

    //------------------------------------- AUDIO ------------------------------------
    [Header("Audio")]
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

    //------------------------------------- HEALTH ------------------------------------
    [Header("Health")]
    [SerializeField] public float MaxHealth = 100.0f;
    public static float PlayerCurrentHealth = 100.0f;
    [SerializeField]
    private Image _PlayerHealthBar;

    //------------------------------------- ANIMATION VALUES ---------------------------
    public bool IsAlive;
    public bool IsHurt;

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

    public float CurrentHealth
    {
        get { return PlayerCurrentHealth; }
        set { PlayerCurrentHealth = Mathf.Clamp(value, 0f, MaxHealth); }
    }

    //-------------------------------- HEALTH PICKUP --------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Health")
        {
            if (CurrentHealth >= 85)
            {

                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += 15;
            }
        }
    }

    //-------------------------------- ACTOR DAMAGED & DEATH --------------------------------
    public void Damage(float damageAmount)
    {
        PlayerCurrentHealth -= damageAmount;
        Debug.Log(gameObject.name + " takes " + damageAmount + " damage.");
        if (CurrentHealth <= 0f)
        {

            Death();
        }
        else
        {
            IsHurt = true;
            _Audio.clip = _Hurt01;
            _Audio.Play();
        }
    }

    public void Death()
    {
        _Audio.PlayOneShot(_DeathSFX, 0.7F);
        IsAlive = false;
        StartCoroutine(WaitForAnim());
    }

    public void ImmidiateDeath()
    {
        _Audio.clip = _DeathSFX;
        _Audio.Play();
        IsAlive = false;
        _GameOverScreen.SetActive(true);
    }
    

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        _Audio.enabled = false;
        yield return new WaitForSecondsRealtime(2f);
        _GameOverScreen.SetActive(true);
    }
}
