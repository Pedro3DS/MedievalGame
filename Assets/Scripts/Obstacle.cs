using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float gravitySpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, - gravitySpeed * Time.deltaTime, 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}