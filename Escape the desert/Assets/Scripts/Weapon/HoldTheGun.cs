using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HoldTheGun : Weapon
{
    public bool isgrab = false;
    public InputActionReference _playerInput;
    private Transform poigneveuttirer;
    public MitrailletteWeapon _weapon;
    public GameObject launchPOINT;
    
    private void Start()
    {
        _weapon = launchPOINT.GetComponent<MitrailletteWeapon>();
    }

    public void Grabb(SelectEnterEventArgs args)
    {
        Debug.Log("Grab");
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


        Vector3 lookCible = (2 * transform.position - poigneveuttirer.position);
        transform.LookAt(lookCible);



        if (_playerInput.action.ReadValue<float>() > 0)
        {

            if (Time.time >= nextFireTime)
            { nextFireTime = Time.time + fireRate; 
                Debug.Log("shoot");
                fire();
            }
        }
    }

    ///////////////////////////////////////////////////////////////
       ///
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
      /* public override void Engage()
       {
           _auto = true;
       }

       public override void DisEngage()
       {
           _auto = false;
       }*/
       public void fire()  // ici c'est la méthode ou l'on modifie la facon dont tire l'arme.
       {
           Ray ray = new Ray(launchPOINT.transform.position,launchPOINT.transform.forward);
           // shoot + dgt
           if (Physics.Raycast(ray,out hit,Maxrange))// pour appliquer les degats
           {
               /// les fxs
               Debug.Log("shooot");
               //destination = ray.GetPoint(Maxrange);
            
            
               //raycastDestination = hit.transform;
               //ray.origin = raycastOrigin.position;
               //ray.direction = raycastDestination.position - raycastOrigin.position;
               muzzleFlash.SetActive(true);
               //var tracer = Instantiate(effectTrail, launchPOINT.transform.position, Quaternion.identity,null);
               //tracer.transform.position += tracer.transform.forward * 15 *Time.deltaTime



               Debug.Log(hit.point);
               if (hit.transform.gameObject.CompareTag("Enemie"))
               {
                  // GameObject enemies = hit.transform.gameObject;
                //   enemies.GetComponent<Health>().takeDamage(degats);
               }
           }
           //Dans tous les cas
           var tracer = Instantiate(effectTrail, launchPOINT.transform.position, Quaternion.identity,null);
           tracer.transform.LookAt( launchPOINT.transform.position +  launchPOINT.transform.forward);
       }

    }


