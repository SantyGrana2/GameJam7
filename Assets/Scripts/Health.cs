using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //C�digo general para ajustar la vida y cuanto da�o se le hace al gameObject
    public int health;
    public int maxHealth;
    [SerializeField] private bool inmortal;
    private Animator animacionController;
    public bool gameOver = false;
    public GameOver endGame;
    private bool isDead;
    void Start()
    {
        health = maxHealth; 
        animacionController = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if(inmortal == false)
        {
            if(gameObject.CompareTag("Player") || gameObject.CompareTag("Enemy"))
            {
                animacionController.SetTrigger("Damage");

            } else if (gameObject.CompareTag("Enemy"))
            {
                animacionController.SetTrigger("Hurt");
            }

            health -= amount;
            if (health <= 0)
            {
                
                
                if(gameObject.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                    animacionController.SetBool("Death", true);
                }
                
                
                if(gameObject.CompareTag("Player"))
                {
                animacionController.SetTrigger("Muerte");
                animacionController.SetBool("Muerto",true);
                gameOver = true;
                isDead = true;
                endGame.End();
                }
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PuLife"))
        {
            inmortal = true;
            Destroy(other.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,250f,0f);
            StartCoroutine(ContadorPowerUp());
        }

        if(other.CompareTag("PuPlus"))
        {
            health += 30;
            if(health >=50)
            {
                health = 50;
            }
            Destroy(other.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,0f,0f);
            StartCoroutine(ContadorPowerUpVida());
        }
    }

      IEnumerator ContadorPowerUp()
    {
        yield return new WaitForSeconds(10); 
        inmortal = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);
        
    }

    IEnumerator ContadorPowerUpVida()
    {
        yield return new WaitForSeconds(2); 
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);
        
    }

}
