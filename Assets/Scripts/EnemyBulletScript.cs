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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    //Validación para optimizar, que cuando pasen 7 segundos se destruyan las balas
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
}
