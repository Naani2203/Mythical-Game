using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablebyPlayer : MonoBehaviour
{


    [SerializeField]
    private GameObject _OriginalObject;
    [SerializeField]
    private GameObject _BrokenObject;
    private Rigidbody _Rb;
    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _OriginalObject.SetActive(false);
            _BrokenObject.SetActive(true);

        }
    }
}
