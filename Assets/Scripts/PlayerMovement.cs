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

    private Animator animacionController;

    public Health vida;

    public float spriteScaleX;
    //[SerializeField] private AnimationClip animacionCaminar;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacionController = GetComponent<Animator>();
    }

    void Update()
    {
        //Guardar la �ltima direcci�n en la que se movi�
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0) && !vida.gameOver)
        {
            
            isWalking = false;
            lastMoveDirection = input;
            Vector3 vec3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vec3);

        } else if (moveX != 0 || moveY != 0 && !vida.gameOver)
        {
            
            isWalking = true;
            animacionController.SetTrigger("Walking");
        }

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (input.x > 0)  // Movimiento hacia la derecha
        {
            gameObject.transform.localScale = new Vector3(spriteScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (input.x < 0)  // Movimiento hacia la izquierda
        {
            gameObject.transform.localScale = new Vector3(-spriteScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        if(!vida.gameOver)
        {
            rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
            if (isWalking )
            {
                
                Vector3 vec3 = Vector3.left * input.x + Vector3.down * input.y;
                aim.rotation = Quaternion.LookRotation(Vector3.forward, vec3);
            }
        }
    }
}
