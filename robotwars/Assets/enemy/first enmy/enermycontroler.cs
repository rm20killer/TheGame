using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enermycontroler : MonoBehaviour
{

    public float lookradius = 100f;
    public float attackrange = 1f;



    #region damageStuff
    private RaycastHit hit;
    private Ray ray;
    public int damage = 10;
    #endregion
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
       
        if (distance <= attackrange)
        {
            //attack animation
            Debug.Log("ai shot");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), attackrange))
             
            {
                if (hit.transform.gameObject.CompareTag("Player")) 
                {
                    // deal damage
                    Playerhit();
                }
                else
                {
                    Debug.Log("ai missed");
                }
            }
        }
    }

    void Playerhit()
    {

        Debug.Log("hit");
        //deal damage to player
    }
}
