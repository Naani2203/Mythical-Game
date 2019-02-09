using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    private Animator _Anim;
    [SerializeField]
    private float _Duration;
    private float _Delay;
    private bool _IsSlowMo;

    private void Awake()
    {
        _Anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(_IsSlowMo==true)
        {
            StartSlowMo();
        }
        else
        {
            _Delay = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
      
            _IsSlowMo = true;
       
    }

    void StartSlowMo()
    {
        if(_Delay<_Duration)
        {
            Time.timeScale = 0.3f;
            
        }
        _Delay += Time.deltaTime;
        if (_Delay>=_Duration)
        {
            Time.timeScale = 1;
            _IsSlowMo = false;
            
        }
    }

}
