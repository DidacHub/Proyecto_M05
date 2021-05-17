using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool MoveRight;
    public Transform groundDetection;

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
        //AI Patrol
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if (MoveRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    MoveRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    MoveRight = true;
                }
            }
    }

    //Si le alcanza la bala del player se destruye
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
