using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public List<GameObject> fallObjects;
    private List<Rigidbody> rBodies;
    [SerializeField]
    private float _Speed;
    [SerializeField]
    private float _Delaytime;
    [SerializeField]
    private float _DestroyTime;
    private float _Delay;
    private bool _Fall;
    private bool _Startdelay;

    private void Update()
    {
        if (_Startdelay == true)
        {
            _Delay += Time.deltaTime;
        }
        if(_Fall==true)
        {
            FallObjects();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.name == "Player")
            {
            _Fall = true;
            _Startdelay = true;
            }
            
    }
    void FallObjects()
    {
        _Startdelay = true;
        if (_Delay >= _Delaytime)
        {
            for (int i = 0; i < fallObjects.Count; i++)
                {
            
                    fallObjects[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.Range(_Speed, _Speed * 2) * -1, 0));
                Destroy(fallObjects[i], _DestroyTime);
                }
        }
    }
}


