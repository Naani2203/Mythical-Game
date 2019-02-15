using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashFX : MonoBehaviour
{
    [SerializeField]
    private GameObject _SlashEffect1;
    [SerializeField]
    private GameObject _SlashEffect2;
    [SerializeField]
    private GameObject _SlashEffect3;
    [SerializeField]
    private Transform _AttackPos1;
    [SerializeField]
    private Transform _AttackPos2;
    [SerializeField]
    private Transform _AttackPos3;
    [SerializeField]
    private Transform _PlayerTransform;


    public void SpawnSlashFX1()
    {
        Instantiate(_SlashEffect1, _AttackPos1.position, transform.localRotation);
    }
    public void SpawnSlashFX2()
    {
        Instantiate(_SlashEffect2, _AttackPos2.position, transform.localRotation);
    }
    public void SpawnSlashFX3()
    {
        Instantiate(_SlashEffect3, _AttackPos3.position, transform.localRotation);
    }

}
