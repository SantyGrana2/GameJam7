using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
   

    private float timer;

    //El cooldown que tiene el enemigo para disparar
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    //Lugar y prefab donde se instancian las balas
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
