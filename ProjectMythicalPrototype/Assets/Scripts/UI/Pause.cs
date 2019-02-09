using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField]
    private GameObject _PauseScreen;
    private bool _IsPaused;
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            _IsPaused = true;
        }
        if(_IsPaused==true)
        {
            Time.timeScale = 0;
            _PauseScreen.SetActive(true);
            _IsPaused = false;
        }
	}
}
