using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private float _ElapsedTime;
    private Vector3 _Offset;
    private Quaternion _RotationalOffset;
    private bool _IsCameraShake=false;
    

    private void Update()
    {
       if(_IsCameraShake==true)
        {
            StartCoroutine(CameraShake(0.3f, 0.08f));

        }
        
    }
    public void CameraShake()
    {
        _IsCameraShake = true;
    }

    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 _OriginalPos = transform.localPosition;
        Quaternion _OriginalRot = transform.localRotation;
        _Offset = _OriginalPos;

        _ElapsedTime = 0.0f;

        while(_ElapsedTime<duration)
        {
            _Offset.x += Random.Range(-1f, 1f)*magnitude;
            _Offset.y += Random.Range(-1f, 1f)*magnitude;
            _RotationalOffset = _OriginalRot * Quaternion.Euler(1*magnitude, 1 * magnitude, 1 * magnitude); 
            transform.localPosition = _Offset;
            transform.localRotation = _RotationalOffset;
            yield return null;

            _ElapsedTime += Time.deltaTime;

        }
        transform.localPosition = _OriginalPos;
        transform.localRotation = _OriginalRot;
        _IsCameraShake = false;
    }
	
}
