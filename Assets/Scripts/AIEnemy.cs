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

    void Update()
    {
        if(!vida.gameOver)
        {
        // Seguimiento al jugador sin rotaci�n
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }

        // Con rotaci�n

        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
