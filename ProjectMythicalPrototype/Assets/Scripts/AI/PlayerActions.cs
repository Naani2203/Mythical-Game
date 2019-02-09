using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
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
        if(_CanSlowMo) return;
        _CanSlowMo = true;
        Invoke("StartSlowMo", _SlowMoWait);
    }

    public void ResetSlowMo()
    {
        print("ResetSloMo");
        _CanSlowMo = false;
    }

    private void StartSlowMo()
    {
        if(_CanSlowMo)
        {
            print("Slow Mo");
            Time.timeScale = _SlowMoAmount;
            StartCoroutine(ResetTimeScale());
        }
    }

    private IEnumerator ResetTimeScale()
    {
        yield return new WaitForSecondsRealtime(_SlowMoTime);
        print("Reset Time Scale");
        Time.timeScale = 1f;
        _CanSlowMo = false;
    }

}
