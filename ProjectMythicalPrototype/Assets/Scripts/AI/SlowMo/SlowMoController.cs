using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoController : MonoBehaviour
{
    [SerializeField]
    private float _SlowMoAmount = 0.1f;

    [SerializeField]
    private float _SlowMoTime = 1f;
    public static bool _SlowMoCD;
    [SerializeField]
    private float _SlowMoWait = 0.02f;
    [SerializeField]
    private float _SlowMoCoolDown = 4f;
    private float _Delay=0;
    public static bool _IsAttackSloMo;
    public static bool _InSlowMo;


    private bool _CanSlowMo = false;

    public void SetSlowMo()
    {
        if (_CanSlowMo) return;
        _CanSlowMo = true;
        Invoke("StartSlowMo", _SlowMoWait);
    }

    public void ResetSlowMo()
    {
        _CanSlowMo = false;
    }

    private void StartSlowMo()
    {
        if (_CanSlowMo==true && _SlowMoCD==false && _IsAttackSloMo==true)
        {
            Time.timeScale = _SlowMoAmount;
            _SlowMoCD = true;
            StartCoroutine(ResetTimeScale());
            _InSlowMo = true;
        }
    }

    private IEnumerator ResetTimeScale()
    {
        yield return new WaitForSecondsRealtime(_SlowMoTime);
        Time.timeScale = 1f;
        _CanSlowMo = false;
        _InSlowMo = false;
    }
    private void Update()
    {
      
        if(_SlowMoCD==true)
        {
            _Delay += Time.deltaTime;
            if(_Delay>=_SlowMoCoolDown)
            {
                _SlowMoCD = false;
                _Delay = 0;
            }
        }
        
    }
}
