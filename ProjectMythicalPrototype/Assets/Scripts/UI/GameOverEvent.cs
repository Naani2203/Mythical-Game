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
    [SerializeField]
    private Canvas _Canvas;

    private void Awake()
    {
       // _EventSystem.firstSelectedGameObject = _FirstSelected;
        EventSystem.current.SetSelectedGameObject(_FirstSelected);
    }
   

}
