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
    [SerializeField]
    private AudioSource _Audio;
    [SerializeField]
    private AudioSource _FootStepsFX;
    [SerializeField]
    private AudioClip _FaunLand;
    [SerializeField]
    private AudioClip _FaunFootStepsLeft;
    [SerializeField]
    private AudioClip _FaunFootStepsRight;
    [SerializeField]
    private AudioClip _InteractSound;


    public void SpawnParticleAtJumpAndLand()
    {
        Instantiate(_ParticleEffect, _Leg1.position, Quaternion.identity);
        _Camera.CameraShake(0.1f,0.08f);
        _Audio.clip = _FaunLand;
        _Audio.Play();

    }
    public void SpawnParticleAtSmash()
    {
        Instantiate(_CircleEffect, _StompPos.position, Quaternion.identity);
        _Camera.CameraShake(0.1f, 0.08f);
        _Audio.clip = _InteractSound;
        _Audio.Play();

    }
    public void PLaySoundAtLeftFoot()
    {
        _FootStepsFX.clip = _FaunFootStepsLeft;
        _FootStepsFX.Play();
    }
    public void PLaySoundAtRightFoot()
    {
        _FootStepsFX.clip = _FaunFootStepsRight;
        _FootStepsFX.Play();
    }
}
