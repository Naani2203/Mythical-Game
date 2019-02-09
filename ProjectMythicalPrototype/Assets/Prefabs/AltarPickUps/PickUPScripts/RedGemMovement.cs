using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemMovement : MonoBehaviour
{
    private PlayerPickUp _PlayerPickUp;
    private void Awake()
    {
        _PlayerPickUp = GameObject.Find("Player").GetComponent<PlayerPickUp>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _PlayerPickUp._LeftRune.position, _PlayerPickUp._SpeedOfRune);
    }
}
