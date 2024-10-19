using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SoundMananger soundMananger;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;

    public Transform aim;
    bool isWalking = false;
    public bool tocoPuerta = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Guardar la �ltima direcci�n en la que se movi�
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            
            isWalking = false;
            lastMoveDirection = input;
            Vector3 vec3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vec3);

        } else if (moveX != 0 || moveY != 0)
        {
            
            isWalking = true;
        }

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
        if (isWalking)
        {
            Vector3 vec3 = Vector3.left * input.x + Vector3.down * input.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vec3);
        }
    }
}
