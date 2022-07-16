using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private LayerMask enemyMask;

    protected override void Start()
    {
        base.Start();

        enemyMask = LayerMask.GetMask("Enemy");
    }

    // Убиваем всех врагов в поле зрения игрока
    public override void Shoot()
    {
        if (!isWeaponOnCooldown)
        {
            base.Shoot();

            Vector3 playerPosition = cameraTransform.parent.position;
            Collider[] enemyCollidersNearby = Physics.OverlapSphere(playerPosition, 30f, enemyMask);

            if (enemyCollidersNearby.Length > 0)
            {
                foreach (Collider enemyCollider in enemyCollidersNearby)
                {
                    Vector3 directionToEnemy = (enemyCollider.transform.position - playerPosition).normalized;
                    float dotProduct = Vector3.Dot(directionToEnemy, cameraTransform.forward);
                    Physics.Raycast(cameraTransform.position, directionToEnemy, out RaycastHit hitInfo, 100f, enemyAndObstaclesMask);
                    Collider hitCollider = hitInfo.collider;

                    if (dotProduct >= 0.66 && hitCollider == enemyCollider)
                    {
                        hitCollider.GetComponent<Enemy>().Die();
                    }
                }
            }
        }
    }
}
