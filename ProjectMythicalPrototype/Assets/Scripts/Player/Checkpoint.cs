using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
    private bool _CheckpointActivated;
    private AudioSource _AudioSource;

	private void Awake()
	{
        _CheckpointActivated = false;
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!_CheckpointActivated)
		{
			if (other.gameObject.tag == "Player" && other.GetType()== typeof (CapsuleCollider))
			{
                _AudioSource.Play();
                Debug.Log("Checkpoint activated");
				Activate();
			}
		}
	}

	private void Activate() 
	{
        CheckpointManager.CheckpointPos = transform.position;
        _CheckpointActivated = true;

	}
}
