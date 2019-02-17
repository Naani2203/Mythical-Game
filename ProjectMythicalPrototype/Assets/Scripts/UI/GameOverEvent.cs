using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject _FirstSelected;
    [SerializeField]
    private EventSystem _EventSystem;

    private void Awake()
    {
        _EventSystem.firstSelectedGameObject = _FirstSelected;
    }

}
