using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private bool isJumping = false;
    public bool isAlive = true;

    private SpriteRenderer render;
    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        Movimentando();
        Jump();
    }

    void Movimentando()
    {
        
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float currentX = transform.position.x;

        float newX = moveX + currentX;

        if (newX < Camera.main.ScreenToWorldPoint(Vector3.zero).x + (render.bounds.size.x / render.bounds.size.x))
        {
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + (render.bounds.size.x / render.bounds.size.x);
        }
        if (newX > Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1 - (render.bounds.size.x / render.bounds.size.x))
        {
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1 - (render.bounds.size.x / render.bounds.size.x);
        }
        transform.position = new Vector3(newX, transform.position.y, 0);
        anim.SetBool("Run", true);
        if (Input.GetAxis("Horizontal") > 0)
        {
            render.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            render.flipX = true;
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WaterDrop"))
        {
            isAlive = false;
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
