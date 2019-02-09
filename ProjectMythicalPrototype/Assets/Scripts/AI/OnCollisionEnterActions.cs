using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEnterActions : MonoBehaviour
{
    [SerializeField]
    private string _Tag;

    [SerializeField]
    UnityEvent _Actions;

    private void OnCollisionEnter(Collision other)
    {
        print("OnCol");
        if(other.gameObject.CompareTag(_Tag))
        {
            _Actions.Invoke();
        }
    }
}
