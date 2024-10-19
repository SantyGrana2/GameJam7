using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopButton : MonoBehaviour
{
    [SerializeField] private GameObject botonStop;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Menu();
            }

        }
        
    }
    public void Menu()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonStop.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
         juegoPausado = false;
        Time.timeScale = 1f;
        botonStop.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reinicar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

