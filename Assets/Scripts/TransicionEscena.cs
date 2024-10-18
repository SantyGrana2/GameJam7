using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    private Animator animator;
    public int siguienteEscena;
    private MoverEscena puerta;
    [SerializeField] private AnimationClip animacionFinal;
    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
         puerta = FindObjectOfType<MoverEscena>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puerta.tocoPuerta)
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(siguienteEscena);

    }

}
