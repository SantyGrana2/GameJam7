using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoverEscena : MonoBehaviour
{
    
    public bool tocoPuerta;
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
        if(other.CompareTag("Player"))
        {
            
            tocoPuerta = true;
        }
    }
    

    
}
