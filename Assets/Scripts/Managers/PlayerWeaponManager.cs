using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private GameObject characterSelectScreen;
    [SerializeField] private PortraitGameplay portraitGameplay;

    private Weapon selectedWeapon;

    public void SelectWeapon(string weaponType)
    {
        int index = 0;

        switch (weaponType)
        {
            case "Pistol":
                index = 0;
                break;
            case "Shotgun":
                index = 1;
                break;
            case "Submachine Gun":
                index = 2;
                break;
            default:
                Debug.LogError("Wrong weapon type");
                break;
        }

        selectedWeapon = weapons[index];
        GameManager.Instance.SetSkull(index);
        characterSelectScreen.SetActive(false);
        GameManager.Instance.playerInput.SwitchCurrentActionMap("Player");
        Cursor.lockState = CursorLockMode.Locked;
        selectedWeapon.gameObject.SetActive(true);
        portraitGameplay.SetPortrait(index);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            selectedWeapon.Shoot();
            selectedWeapon.isHoldingShootButton = true;
        }
        else if (context.canceled)
        {
            selectedWeapon.isHoldingShootButton = false;
        }
    }
}
