using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public GameObject point_A;
    public GameObject point_B;
    public bool looping;
    private Transform _Target;
    [SerializeField]
    private float _DelayTime;
    private float _Delay;
    private bool _IsDelay;
  
    public float speed = 5f;
    private float _Movespeed;

    private void Start()
    {
        _Target = point_B.transform;
        _IsDelay = false;
        _Delay = 0;
    }

    void Update ()
    {
        _Movespeed=speed * Time.deltaTime;
        if (_IsDelay == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Target.position, _Movespeed);
        }
        if(_IsDelay==true)
        {
            Delay();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (looping == true)
        {
            
            if (other.gameObject == point_A)
            {
                _Target = point_B.transform;
                _IsDelay = true;
            }
            if (other.gameObject == point_B)
            {
                _Target = point_A.transform;
                _IsDelay = true;
            }
        }
    }
    private void Delay()
    {
        _Delay += Time.deltaTime;
        if(_Delay>=_DelayTime)
        {
            _IsDelay = false;
            _Delay = 0;
        }
    }
}
