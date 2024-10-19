using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Código general para ajustar la vida y cuanto daño se le hace al gameObject
    public int health;
    public int maxHealth;
    [SerializeField] private bool inmortal;
    void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage(int amount)
    {
        if(inmortal == false)
        {
            health -= amount;
            if (health <= 0)
            {
                Destroy(gameObject);
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
