using UnityEngine.Events;
using UnityEngine;

public class SlowMoOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string _Tag;

    [SerializeField]
    UnityEvent _Actions;

    private Animator _Anim;

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_Tag))
        {
            _Anim = other.gameObject.GetComponentInParent<Animator>();
           
                Debug.Log("slowmo");
                _Actions.Invoke();
            
            
        }
    }
}
