using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float leftLimit;
    public float rightLimit;

    private SpriteRenderer render;

    private Animator anim;


    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    { 
        Movimentando();
   
    }

    void Movimentando()
    {

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;


        float currentX = transform.position.x;

        float newX = moveX + currentX;

        if (newX < Camera.main.ScreenToWorldPoint(Vector3.zero).x + (render.bounds.size.x / 2))
        {
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + (render.bounds.size.x / 2);
        }
        if (newX > Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1 - (render.bounds.size.x / 2))
        {
            newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1 - (render.bounds.size.x / 2);
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
}
