using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    public Image heathbar;
    public int health;
    public int starthealth;

    public void onDamgeTaken(int damage) 
    {
        health = health - damage;
        heathbar.fillAmount = health / starthealth;
        if (health>=0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
