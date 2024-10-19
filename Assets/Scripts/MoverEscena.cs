using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoverEscena : MonoBehaviour
{
    
    public bool tocoPuerta;
    public GameObject puerta1,puerta2;
   // public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoverPuertas();


    }
        
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            GameObject puerta = GameObject.Find("BloqueoPuerta");
            Destroy(puerta);
            tocoPuerta = true;
        }
    }
    
    void MoverPuertas()
    {
        GameObject enemy1 = GameObject.Find("EnemyMeele");
        GameObject enemy2 = GameObject.Find("EnemyMeele (1)");

        if(enemy1 == null && enemy2 == null && puerta1 != null)
        {
            puerta1.transform.Translate(Vector2.up * 0.01f);
            if(puerta1.transform.position.y > 15f)
            {
                Destroy(puerta1);
            }
        }

        GameObject enemy3 = GameObject.Find("EnemyMeele (2)");
        GameObject enemy4 = GameObject.Find("EnemyMeele (3)");

        if(enemy3 == null && enemy4 == null && puerta2 != null)
        {
            puerta2.transform.Translate(Vector2.up * 0.01f);
            if(puerta2.transform.position.y > 15f)
            {
                Destroy(puerta2);
            }
        }
    }

    
}
