using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterActions : MonoBehaviour
{
    [SerializeField]
    private string _Tag;
    
    [SerializeField]
    UnityEvent _Actions;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_Tag))
        {
            _Actions.Invoke();
        }
    }

}
