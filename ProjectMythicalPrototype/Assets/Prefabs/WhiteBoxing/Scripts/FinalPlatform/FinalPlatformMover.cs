using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatformMover : MonoBehaviour
{

    public rail rail;

    private int currentseg;
    private float transition;
    private bool isCompleted;
    private bool _CanMove=false;

    public float speed = 2.5f;
    public bool isReversed;
    public bool isLooping;
    public bool pingPong;

    public PlayMode mode;

    private void Update()
    {
        if (!rail)
            return;
        if(_CanMove==true)
        {
            if (!isCompleted)
            {
                Play(!isReversed);
            }
        }
    }

    private void Play(bool forward = true)
    {
        float m = (rail.nodes[currentseg + 1].position - rail.nodes[currentseg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += (forward) ? s : -s;
        if (transition > 1)
        {
            transition = 0;
            currentseg++;
            if (currentseg == rail.nodes.Length - 1)
            {
                if (isLooping)
                {

                }
                else
                {
                    isCompleted = true;
                    return;
                }
            }
        }
        else if (transition < 0)
        {
            transition = 1;
            currentseg--;
        }

        transform.position = rail.PositionOnRail(currentseg, transition, mode);
        transform.rotation = rail.Orientation(currentseg, transition);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && other.GetType()==typeof(CapsuleCollider))
        {
            //if(Input.GetButtonDown("Interact"))
            //{
                _CanMove = true;
            //}
        }
    }
}
