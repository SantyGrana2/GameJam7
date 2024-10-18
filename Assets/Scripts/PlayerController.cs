using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controllerPlayer;
    public GameObject bullet;
    public Transform ShootPosition;

    private float movX,movY;
    public float multiplierSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controllerPlayer = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        controllerPlayer.Move(Vector2.right * movX * multiplierSpeed * Time.deltaTime + Vector2.up * movY * multiplierSpeed * Time.deltaTime) ;

        if(Input.GetButtonDown("Jump"))
        {
                Shoot();
        }

        // Comprobar si hay alguna tecla presionada
        if (Input.anyKeyDown)
        {
            RotationPlayer();
        }


    }

    void RotationPlayer()
    {
        // Obtener la última tecla presionada
            string input = Input.inputString;

           // Rotar según la tecla presionada
            switch (Input.inputString.ToLower()) // Convertimos a minúsculas para simplificar
            {
                case "w":
                    // Mirar hacia arriba
                    transform.rotation = Quaternion.Euler(0, 0, 0); // 0 grados
                    break;

                case "a":
                    // Mirar hacia la izquierda
                    transform.rotation = Quaternion.Euler(0, 0, 90); // 270 grados
                    break;

                case "s":
                    // Mirar hacia abajo
                    transform.rotation = Quaternion.Euler(0, 0, 180); // 180 grados
                    break;

                case "d":
                    // Mirar hacia la derecha
                    transform.rotation = Quaternion.Euler(0, 0, 270); // 90 grados
                    break;

                default:
                    // Tecla no reconocida
                    break;
            }
    }

    void Shoot()
    {
        Instantiate(bullet, ShootPosition.transform.position, transform.rotation);
    }
}
