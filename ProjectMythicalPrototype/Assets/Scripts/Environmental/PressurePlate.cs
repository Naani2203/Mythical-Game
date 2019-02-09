using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> Platforms;
   
    public List<Transform> startPosition;
    private Vector3 _Target;
    public float speed;
    private bool _Trigger;

    private void Update()
    {
       
        if(_Trigger==true)
        {
            PlatformMove();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _Trigger = true;
            
        }
       
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
        }
    }

    void PlatformMove()
    {
        for (int i = 0; i < Platforms.Count; i++)
        {
            Platforms[i].transform.position = Vector3.MoveTowards(Platforms[i].transform.position, startPosition[i].position, speed * Time.deltaTime);
        }
    }


}
