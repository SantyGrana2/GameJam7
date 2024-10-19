using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Health healthBoss;
    public Health healthPlayer;
     public GameObject[] gameObjectsToActivate; // Array de GameObjects para activar
    private int currentIndex = 0;   
    private bool isSpawningActive = false; 
    public GameObject itemPrefab; // Prefab del ítem que aparecerá
    private bool itemSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
           
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!healthPlayer.gameOver)
        {

        // Verifica si la salud del jefe está por debajo de la mitad
            if (healthBoss.health <= healthBoss.maxHealth / 2 && !isSpawningActive)
            {
                // Inicia la invocación repetida si no ha comenzado ya
                if (currentIndex == 0) // Esto asegura que no se inicie varias veces
                {
                    InvokeRepeating("ActivateNextGameObject", 2f, 5f); 
                    isSpawningActive = true;// Empieza después de 2 segundos y repite cada 5 segundos
                }
            }

            if (healthBoss.health <= 0)
            {
                // Detener la invocación si está activa
                CancelInvoke("ActivateNextGameObject");
                isSpawningActive = false; // Cambia el estado para evitar múltiples invocaciones
                
                // Desactivar todos los GameObjects
                foreach (GameObject obj in gameObjectsToActivate)
                {
                    obj.SetActive(false);
                }
            }

            if(healthPlayer.health <= healthPlayer.maxHealth/2 && !itemSpawned)
            {
                // Instancia el ítem en la posición del jugador
                Instantiate(itemPrefab, Vector2.zero, Quaternion.identity);
                itemSpawned = true;
            } else if(healthPlayer.health == healthPlayer.maxHealth)
            {
                itemSpawned = false;
            }
        }
    }

    void ActivateNextGameObject()
    {
        if (currentIndex < gameObjectsToActivate.Length)
        {
            // Activar el siguiente GameObject en la lista
            gameObjectsToActivate[currentIndex].SetActive(true);
            currentIndex++;
        }
        else
        {
            // Cuando todos los GameObjects estén activados, detener la invocación
            CancelInvoke("ActivateNextGameObject");
            isSpawningActive = false;
        }


    }

    
 

   
}
