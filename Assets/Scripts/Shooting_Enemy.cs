using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{
    public bool MoveRight;
    public float speed;
    public GameObject bulletEnemy;
    public float fireRate = 1f;
    public float timeToShoot;
    public float nextFireTime;
    public float shootingRange;
    
    bool canShoot;

    private GameObject player;

    Animator animator;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        nextFireTime = 0;
        timeToShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;

        //Contador de tiempo
        if (canShoot == false) {
            timeToShoot += delta;
            if (timeToShoot > fireRate) {
                canShoot = true;
                timeToShoot = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        float distanceFromPlayer = 10000;
        if (player != null) {
            distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        }

        //si al distancia del player es inferior al shootingRage puede disparar
        if (distanceFromPlayer < shootingRange) {
            canShoot = true;
            bulletEnemy = Instantiate(bulletEnemy, transform.position + transform.right * -1 * 40, transform.rotation);
            Destroy(bulletEnemy, 4);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(this.gameObject);
        }
    }
}
