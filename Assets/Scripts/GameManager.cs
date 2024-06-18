using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public TMP_Text score;
    public TMP_Text gameSeconds;
    //public GameObject spawn;

    private float spawnCadense;

    public GameObject[] spawn;

    private float seconds;

    private System.Random rdn;

    public GameObject player;

    void Start()
    {
        rdn = new System.Random();
        gameSeconds.text = "50";
  
    }

    // Update is called once per frame
    void Update()
    {
        spawnCadense += Time.deltaTime;
        

        seconds += Time.deltaTime;
        gameSeconds.text = $"{50 - Mathf.Round(seconds)}";

        if(50 - Mathf.Round(seconds) == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(spawnCadense >= 2f)
        {
            int spawnIndex = rdn.Next(0, spawn.Length-1);
            Instantiate(ball, spawn[spawnIndex].transform.position, Quaternion.identity);
            spawnCadense = 0f;
        }


        GameOver();
    }

    void GameOver()
    {
        if(!player.GetComponent<Player>().isAlive)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
