using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGuy : MonoBehaviour
{
    public List<Transform> movementPoints;
    public Animator anim;
    public float enemyRange;
    public float followRange;
    private Transform _Player;
    public float attackDelay;
    [HideInInspector]
    public Vector3 target;
    public GameObject Projectile;
    public GameObject Platform;
    public Transform firePos;
    [HideInInspector]
    public float flyingHeight;
    [SerializeField]
    private float _StompForce;

    private Rigidbody _Rb;

    [Header("Audio")]
    [SerializeField]
    private AudioSource _Source;
    [SerializeField]
    private AudioClip _StompSound;
    [SerializeField]
    private AudioClip _ShootSound;

    void Start ()
    {
        _Player = GameObject.Find("Player").transform;
        flyingHeight = transform.position.y;
        _Rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        RayCast();
        CheckRange();
        if (anim.GetBool("isGroundStomp") == true)
        {
            _Source.clip = _StompSound;
            
        }
        if (anim.GetBool("isRangedAttack") == true)
        {
            _Source.clip = _ShootSound;
           
        }


    }

    void CheckRange()
    {

        if (Vector3.Distance(_Player.position, transform.position) > enemyRange)
        {
            anim.SetBool("isPatrol", true);
            anim.SetBool("isInrange", false);
        }
       else if (Vector3.Distance(_Player.position, transform.position) < enemyRange)
        {
            anim.SetBool("isPatrol", false);
            anim.SetBool("isSpotted", true);
            anim.SetBool("isInrange", true);
        }
        if(anim.GetBool("canFollow")==false)
        {
            anim.SetBool("isPatrol", true);
            anim.SetBool("isInrange", false);
            
        }
    }
    void RayCast()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
           if(hit.collider.gameObject == Platform)
            {
                if (Vector3.Distance(_Player.position, transform.position) < followRange)
                {
                    anim.SetBool("canFollow", true);
                    
                }
                else
                {
                    anim.SetBool("canFollow", false);
                }
            }
        }
        else
        {
            anim.SetBool("canFollow", false);
            anim.SetBool("isPatrol", true);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
       // StartCoroutine(_CameraHolder.CameraShake(_DurationofCameraShake, _MagnitudeofCameraShake));
        if(collision.gameObject.name=="Player" && collision.collider.GetType()== typeof(CapsuleCollider))
        {
            if(anim.GetBool("isGroundStomp")==true)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * _StompForce,ForceMode.Impulse);
            }
           
        }
        if(collision.gameObject.CompareTag("Level"))
        {
            _Rb.velocity = Vector3.zero;
        }

        

    }
}
