using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public int starthealth;

    private GameObject objspawn;
    private int SpawnerID;
    private void Start()
    {
        objspawn = (GameObject)GameObject.FindWithTag("Spawner ");
    }
    public void AIDamgeTaken(int damage)
    {
        health = health - damage;
        Debug.Log("EnemyHIT");
        //heathbar.fillAmount = health / starthealth;
        if (health <= 0)
        {
            Debug.Log("Enemyat0HP");
            Die();
        }
    }
    void Die()
    {
        Debug.Log("DIE");
        objspawn.BroadcastMessage("killEnemy", SpawnerID);
        Destroy(gameObject);
    }
    void setName(int sName)
    {
        SpawnerID = sName;
    }
}
