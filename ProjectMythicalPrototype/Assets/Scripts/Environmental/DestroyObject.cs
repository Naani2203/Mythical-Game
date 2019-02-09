using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private float _DestroyTime;
    private void Awake()
    {
        Destroy(gameObject, _DestroyTime);
    }

}
