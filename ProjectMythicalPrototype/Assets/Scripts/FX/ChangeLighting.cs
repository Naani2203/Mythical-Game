using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class ChangeLighting : MonoBehaviour
{
    [SerializeField]
    private GameObject _NightLight;
    [SerializeField]
    private GameObject _DayLight;
    [SerializeField]
    private GameObject _NightAbience;
    [SerializeField]
    private GameObject _DayAmbience;
    [SerializeField]
    private AudioSource _Audio;
    private bool _LightChange;
    private bool _IsEndGame;
    ColorGrading color;
    PostProcessVolume ppv;
	
	void Start ()
    {
        _LightChange = false;
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out color);
        
	}
	
    public void BeatChange()
    {
        if(color.postExposure.value<5 && _LightChange==false)
        {
            _Audio.Play();
           color.postExposure.value +=0.050f ;
        }
       else if(color.postExposure.value>=5)
        {
            _LightChange = true;
        }
        if(_LightChange==true)
        {
            _NightLight.SetActive(false);
            _NightAbience.SetActive(false);
            _DayAmbience.SetActive(true);
            _DayLight.SetActive(true);
            if(color.postExposure.value>0)
            {
                color.postExposure.value -=0.050f ;
            }

        }
    }
    public void EndGame()
    {
        //if (color.postExposure.value < 2.5 && _IsEndGame == false)
        //{
        //    color.postExposure.value += 0.050f;
        //}
        //else if (color.postExposure.value >= 2.5)
        //{
        //    _IsEndGame = true;
        //}
        //if(_IsEndGame==true)
        //{
        //    SceneManager.LoadScene("EndCredit");
        //}
    }

}
