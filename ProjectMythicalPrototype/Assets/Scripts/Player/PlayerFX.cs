using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    [SerializeField]
    private GameObject _ParticleEffect;
    [SerializeField]
    private Transform _Leg1;
    [SerializeField]
    private GameObject _CircleEffect;
    [SerializeField]
    private Transform _StompPos;


    public void SpawnParticleAtJumpAndLand()
    {
        Instantiate(_ParticleEffect, _Leg1.position, Quaternion.identity);
    
    }
    public void SpawnParticleAtSmash()
    {
        Instantiate(_CircleEffect, _StompPos.position, Quaternion.identity);

    }
}
