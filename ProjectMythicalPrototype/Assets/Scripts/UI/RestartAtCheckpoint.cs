using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartAtCheckpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointManager _Checkpoint;
	
    public void RestartCheckpoint()
    {
        _Checkpoint.RespawnPlayer();
    }

}
