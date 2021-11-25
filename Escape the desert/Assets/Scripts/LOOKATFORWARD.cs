using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOKATFORWARD : MonoBehaviour
{

    public GameObject referent;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = referent.transform.rotation;
    }
}
