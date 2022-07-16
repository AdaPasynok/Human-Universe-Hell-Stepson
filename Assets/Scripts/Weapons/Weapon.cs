using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public abstract class Weapon : MonoBehaviour
{
    [Range(0.1f, 20f)]
    [SerializeField] protected float fireRate = 20; // Пули в секунду

    protected LayerMask enemyAndObstaclesMask;
    protected GameObject muzzleFlash;
    protected Transform cameraTransform;
    protected AudioSource audioSource;
    protected bool isWeaponOnCooldown = false;

    [HideInInspector] public bool isHoldingShootButton = false;

    protected virtual void Start()
    {
        enemyAndObstaclesMask = LayerMask.GetMask("Default", "Enemy");
        muzzleFlash = transform.GetChild(0).gameObject;
        cameraTransform = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Shoot()
    {
        audioSource.Play();
        isWeaponOnCooldown = true;
        muzzleFlash.SetActive(true);
        muzzleFlash.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-20f, 20f));
        StartCoroutine(HideMuzzleFlash());
        StartCoroutine(CooldownWeapon());
    }

    protected IEnumerator HideMuzzleFlash()
    {
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
    }

    protected IEnumerator CooldownWeapon()
    {
        yield return new WaitForSeconds(1f / fireRate);
        isWeaponOnCooldown = false;
    }
}
