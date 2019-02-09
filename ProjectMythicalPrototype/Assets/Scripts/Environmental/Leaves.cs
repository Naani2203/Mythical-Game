using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public List<GameObject> leaves;
    public float timetodestroy = 5f;
    private bool _Starttimer = false;
    private float _Time;
    public float delaytime;
    private float _Delay;
    private bool _Startdelay;
    private bool _Spawnleaves;

    private ThirdPersonController _Player;

    private void Awake()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();

    }

    void Update()
    {
        if (_Starttimer == true)
        {
            _Time += Time.deltaTime;
        }
        if (_Time >= timetodestroy)
        {
            for (int i = 0; i < leaves.Count; i++)
            {

                leaves[i].SetActive(false);
                _Time = 0;
                _Delay = 0;
            }
            _Startdelay = false;
        }
        if (_Startdelay == true)
        {
            _Delay += Time.deltaTime;
        }
        if (_Spawnleaves == true)
        {
            SpawnLeaves();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown("joystick button 3"))
        {
            _Spawnleaves = true;
            _Player.Interact = true;
            Debug.Log("Leaves: Interact is true");
        }
    }
    void SpawnLeaves()
    {
       
        _Startdelay = true;
        if (_Delay >= delaytime)
            
        {
            for (int i = 0; i < leaves.Count; i++)
            {
                leaves[i].SetActive(true);
                _Starttimer = true;
                _Delay = 0;
            }
            
            _Spawnleaves = false;
        }
        
    }
}
