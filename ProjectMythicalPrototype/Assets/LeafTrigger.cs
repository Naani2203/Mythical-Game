using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTrigger : MonoBehaviour
{
    [SerializeField]
    private List<Animator> _Leaves;
    [SerializeField]
    private float _Delay;
    private float _DelayTime;
    private bool _CanSpawn = false;
    private int _LeafCount;
    [SerializeField]
    private GameObject _UI;

    private void Awake()
    {
        _LeafCount = 0;
    }

    private void Update()
    {
        if(_CanSpawn==true && _LeafCount<_Leaves.Count)
        {
            _Leaves[_LeafCount].SetTrigger("Open");
            _Leaves[_LeafCount].SetBool("CanOpen", true);


            Delay();
        }
        if(_LeafCount>=_Leaves.Count)
        {
            _LeafCount = 0;
            _CanSpawn = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ThirdPersonController._CanInteract = true;
            _UI.SetActive(true);
            if(Input.GetButtonDown("Interact"))
            _CanSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ThirdPersonController._CanInteract = false;
            _CanSpawn = false;
            _UI.SetActive(false);
        }
    }


    private void Delay()
    {
        _DelayTime += Time.deltaTime;
        if(_DelayTime>=_Delay)
        {
            _DelayTime = 0;
            _LeafCount++;
        }
    }


}
