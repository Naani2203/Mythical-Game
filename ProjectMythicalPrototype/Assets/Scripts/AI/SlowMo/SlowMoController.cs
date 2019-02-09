using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoController : MonoBehaviour
{
    [SerializeField]
    private float _SlowMoAmount = 0.1f;

    [SerializeField]
    private float _SlowMoTime = 1f;

    [SerializeField]
    private float _SlowMoWait = 0.02f;

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
        if (_CanSlowMo)
        {
            Time.timeScale = _SlowMoAmount;
            StartCoroutine(ResetTimeScale());
        }
    }

    private IEnumerator ResetTimeScale()
    {
        yield return new WaitForSecondsRealtime(_SlowMoTime);
        Time.timeScale = 1f;
        _CanSlowMo = false;
    }
}
