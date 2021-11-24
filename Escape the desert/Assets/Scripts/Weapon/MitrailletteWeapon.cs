using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitrailletteWeapon : Weapon
{
    
    private float nextFireTime;
    private Vector3 destination;
    private bool _auto;

   // gun stats
   public float fireRate = 0.5f;
    public float Maxrange = 30;
    private RaycastHit hit;
    public override void Engage()
    {
        _auto = true;
    }

    public override void DisEngage()
    {
        _auto = false;
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            if (_auto)
            {
                fire();
            }
        }
    }

    private void fire()  // ici c'est la méthode ou l'on modifie la facon dont tire l'arme.
    {
        /// les fxs
        Debug.Log("shooot");
        
        
        if (Physics.Raycast(launchPoint.position,launchPoint.forward,out hit,Maxrange))// pour appliquer les degats
        {
            destination = hit.point;
            Debug.Log(hit.point);
            if (hit.transform.gameObject.CompareTag("Enemie"))
            {
                GameObject enemies = hit.transform.gameObject;
                enemies.GetComponent<Health>().takeDamage(degats);
                
            }
        }
    }
}
