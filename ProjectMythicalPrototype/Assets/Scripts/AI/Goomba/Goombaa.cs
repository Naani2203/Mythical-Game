using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Goombaa : MonoBehaviour
{
    public  List<Transform> movementPoints;
    public Animator anim;
    public NavMeshAgent NavMeshAgent;
    public float enemyRange;
    [HideInInspector]
    public bool InRange;
    private Transform _Player;
    private EnemyHealth _Health;
    [SerializeField]
    private GameObject _HealthBar;
    [SerializeField]
    private GameObject _GrootParts;

    void Start()
    {
        _Player = GameObject.Find("Player").transform;
        _Health = GetComponent<EnemyHealth>();

    }

    void Update()
    {
        if(Vector3.Distance(_Player.position,transform.position)> (enemyRange)&& movementPoints.Count != 0)
        {
            anim.SetBool("isPatrol", true);
            anim.SetBool("isFollow", false);
            _HealthBar.SetActive(false);
        }
        if (Vector3.Distance(_Player.position, transform.position) <= enemyRange )
        {
            InRange = true;
            anim.SetBool("isFollow", true);
            _HealthBar.SetActive(true);
            
        }
        if(movementPoints.Count==0 && Vector3.Distance(_Player.position, transform.position) > enemyRange )
        {
          
            anim.SetBool("isPatrol", false);
            _HealthBar.SetActive(false);

        }
        if (Vector3.Distance(_Player.position, transform.position) > (enemyRange))
        {
            anim.SetBool("isFollow", false);
            _HealthBar.SetActive(false);
        }
        if(_Health.CurrentHealth==0)
        {
            Instantiate(_GrootParts, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
   

}
