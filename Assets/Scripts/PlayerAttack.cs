using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject meele;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    public Health enemy;

    [SerializeField]
    private int damage;

    public Transform aim;
    public GameObject bullet;
    public float fireForce;
    public float shootCooldown;
    public float shootTimer;

    private void Update()
    {
        CheckMeeleTimer();

        shootTimer = Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onAttack();
        }
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E))
        {
            OnShoot(); 
        }
    }

    void OnShoot()
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0f;
            GameObject instBullet = Instantiate(bullet, aim.position, aim.rotation);
            instBullet.GetComponent<Rigidbody2D>().AddForce(-aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(instBullet, 7f);
        }
    }

    void onAttack()
    {
        if (!isAttacking)
        {
            meele.SetActive(true);
            isAttacking = true;
        }
    }

    void CheckMeeleTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration)
            {
                atkTimer = 0f;
                isAttacking = false;
                meele.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isAttacking && other.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
    }
}
