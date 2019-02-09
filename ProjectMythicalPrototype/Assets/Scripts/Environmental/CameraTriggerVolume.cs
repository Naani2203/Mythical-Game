using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerVolume : MonoBehaviour
{
    [SerializeField]
    private GameObject _Camera;


    private void OnTriggerEnter(Collider other)
    {
        _Camera.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        _Camera.SetActive(false);
    }
}
