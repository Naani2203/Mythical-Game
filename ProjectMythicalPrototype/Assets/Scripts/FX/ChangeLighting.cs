using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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
    private bool _LightChange;
    ColorGrading color;
    PostProcessVolume ppv;
	// Use this for initialization
	void Start ()
    {
        _LightChange = false;
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out color);
        //color.postExposure.value = 5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
         
        
		
	}
    public void BeatChange()
    {
        if(color.postExposure.value<5 && _LightChange==false)
        {
           color.postExposure.value +=0.025f ;
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
                color.postExposure.value -=0.025f ;
            }

        }
    }
}
