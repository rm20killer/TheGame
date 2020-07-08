using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public int starthealth;

    public void AIDamgeTaken(int damage)
    {
        health = health - damage;
        //heathbar.fillAmount = health / starthealth;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
