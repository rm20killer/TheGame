using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class bullet : MonoBehaviour
{

    public float bulletspeed = 100f;
    public int damage = 10;
    Rigidbody RB;
    Transform player;
    Vector3 MoveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        player = playermanger.instance.player.transform;
        MoveDirection = (player.transform.position - transform.position).normalized * bulletspeed;
        RB.velocity = new Vector3(MoveDirection.x, MoveDirection.z);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            healthbar healthbar = other.transform.GetComponent<healthbar>();
            Debug.Log("AI hit");
            healthbar.onDamgeTaken(damage);
        }
    }
}
