using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnFall : MonoBehaviour {

    private GameObject _Player;
    private ActorHealth _PlayerHealth;


    private void Awake()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerHealth = _Player.GetComponent<ActorHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") 
        {
            Debug.Log(_Player + " has entered killzone");
            _PlayerHealth.ImmidiateDeath();
        }
    }
}
