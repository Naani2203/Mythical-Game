using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehaviour : MonoBehaviour
{
    private Collider _Collider;
    [SerializeField]
    private float _Delay;
    private float _DelayTime;
    private Animator _Anim;

    private void Awake()
    {
        _Collider = GetComponentInChildren<Collider>();
        _Collider.enabled = false;
        _Anim = GetComponent<Animator>();
    }

    public void LeafClosed()
    {
        _Collider.enabled = false;
    }

    public void LeafOpened()
    {
        _Collider.enabled = true;
        Delay();
    }
    private void Delay()
    {
        _DelayTime += Time.deltaTime;
        if (_DelayTime >= _Delay)
        {
            _DelayTime = 0;
            _Anim.SetTrigger("Close");
            _Anim.SetBool("CanOpen", false);
           
        }
    }
}
