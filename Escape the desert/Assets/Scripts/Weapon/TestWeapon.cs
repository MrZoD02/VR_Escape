using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestWeapon : MonoBehaviour
{
    private PlayerInput _playerInput;
    public GameObject effectTrail;
    public Transform raycastOrigin;
    public GameObject muzzleFlash;

    
    

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private Ray ray;
    private RaycastHit hitInfo;

    private void Update()
    {
        if (_playerInput.actions["Fire"].triggered)
        { 
            Engage();
        }
        
    }

    public void Engage()
    {
        ray.origin = raycastOrigin.position;
        muzzleFlash.SetActive(true);


        var tracer = Instantiate(effectTrail, ray.origin, Quaternion.identity);

        tracer.transform.position += tracer.transform.forward * 15 *Time.deltaTime;
        
        muzzleFlash.SetActive(false);
        
    }

    public void DisEngage()
    {
        muzzleFlash.SetActive(false);
    }
}
