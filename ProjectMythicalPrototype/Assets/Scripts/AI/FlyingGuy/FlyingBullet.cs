using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBullet : MonoBehaviour
{
    [SerializeField]
    private float _Speed;
    private Vector3 _Target;
    private Vector3 _Offset;
    private GameObject _FlyingGuy;
    private Rigidbody _Rb;

    private void Awake()
    {
        _FlyingGuy = GameObject.Find("Pyramid");
        _Target = _FlyingGuy.GetComponent<FlyingGuy>().target;
        _Offset = new Vector3(1, 1, 1);
        _Target += _Offset + Vector3.back;
        _Rb = GetComponent<Rigidbody>();
    }


    void Update ()
    {
        
        _Rb.AddForce((_Target-transform.position).normalized * _Speed);
        Destroy(gameObject, 1f);
      
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Platform")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.name== "Player")
        {
            Destroy(gameObject);
        }
    }
}
