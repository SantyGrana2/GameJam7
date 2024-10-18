using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject meele;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    public Health[] enemies;

    [SerializeField]
    private int damage;

    public Transform aim;
    public GameObject bullet;
    public float fireForce;
    public float shootCooldown;
    public float shootTimer;
    public int damageBullet;

    private void Update()
    {
        CheckMeeleTimer();

        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onAttack();
        }
        if (Input.GetMouseButton(0))
        {
            OnShoot(); 
        }
    }

    void OnShoot()
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0f;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector2 shootDirection = (mousePos - aim.position).normalized;

            GameObject instBullet = Instantiate(bullet, aim.position, aim.rotation);
            instBullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * fireForce, ForceMode2D.Impulse);
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
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
