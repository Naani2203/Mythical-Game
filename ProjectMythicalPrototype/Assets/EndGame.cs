using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")&&collision.collider.GetType()==typeof (CapsuleCollider))
        {
        SceneManager.LoadScene("EndCredit");

        }
    }
}
