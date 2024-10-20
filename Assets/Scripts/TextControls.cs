using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextControls : MonoBehaviour
{
    public GameObject[] textObjects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerupText"))
        {
            // Activa el texto correspondiente al cofre según el nombre del cofre
            foreach (GameObject textObject in textObjects)
            {
                // Activa el texto si coincide el nombre del cofre y el texto
                if (textObject.name == "Text_" + collision.gameObject.name) // Asegúrate que los nombres coincidan
                {
                    textObject.SetActive(true); // Activa el texto
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerupText"))
        {
            // Desactiva el texto correspondiente al cofre según el nombre del cofre
            foreach (GameObject textObject in textObjects)
            {
                if (textObject.name == "Text_" + collision.gameObject.name)
                {
                    textObject.SetActive(false); // Desactiva el texto
                }
            }
        }
    }
}
