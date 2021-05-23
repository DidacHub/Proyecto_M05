using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{

    private float moveRight;
    private bool facingRight = true;
    public Transform player;
   
   
    public float nextFireTime;
    public float shootingRange;
    public GameObject bulletEnemy;
    public float fireRate = 1f;

    Rigidbody2D rb;
    Animator animator;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextFireTime = 0;
    }

    private void FixedUpdate()
    {
     
        float distanceFromPlayer = 100000;
        if (player != null) {
            distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        }

        float delta = Time.fixedDeltaTime * 1000;
        nextFireTime += delta;

        //si al distancia del player es igual o inferior al shootingRage puede disparar
        if (distanceFromPlayer <= shootingRange) {
            checkIfTimeToFire();
        }

    }

    void checkIfTimeToFire() {

        if (nextFireTime > fireRate) {
            GameObject bulletE = Instantiate(bulletEnemy, transform.position + transform.right * -1, transform.rotation);
            Destroy(bulletE, 4);
            nextFireTime = 0;
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(this.gameObject);
        }
    }
}
