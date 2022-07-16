using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGun : Pistol
{
    [SerializeField] private float playerSpeed = 3f; // Дебафф скорости игрока

    protected override void Start()
    {
        base.Start();

        GameManager.Instance.player.movementSpeed = playerSpeed;
    }

    private void Update()
    {
        if (isHoldingShootButton)
        {
            Shoot();
        }
    }
}
