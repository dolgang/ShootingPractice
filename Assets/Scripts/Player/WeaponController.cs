using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class WeaponController : MonoBehaviour
{
    public Weapon curWeapon;
    public Transform equipParent;
    private PlayerController controller;

    public GameObject equipPrefab;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        EquipNew();
    }

    public void OnFireInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            curWeapon.IsAttacking = true;
        }
        else
        {
            curWeapon.IsAttacking = false;
        }
    }

    public void EquipNew()
    {
        //UnEquip();
        curWeapon = Instantiate(equipPrefab, equipParent).GetComponent<Weapon>();
    }
}
