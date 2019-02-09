using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlowMoOnCollision : MonoBehaviour
{

    [SerializeField]
    private string _Tag;

    [SerializeField]
    UnityEvent _Actions;

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag(_Tag))
        {
            _Actions.Invoke();
        }
    }
}
