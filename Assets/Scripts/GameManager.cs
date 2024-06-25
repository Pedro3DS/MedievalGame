using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Obstacle drop;
    public TMP_Text gameSeconds;
    public TMP_Text gameLives;
    private float spawnCadense;
    private float spawnLimit = 2f;
    private float seconds;
    private float gameTime = 60f;
    private float obstacleSpeed = 1f;
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameLives.text = $"Vidas: {player.GetComponent<Player>().lives}";
        spawnCadense += Time.deltaTime;
        

        seconds += Time.deltaTime;
        gameSeconds.text = $"{gameTime - Mathf.Round(seconds)}";

        

        if(spawnCadense >= spawnLimit)
        {
            Obstacle newObstacle = Instantiate(drop);
            float spawnIndex = Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).x, Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1);
            newObstacle.transform.position = new Vector2(spawnIndex, Camera.main.ScreenToWorldPoint(Vector3.zero).y * -1);
            obstacleSpeed+=0.5f;
            newObstacle.gravitySpeed += obstacleSpeed;
            if(spawnLimit >= 0.6f)
            {
                spawnLimit -= 0.1f;
            }
            spawnCadense = 0f;
            
        }
        Win();
        GameOver();
    }

    void GameOver()
    {
        if(!player.GetComponent<Player>().isAlive)
        {
            spawnLimit = 2f;
            obstacleSpeed = 1f;
            seconds = 0f;
            player.transform.position = new Vector3(0f, -2.05f, 0f);
            player.GetComponent<Player>().isAlive = true;

        }
        if (player.GetComponent<Player>().lives == 0)
        {
            SceneManager.LoadScene("LoseScene");

        }
    }

    void Win()
    {
        if (gameTime - Mathf.Round(seconds) == 0)
        {
            SceneManager.LoadScene("WinScene");//TODO
        }
    }
}
