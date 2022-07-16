using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerAndObstaclesMask;

    protected NavMeshAgent navMeshAgent;
    protected bool isPlayerDetected = false;

    protected virtual void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected bool CheckPlayer(Vector3 playerPosition)
    {
        Vector3 directionToPlayer = (playerPosition - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hitInfo, 100f, playerAndObstaclesMask))
        {
            return hitInfo.collider.CompareTag("Player");
        }

        return false;
    }

    protected void Chase(Vector3 destination)
    {
        isPlayerDetected = false;
        navMeshAgent.isStopped = false;
        navMeshAgent.destination = destination;
    }

    public void Die()
    {
        GameManager.Instance.SubtractEnemy();
        Destroy(gameObject);
    }

    public abstract void TryToTargetPlayer(Vector3 playerPosition);
}
