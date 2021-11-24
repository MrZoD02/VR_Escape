using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealtEnemies : Health
{
   

   private void Update()
   {
      if (healt <= 0)
      {
         goDie();
      }
   }

   public override void goDie()
   {
      Debug.Log("enemies dead");
      Destroy(gameObject,1);
   }
}
