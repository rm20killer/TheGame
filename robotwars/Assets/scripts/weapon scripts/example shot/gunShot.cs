﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class gunShot : MonoBehaviour
{
    public float Range = 100f;

    public GameObject impactEffect;
    private RaycastHit hit;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Physics.Raycast(ray, out hit, Range))
            {
                GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
                Destroy(impactEffectGO,5);

            }
        }
    }
}
