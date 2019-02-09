using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spearguy : MonoBehaviour
{
    public List<Transform> movementPoints;
    public Animator anim;
    public NavMeshAgent NavMeshAgent;
    public float enemyRange;
    private Transform _Player;
    public float attackDelay;
    public float dashSpeed;
    private EnemyHealth _Health;
    private bool _IsDeathAnim;
    [HideInInspector]
    public Vector3 target;
    private AudioSource _AudioSource;
    public AudioClip DashClip;
    public AudioClip Scream;
    [SerializeField]
    private AudioClip _DeadClip;

   
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Player = GameObject.Find("Player").transform;
        _Health = GetComponent<EnemyHealth>();
        _IsDeathAnim = false;
    }

    void Update()
    {
        if (_Health.CurrentHealth>0)
        {
            if (Mathf.Abs(_Player.position.sqrMagnitude - transform.position.sqrMagnitude) > Mathf.Abs(enemyRange*enemyRange))
            {
                anim.SetBool("isPatrol", true);
                anim.SetBool("isInrange", false);
            }
            if (Vector3.Distance(_Player.position,transform.position) < enemyRange)
            {      
                anim.SetBool("isPatrol", false);
                anim.SetBool("isSpotted", true);
                anim.SetBool("isInrange", true);
            }

        }

        if(_Health.CurrentHealth==0 && _IsDeathAnim==false)
        {
            _AudioSource.clip = _DeadClip;
            _AudioSource.Play();
            anim.SetTrigger("Dead");
            Destroy(gameObject, 10f);
            _IsDeathAnim = true;
        }

    }
}
