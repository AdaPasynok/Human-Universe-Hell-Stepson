using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPistol : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [Min(1)]
    [SerializeField] private int fireRate = 1; // Пули в секунду

    private Transform cameraTransform;
    private AudioSource audioSource;
    private bool isWeaponOnCooldown = false;

    protected override void Start()
    {
        base.Start();
        cameraTransform = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
    }

    public override void TryToTargetPlayer(Vector3 playerPosition)
    {
        if (CheckPlayer(playerPosition))
        {
            if (!isWeaponOnCooldown)
            {
                Vector3 directionToPlayerFace = (cameraTransform.position - transform.position).normalized;
                Shoot(directionToPlayerFace);
                isWeaponOnCooldown = true;
                StartCoroutine(CooldownWeapon());
            }
        }
        else if (isPlayerDetected)
        {
            Chase(playerPosition);
        }
    }

    private void Shoot(Vector3 direction)
    {
        audioSource.Play();
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.direction = direction;
        isPlayerDetected = true;
        navMeshAgent.isStopped = true;
    }

    private IEnumerator CooldownWeapon()
    {
        yield return new WaitForSeconds(1f / fireRate);
        isWeaponOnCooldown = false;
    }
}
