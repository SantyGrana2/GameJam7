using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    SoundMananger soundMananger;

    //Variables ataque corta distancia
    public GameObject meele;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    public Health[] enemies;

    [SerializeField]
    private int damage;

    //Variables ataque a larga distancia 
    public Transform aim;
    public GameObject bullet;
    public float fireForce;
    public float shootCooldown;
    public float shootTimer;
    public int damageBullet;
    private Animator animacionController;

    
    void Start()
    {
        animacionController = GetComponent<Animator>();
        
    }
    private void Update()
    {
        soundMananger = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMananger>();

        CheckMeeleTimer();

        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundMananger.PlaySFX(soundMananger.Sword);
            animacionController.SetTrigger("AtackMelee");
            onAttack();

        }
        if (Input.GetMouseButtonDown(0))
        {
            soundMananger.PlaySFX(soundMananger.Shot);
            animacionController.SetTrigger("Attack");
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

             // Encuentra el GameObject "punta" dentro de la flecha instanciada
            Transform punta = instBullet.transform.Find("punta");

            if (punta != null)
            {
                // Calcula la rotación para que la punta apunte hacia la dirección del disparo
                float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                instBullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

                // Aplica la fuerza desde la dirección de la punta
                instBullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * fireForce, ForceMode2D.Impulse);
            }
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

    //Cuando el objeto meele entra en contacto con un enemigo le quita vida
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (isAttacking && other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }

        if(other.CompareTag("PupShoot"))
        {
            fireForce = 20;
            Destroy(other.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(58,236f,17f);
            StartCoroutine(ContadorPowerUpDisparo());
        }

    }

    void Damage()
    {
        animacionController.SetTrigger("Damage");
    }

    IEnumerator ContadorPowerUpDisparo()
    {
        yield return new WaitForSeconds(2); 
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);
        
    }
}
