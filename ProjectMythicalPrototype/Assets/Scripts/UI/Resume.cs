using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    [SerializeField]
    private GameObject _PauseScreen;

    public void ButtonPressed()
    {
        ThirdPersonController._CanMove = true;
        _PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quitttt()
    {
        Application.Quit();
    }
}
