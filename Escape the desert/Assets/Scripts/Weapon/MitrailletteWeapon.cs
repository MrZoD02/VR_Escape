using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitrailletteWeapon : Weapon
{
    
    
    public float nextFireTime;
    private Vector3 destination;
    private bool _auto;
// FX
    public GameObject effectTrail;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public GameObject muzzleFlash;
    private Ray ray;

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
                Debug.Log("shoot");
                fire();
            }
        }
    }

  public void fire()  // ici c'est la méthode ou l'on modifie la facon dont tire l'arme.
    {
        
         
        Ray ray = new Ray(launchPoint.position,launchPoint.forward);
         // shoot + dgt
         if (Physics.Raycast(ray,out hit,Maxrange))// pour appliquer les degats
        {
            /// les fxs
            Debug.Log("shooot");
            destination = ray.GetPoint(Maxrange);
            
            
            raycastDestination = hit.transform;
            ray.origin = raycastOrigin.position;
            ray.direction = raycastDestination.position - raycastOrigin.position;
            muzzleFlash.SetActive(true);
        
            var tracer = Instantiate(effectTrail, ray.origin, Quaternion.identity);
            tracer.transform.position += tracer.transform.forward * 15 *Time.deltaTime;
           
            
           
            Debug.Log(hit.point);
            if (hit.transform.gameObject.CompareTag("Enemie"))
            {
                GameObject enemies = hit.transform.gameObject;
                enemies.GetComponent<Health>().takeDamage(degats);
            }
        }
    }
}
