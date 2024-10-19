using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeeleAttack : MonoBehaviour
{
    public Health playerHealth;

    [SerializeField]
    private int damage;

    //Cuando el enemigo haga una colisi�n con el jugador quitarle vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerHealth.gameOver)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
