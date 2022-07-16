using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if (!isWeaponOnCooldown)
        {
            base.Shoot();

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitInfo, 100f, enemyAndObstaclesMask))
            {
                Collider hitCollider = hitInfo.collider;

                if (hitCollider.CompareTag("Enemy"))
                {
                    hitCollider.GetComponent<Enemy>().Die();
                }
            }
        }
    }
}
