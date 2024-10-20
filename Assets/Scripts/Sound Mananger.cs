using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundMananger : MonoBehaviour
{
    [Header ("-----Audio Source----")]
    [SerializeField] AudioSource musicSoruce;
    [SerializeField] AudioSource SFXSource;
    [Header ("-----Audio Clip----")]
    
    public AudioClip Background;
    public AudioClip Walk;
    public AudioClip Shot;
    public AudioClip Sword;

    private void Start() 
    {

     musicSoruce.clip = Background;
     musicSoruce.Play();
     
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    

    
}
