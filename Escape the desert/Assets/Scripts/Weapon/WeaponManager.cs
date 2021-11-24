using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public Weapon activeWeapon;
    public Weapon[] weapons;
    public int activeWeaponID;
    public  PlayerInput _playerInput;
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        weapons = GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons)
        {
           weapon.gameObject.SetActive(false);
        }
        weapons[activeWeaponID].gameObject.SetActive(true);
    }

    void Update()
    {
        
        if (_playerInput.actions["Fire"].IsPressed())
        {
            weapons[activeWeaponID].Engage();
        }
        else
        {
            weapons[activeWeaponID].DisEngage();
        }
    }

    private void Changeweapon()
    {
        weapons[activeWeaponID].gameObject.SetActive(false);
        activeWeaponID++;
        if (activeWeaponID >= weapons.Length)
        {
            activeWeaponID = 0;
        }
        weapons[activeWeaponID].gameObject.SetActive(true);
    }
    
}
