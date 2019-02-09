using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTrap : MonoBehaviour
{
    public GameObject point_A;
    public GameObject point_B;
    public float delay;
    public float damage;
    private float _Delaytime;
    private bool _Looping;
    private bool _Check;
    private Transform _Target;

    public float speed = 5f;
    private float _Movespeed;

    private void Start()
    {
        _Delaytime = 0;
        _Looping = true;
        _Target = point_B.transform;
    }
  
    void Update()
    {
        _Delaytime += Time.deltaTime;
        if (_Delaytime >= delay)
        {
            _Movespeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _Target.position, _Movespeed);
           
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
         
            if (other.gameObject == point_A)
            {
                _Delaytime = 0;

                _Target = point_B.transform;

            }
            if (other.gameObject == point_B)
            {
                _Delaytime = 0;
                
                _Target = point_A.transform;
               
            }
    }
   
}
