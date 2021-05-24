using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject Wall;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    private bool shielded;




    // Start is called before the first frame update
    void Start()
    {
        shielded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       CheckShield();

       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if (Input.GetButtonDown("Jump"))
       {
            jump = true;
            animator.SetBool("Jumping", true);
       }
      
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    
    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    void CheckShield()
    {
        if (Input.GetKey(KeyCode.H)&&!shielded)
        {
            Wall.SetActive(true);
            shielded = true;

            Invoke("NoShield", 3f);
        }
    }
    void NoShield()
    {
        Wall.SetActive(false);
        shielded = false;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "finale")
        {
            SceneManager.LoadScene("Win");
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "BulletEnemy")
        {
            Destroy(this.gameObject);
        }
    }

    
}

