using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    EnemyHealth myHealth;
    PlayerHealth playerHealth;
    NavMeshAgent myLegs;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        myHealth = GetComponent<EnemyHealth>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        myLegs = GetComponent<NavMeshAgent>();
    }
    void Update ()
    {
        if (myHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            myLegs.SetDestination (player.position);
        }
        else
        {
            myLegs.enabled = false;
        }
    }
}
