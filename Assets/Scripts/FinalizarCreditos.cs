using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalizarCreditos : MonoBehaviour
{
    public int siguienteEscena;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }


     // Método que será llamado al final de la animación
    public void OnCreditsEnd()
    {
        // Cambia la escena (reemplaza "SceneName" por el nombre de la escena que quieras cargar)
        SceneManager.LoadScene(siguienteEscena);
    }
 
}
