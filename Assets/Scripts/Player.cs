using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Start()
    {

        UnityEngine.Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(gameObject.transform.position);
        Movimentando();
    }

    void Movimentando()
    {

        if (gameObject.transform.position.x < -12)
        {
            transform.Translate(0f, 0f, 0f);
            if (Input.GetKey(KeyCode.D))
            {
                //gameObject.transform.position = new Vector2(0, 5);
                transform.Translate(0.1f, 0f, 0f);

            }
        }
        else if (gameObject.transform.position.x > 12)
        {
            transform.Translate(0f, 0f, 0f);
            if (Input.GetKey(KeyCode.A))
            {
                //gameObject.transform.position = new Vector2(0, 5);
                transform.Translate(-0.1f, 0f, 0f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                //gameObject.transform.position = new Vector2(0, 5);
                transform.Translate(0.1f, 0f, 0f);

            }

            if (Input.GetKey(KeyCode.A))
            {
                //gameObject.transform.position = new Vector2(0, 5);
                transform.Translate(-0.1f, 0f, 0f);
            }
        }

        

    }
}
