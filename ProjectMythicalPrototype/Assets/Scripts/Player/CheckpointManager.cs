using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    [SerializeField]
    public static Vector3 CheckpointPos;

    [SerializeField]
    private GameObject _Player;

    [SerializeField]
    private GameObject _GameOverScreen;

    private Vector3 _InitialPosition;

    private void Awake()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _InitialPosition = _Player.transform.position;
        CheckpointPos = _InitialPosition;
    }

    public void RespawnPlayer()
    {
        _Player.GetComponent<ActorHealth>().IsAlive = true;
        _Player.GetComponent<ActorHealth>().CurrentHealth = _Player.GetComponent<ActorHealth>().MaxHealth;
        _Player.transform.position = CheckpointPos;
        _GameOverScreen.SetActive(false);
    }

}
