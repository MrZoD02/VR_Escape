using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HoldTheGun : MonoBehaviour
{
    public bool isgrab = false;
    public InputActionReference _playerInput;
    private Transform poigneveuttirer;
    public MitrailletteWeapon _weapon;
    
    private void Start()
    {

        _weapon = GetComponent<MitrailletteWeapon>();
    }

    public void Grabb(SelectEnterEventArgs args)
    {
        poigneveuttirer = args.interactorObject.transform;
        isgrab = true;
    }

    public void Ungrabb(SelectExitEventArgs args)
    {
        isgrab = false;
    }
// axes y et z 
// fuck l'axe X

    private void Update()
    {
        if (!isgrab)
            return;

        Debug.Log("ca tire");
        Debug.Log(poigneveuttirer.transform.position);
        Vector3 lookCible = (2 * transform.position - poigneveuttirer.position);
        transform.LookAt(lookCible);


        {
            if (_playerInput.action.ReadValue<float>() > 0)
                if (Time.time >= _weapon.nextFireTime)
                {
                    _weapon.nextFireTime = Time.time + _weapon.fireRate;
                    _weapon.fire();
                }

            Debug.Log("shooo this on click");

        }
    }
}
