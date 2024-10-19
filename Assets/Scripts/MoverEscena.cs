using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoverEscena : MonoBehaviour
{
    
    public bool tocoPuerta;
    private float numerosEnemigos;
   // public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            GameObject puerta = GameObject.Find("BloqueoPuerta");
            Destroy(puerta);
            tocoPuerta = true;
        }
    }
    

    
}
