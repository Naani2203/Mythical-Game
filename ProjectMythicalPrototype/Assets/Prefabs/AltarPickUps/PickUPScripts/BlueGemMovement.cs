using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemMovement : MonoBehaviour
{
    private PlayerPickUp _PlayerPickUp;
    private void Awake()
    {
        _PlayerPickUp = GameObject.Find("Player").GetComponent<PlayerPickUp>();
    }
    void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, _PlayerPickUp._RightRune.position, _PlayerPickUp._SpeedOfRune);
    }
}
