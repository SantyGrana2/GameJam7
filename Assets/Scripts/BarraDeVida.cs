using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;

    
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }
    public void CambiatVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }
    public void IniciarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiatVidaActual(cantidadVida);
    }

    

}
