using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField] private bool inmortal;
    void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage(int amount)
    {
        if(inmortal == true)
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
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,250f,0f);
            StartCoroutine(ContadorPowerUp());
        }
    }

      IEnumerator ContadorPowerUp()
    {
        yield return new WaitForSeconds(10); 
        inmortal = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);
        
    }

}
