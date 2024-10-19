using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public Health vida;
    public GameObject player;
    [SerializeField]
    private float speed;
    private float distance;

    private Animator animController;

    public float spriteScaleX;

    private void Start()
    {
        animController = GetComponent<Animator>();
    }

    void Update()
    {
        if(!vida.gameOver)
        {
        // Seguimiento al jugador sin rotaci�n
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animController.SetTrigger("Walking");

            if (direction.x > 0)  // Si el jugador está a la derecha
            {
                transform.localScale = new Vector3(spriteScaleX, transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x < 0)  // Si el jugador está a la izquierda
            {
                transform.localScale = new Vector3(-spriteScaleX, transform.localScale.y, transform.localScale.z);
            }

        }

        // Con rotaci�n

        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
