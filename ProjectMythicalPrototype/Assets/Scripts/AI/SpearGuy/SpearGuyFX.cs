using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGuyFX : MonoBehaviour
{
    [SerializeField]
    private Transform _LeftLeg;
    [SerializeField]
    private Transform _RightLeg;
    [SerializeField]
    private GameObject _StompParticleFX;
    [SerializeField]
    private CameraShaker _Camera;
    private GameObject _Player;
    private bool _CanScreenShake;

    private void Awake()
    {
        _Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _Player.transform.position)<20)
        {
            _CanScreenShake = true;
        }
    }


    void SpawnParticleAtLeftLeg()
    {
        if(_CanScreenShake==true)
        {
        Instantiate(_StompParticleFX, _LeftLeg.position, Quaternion.identity);
        _Camera.CameraShake();
        

        }
    }
    void SpawnParticleAtRightLeg()
    {
        if(_CanScreenShake==true)
        {
        Instantiate(_StompParticleFX, _RightLeg.position, Quaternion.identity);
        _Camera.CameraShake();
            
        }
    }
   

}

