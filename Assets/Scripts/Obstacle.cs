using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float gravitySpeed;
    public float bottom;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, - gravitySpeed * Time.deltaTime, 0f);
        if(transform.position.y < bottom){
            Destroy(gameObject);
        }
    }


}
