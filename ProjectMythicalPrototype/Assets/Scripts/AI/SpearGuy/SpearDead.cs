using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDead : MonoBehaviour
{
    [SerializeField]
    private EnemyHealth _EnemyHealth;
    [SerializeField]
    private Animator _Anim;

    private void Update()
    {
        if(_EnemyHealth.CurrentHealth==0)
        {
            _Anim.SetBool("IsDead", true);
            Destroy(gameObject, 45f);
        }
    }


}
