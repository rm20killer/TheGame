using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enermycontroler : MonoBehaviour
{

    public float lookradius = 100f;
    public float attackrange = 1f;
    private float firerate = 20f;
    private float nexttimetofire = 0;


    #region damageStuff
    private RaycastHit hit;
    private Ray ray;
    public int damage = 10;
    #endregion
    Transform player;
    NavMeshAgent Agent;
    private string targethit;

    // Start is called before the first frame update
    void Start()
    {
        player = playermanger.instance.player.transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookradius) 
        {
            Agent.SetDestination(player.position);
        }

        //all below dont work
        //   if (distance <= attackrange && Time.time >= nexttimetofire)
        //   {
        //       nexttimetofire = Time.time + 1f / firerate;
        //       //attack animation
        //            Debug.Log("ai shot");
        //       Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), attackrange);
        //       targethit = hit.transform;
        //       if (targethit== "playercontroler")
        //       { 
        // healthbar target = player.GetComponent<healthbar>();
        //if (target == player)
        //        {
        //            Debug.Log("hit");
        //            target.onDamgeTaken(damage);
        //            // deal damage
         //       }
          //      else
            //    {
              //      Debug.Log("ai missed");
                //}
           // }
        //}
        
    }

}
