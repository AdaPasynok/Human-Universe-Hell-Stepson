using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFists : Enemy
{
    public override void TryToTargetPlayer(Vector3 playerPosition)
    {
        if (CheckPlayer(playerPosition))
        {
            Chase(playerPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
