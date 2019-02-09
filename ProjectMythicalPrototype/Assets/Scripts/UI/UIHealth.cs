using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject _Heart1;
    [SerializeField]
    private GameObject _Heart2;
    [SerializeField]
    private GameObject _Heart3;
    [SerializeField]
    private GameObject _Heart4;
    [SerializeField]
    private GameObject _GameOverScreen;

    private float _Health;

    private GameObject _Player;
    private ActorHealth _PlayerHealth;


    // Use this for initialization
    void Start ()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerHealth = _Player.GetComponent<ActorHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        _Health = ActorHealth.PlayerCurrentHealth;
        if (_Health<0)
        {
            _Health = 0;
        }
        RemoveHearts();
        AddHearts();

        if(_Health == 0)
        {
            Time.timeScale = 0;
            _GameOverScreen.SetActive(true);

        }
    }

    void RemoveHearts()
    {
        if (_Health <=75)
        {
            _Heart4.SetActive(false);
        }
        if (_Health <= 50)
        {
            _Heart3.SetActive(false);
        }
        if (_Health <= 25)
        {
            _Heart2.SetActive(false);
        }
        if (_Health <= 0)
        {
            _Heart1.SetActive(false);
        }
    }
    void AddHearts()
    {
        if (_Health > 75)
        {
            _Heart4.SetActive(true);
        }
        if (_Health >50)
        {
            _Heart3.SetActive(true);
        }
        if (_Health > 25)
        {
            _Heart2.SetActive(true);
        }
        if (_Health > 0)
        {
            _Heart1.SetActive(true);
        }
    }
}
