using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    private float moveRight;
    private bool facingRight = true;
    public float jump;
    public Transform player;
    public Transform groundCheck;
    private bool isGrounded;
    private bool canSeePlayer;
    Vector2 boxsize;
    [SerializeField] Vector2 lineofSite;
    LayerMask Player;

    Animator animator;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxsize, 0);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineofSite, 0);
        /*  if (!canSeePlayer && isGrounded)
          {
              //Animator de estar en idle

          }*/
        JumpAttack();

    }

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (isGrounded)
        {
            rb.AddForce(new Vector2(distanceFromPlayer, jump), ForceMode2D.Impulse);
        }
    }

    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition < 0 && facingRight)
        {
            sprite.flipX = true;
        }
        else if (playerPosition > 0 && !facingRight)
        {
            sprite.flipX = false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineofSite);
    }

    //Si le alcanza la bala del player se destruye
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }

    
}
