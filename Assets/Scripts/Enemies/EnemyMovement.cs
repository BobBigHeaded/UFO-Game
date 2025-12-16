using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject player;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //set seed
        Random.InitState(System.DateTime.Now.Millisecond);
        //Set random offset for the UFO body to feel like they are flying
        _agent.baseOffset = Random.Range(2f, 3f);
    }
    
    private void Update()
    {
        //if the enemy is within stopping distance we'll change direction
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            //new destination within 4 - 6 steps
            _agent.destination = GetRandomDirection();
        }
    }

    private Vector3 GetRandomDirection()
    {
        //Get random rotation for a random direction
        transform.Rotate(0, Random.Range(0, 360), 0);
        var newGoal = transform.position + (transform.forward * Random.Range(2f, 4f));
        
        return newGoal;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
