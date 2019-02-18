using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("Transforms")]
   
    public  Transform _TopRune;
    public  Transform _LeftRune;
    public  Transform _RightRune;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject _GreenRunePrefab;
    [SerializeField]
    private GameObject _RedRunePrefab;
    [SerializeField]
    private GameObject _BlueRunePrefab;
    [SerializeField]
    private GameObject _Particle;


    [Header("UI")]
    [SerializeField]
    private GameObject _BlueRuneUI;
    [SerializeField]
    private GameObject _RedRuneUI;
    [SerializeField]
    private GameObject _GreenRuneUI;

    [Header("LightingChange")]
    [SerializeField]
    private ChangeLighting _ChangeLighting;
    private bool _IsLightChange;

    [Header("Audio")]
    [SerializeField]
    private AudioSource _PickUpFX;
    [SerializeField]
    private AudioClip _PickUpClip;

    public  float _SpeedOfRune;

    [HideInInspector]
    public bool IsGreenGem;
    [HideInInspector]
    public bool IsRedGem;
    [HideInInspector]
    public bool IsBlueGem;
    [HideInInspector]
    public bool IsAltar=false;

    private void Start()
    {
        IsGreenGem = false;
        IsRedGem = false;
        IsBlueGem = false;
        _IsLightChange = false;

    }
    private void Update()
    {
        if(IsAltar==true)
        {
            GemSpawn();
        }
        if(_IsLightChange)
        {
            _ChangeLighting.BeatChange();
        }
    }

    public void GemSpawn()
    {

        if (IsGreenGem == true)
        {
            GameObject _GreenGem = Instantiate(_GreenRunePrefab, transform.position, Quaternion.identity);
            _GreenGem.transform.position = Vector3.MoveTowards(_GreenGem.transform.position, _TopRune.position, _SpeedOfRune);
            _GreenRuneUI.SetActive(false);
            
                _IsLightChange = true;
                IsAltar = false;
            

            IsGreenGem = false;
        }
        if (IsRedGem == true)
        {
            GameObject _RedGem = Instantiate(_RedRunePrefab, transform.position, Quaternion.identity);
            _RedGem.transform.position = Vector3.MoveTowards(_RedGem.transform.position, _TopRune.position, _SpeedOfRune);
           
                IsRedGem = false;
            _RedRuneUI.SetActive(false);

        }
        if (IsBlueGem == true)
        {
            GameObject _BlueGem = Instantiate(_BlueRunePrefab, transform.position, Quaternion.identity);
            _BlueGem.transform.position = Vector3.MoveTowards(_BlueGem.transform.position, _TopRune.position, _SpeedOfRune);
            IsBlueGem = false;
            _BlueRuneUI.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="GreenPickUp")
        {
            Instantiate(_Particle, transform.position, Quaternion.identity);
            _PickUpFX.clip = _PickUpClip;
            _PickUpFX.Play();
            IsGreenGem = true;
            _GreenRuneUI.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "RedPickup")
        {
            Instantiate(_Particle, transform.position, Quaternion.identity);
            _PickUpFX.clip = _PickUpClip;
            _PickUpFX.Play();
            IsRedGem = true;
            _RedRuneUI.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "BluePickUp")
        {
            Instantiate(_Particle, transform.position, Quaternion.identity);
            _PickUpFX.clip = _PickUpClip;
            _PickUpFX.Play();
            IsBlueGem = true;
            _BlueRuneUI.SetActive(true);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Altar"))
        {
            IsAltar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Altar"))
        {
            IsAltar = false;
        }
    }



}
