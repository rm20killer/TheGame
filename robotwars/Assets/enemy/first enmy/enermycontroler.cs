using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enermycontroler : MonoBehaviour
{

    public float lookradius = 100f;

    Transform target;
    NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        target = playermanger.instance.player.transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookradius) 
        {
            Agent.SetDestination(target.position);
        }
       
    }
}
