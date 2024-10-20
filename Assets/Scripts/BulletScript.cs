using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damageBullet;

    //Cuando la bala encuentre un enemigo quitarle vida
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.TakeDamage(damageBullet);
        }
    }
}
