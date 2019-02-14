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
    [SerializeField]
    private CameraShaker _Camera;


    public void SpawnParticleAtJumpAndLand()
    {
        Instantiate(_ParticleEffect, _Leg1.position, Quaternion.identity);
        _Camera.CameraShake(0.1f,0.08f);

    }
    public void SpawnParticleAtSmash()
    {
        Instantiate(_CircleEffect, _StompPos.position, Quaternion.identity);
        _Camera.CameraShake(0.1f, 0.08f);

    }
}
