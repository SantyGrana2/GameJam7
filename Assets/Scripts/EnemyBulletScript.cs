using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    private float timer;
    public int damageBullet;

    //Disparar hacia donde esta el jugador
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        MoveArrow();
        
    }

    //Validaci�n para optimizar, que cuando pasen 7 segundos se destruyan las balas
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 7)
        {
            Destroy(gameObject);
        }
    }

    //Cuando la bala encuentre al jugador le quite vida
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.TakeDamage(damageBullet);
            Destroy(gameObject);
        }
    }

    private void MoveArrow()
    {
        // Calcula la dirección desde la flecha hacia el jugador
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Encuentra el GameObject "punta" dentro de la flecha
        Transform punta = gameObject.transform.Find("punta");

        if (punta != null)
        {
            // Calcula la rotación para que la punta apunte hacia el jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Aplica la velocidad a la flecha en la dirección del jugador
            rb.velocity = direction * force;
        }

    }
}
