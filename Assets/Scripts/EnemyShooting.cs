using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Health vida;
    private Animator animatorController;
    private float timer;

    public GameObject player;
    public float spriteScaleX;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    //El cooldown que tiene el enemigo para disparar
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2 && !vida.gameOver)
        {
            timer = 0;
            Shoot();
        }

        FlipTowardsPlayer();
    }

    //Lugar y prefab donde se instancian las balas
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        animatorController.SetTrigger("Dispara");
    }

    void FlipTowardsPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;

        if (direction.x > 0)  // El jugador está a la derecha
        {
            transform.localScale = new Vector3(spriteScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)  // El jugador está a la izquierda
        {
            transform.localScale = new Vector3(-spriteScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}
