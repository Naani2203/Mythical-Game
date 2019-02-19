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
        if(Vector3.Distance(transform.position, _Player.transform.position)<10 && Vector3.Distance(transform.position, _Player.transform.position) > 2)
        {
            _CanScreenShake = true;
        }
        else
        {
            _CanScreenShake = false;
        }
    }


    void SpawnParticleAtLeftLeg()
    {
        Instantiate(_StompParticleFX, _LeftLeg.position, Quaternion.identity);
        if(_CanScreenShake==true && SlowMoController._InSlowMo==false)
        {
        _Camera.CameraShake(0.3f, 0.08f);
        

        }
    }
    void SpawnParticleAtRightLeg()
    {
        Instantiate(_StompParticleFX, _RightLeg.position, Quaternion.identity);
        if(_CanScreenShake==true && SlowMoController._InSlowMo == false)
        {
        _Camera.CameraShake(0.3f, 0.08f);
            
        }
    }
   

}

