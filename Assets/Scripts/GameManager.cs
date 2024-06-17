using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    //public GameObject spawn;

    private float spawnCadense;
    private float spawnSeconds;

    public GameObject[] spawn;

    private System.Random rdn;

    void Start()
    {
        rdn = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        spawnCadense += Time.deltaTime;
        
        if(spawnCadense >= 2f)
        {
            int spawnIndex = rdn.Next(0, spawn.Length-1);
            Instantiate(ball, spawn[spawnIndex].transform.position, Quaternion.identity);
            spawnCadense = 0f;
        }
        
    }
}
