using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class BeamLockMissilleWeapon : Weapon
{
    public float maxRange = 30.0f;
    public GameObject missileProj;
    public MissileTarget missileTarget;
    public RaycastHit[] hits;
    public List<Transform> target;
    Color lineColor = Color.red;
    public float witdhLine = 0.3f;
    
    private LineRenderer lineRenderer;
    private bool isBeam;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        missileTarget = GetComponent<MissileTarget>();
        // set up line renderer
        lineRenderer.startWidth = witdhLine;lineRenderer.endWidth = witdhLine;
        lineRenderer.startColor = lineColor; lineRenderer.endColor = lineColor;
        isBeam = false;
    }
    public override void Engage()
    {
        lineRenderer.enabled = true;
        isBeam = true;
    }
    public override void DisEngage()
    {
        int i = 0;
        foreach (var VARIABLE in target)
        {
            GameObject missile = Instantiate (missileProj,gameObject.transform.position, Quaternion.identity);
            missileGoTarget(missile,target[i]);
            i++;
        }
        target = new List<Transform>();
        lineRenderer.enabled = false;
        isBeam = false;
    }
    private void Update()
    {
        if (isBeam)
        {
            fire();
        }
    }
    private void fire()
    {
        hits = Physics.RaycastAll(launchPoint.position, launchPoint.forward, maxRange);
        int i = 0;
        foreach (var VARIABLE in hits)
        {
            RaycastHit hit = hits[i];
            GameObject killed = hit.transform.gameObject;
            if (!target.Contains(killed.transform))
            {
                target.Add(killed.transform);
            }
            i++;
        }
        /// Draw line
        lineRenderer.SetPosition(0,launchPoint.position);
        Vector3 endCast = launchPoint.position;
        endCast.z = maxRange;
        lineRenderer.SetPosition(1,endCast);
    }

    public void missileGoTarget(GameObject proj, Transform trans)
    {
        proj.GetComponent<MissileTarget>().target = trans;
    }
}
