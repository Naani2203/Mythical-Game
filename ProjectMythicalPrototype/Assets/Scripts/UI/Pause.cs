using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{

    [SerializeField]
    private GameObject _PauseScreen;
    private bool _IsPaused;
    [SerializeField]
    private EventSystem _EventSystem;
    [SerializeField]
    private GameObject _FirstSelected;
   
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            _IsPaused = true;
        }
        if(_IsPaused==true)
        {
        
            ThirdPersonController._CanMove = false;
            _EventSystem.firstSelectedGameObject = _FirstSelected;
            Time.timeScale = 0;
            _PauseScreen.SetActive(true);
            _IsPaused = false;
        }
	}
}
