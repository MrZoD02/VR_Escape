using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MissileTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    private Rigidbody _rb;
 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision other)
    {
        HealtEnemies damaged = other.transform.GetComponent<HealtEnemies>();
        BeamLockMissilleWeapon degat = GetComponent<BeamLockMissilleWeapon>();
        if (!damaged)
        {
            damaged.takeDamage(degat.degats);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * speed;
    }
    
}
