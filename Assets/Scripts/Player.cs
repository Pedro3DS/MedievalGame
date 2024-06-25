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

    private bool canTakeDamage = true;

    private SpriteRenderer render;
    private Animator anim;
    private Rigidbody2D rb2d;

    private float invencibleSeconds;

    public int lives;

    private void Awake()
    {
        lives = 7;
    }

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
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1 - (render.bounds.size.x / render.bounds.size.x);
            // UnityEngine.Debug.Log(Mathf.Abs(Camera.main.ScreenToWorldPoint(Vector3.zero).x));
            // UnityEngine.Debug.Log();
        }
        else if (newX > (Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1) - (render.bounds.size.x / render.bounds.size.x))
        {
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + (render.bounds.size.x / render.bounds.size.x);
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

        if (!canTakeDamage)
        {
            Invencible();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Invencible()
    {
        invencibleSeconds += Time.deltaTime;
      
        if (invencibleSeconds >= 2f)
        {
          
            canTakeDamage = true;
            invencibleSeconds = 0f;
      
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
        if (other.gameObject.CompareTag("WaterDrop") && canTakeDamage)
        {
            lives --;
            isAlive = false;
            canTakeDamage = false;
            
            //gameObject.SetActive(false);
            //Destroy(other.gameObject);
            
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
