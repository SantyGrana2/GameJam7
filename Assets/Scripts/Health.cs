using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Código general para ajustar la vida y cuanto daño se le hace al gameObject
    public int health;
    public int maxHealth;
    void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
