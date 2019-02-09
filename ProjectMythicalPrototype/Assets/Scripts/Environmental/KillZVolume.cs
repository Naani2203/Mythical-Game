using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZVolume : MonoBehaviour
{
    [SerializeField]
    private int _SceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            SceneManager.LoadScene(_SceneIndex);
        }
    }

}
