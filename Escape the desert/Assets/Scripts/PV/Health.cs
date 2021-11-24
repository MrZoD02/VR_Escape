using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healt;

    public void takeDamage(int damage)
    {
        Debug.Log("pv got down");
        healt -= damage;
    }
     public  virtual void goDie()
    {
        
    }
    
}
