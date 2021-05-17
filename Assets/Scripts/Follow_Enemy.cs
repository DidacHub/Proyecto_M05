using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Enemy : MonoBehaviour
{
    public bool MoveRight;
    public float speed;
    public float WaitTime;
    public float lineOfSite;
    private Vector2 CurrentPos;
    private GameObject player;
    private float WaitedTime = 0f;
    private bool firstTimeSeen = true;
    
    Animator animator;
    public SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        float distanceFromPlayer = 10000;

        if (firstTimeSeen)
        {
            if (WaitedTime > WaitTime)
            {
                firstTimeSeen = false;
                WaitedTime = 0;
            }
        }
        else {
            if (player.transform.position.x > transform.position.x) {
                MoveRight = true;
            }
            else if (player.transform.position.x < transform.position.x)
            {
                MoveRight = false;
            }
            if (MoveRight)
            {
                transform.Translate(2 * delta * speed, 0, 0);
                sprite.flipX = true;
            }
            else
            {
                transform.Translate(-2 * delta * speed, 0, 0);
                sprite.flipX = false;
            }

            if (distanceFromPlayer > lineOfSite)
            {
                MoveRight = false;
                firstTimeSeen = true;
                CurrentPos = transform.position;
            }
           
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
