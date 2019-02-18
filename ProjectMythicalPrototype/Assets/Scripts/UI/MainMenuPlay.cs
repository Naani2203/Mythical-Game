using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlay : MonoBehaviour
{
    [SerializeField]
    private Animator _Anim;

	public void Play()
    {
        _Anim.SetTrigger("ButtonPressed");
    }

    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("Flavio_Beta_Level");
    }
}
