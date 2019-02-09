using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGemMovement : MonoBehaviour
{
    private PlayerPickUp _PlayerPickUp;
    private void Awake()
    {
        _PlayerPickUp = GameObject.Find("Player").GetComponent<PlayerPickUp>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _PlayerPickUp._TopRune.position, _PlayerPickUp._SpeedOfRune);
    }
}
