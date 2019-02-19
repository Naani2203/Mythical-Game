using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slate : MonoBehaviour
{
    private float _Delay;
    private bool _IsDelay;

    private void Awake()
    {
        _IsDelay = true;
        _Delay = 0;
    }
    private void Update()
    {
        _Delay += Time.deltaTime;
        if(_Delay>=5.0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


}
