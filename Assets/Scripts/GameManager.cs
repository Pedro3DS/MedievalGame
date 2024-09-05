using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Obstacle drop;
    public TMP_Text gameSeconds;
    public TMP_Text gameLives;
    public TMP_Text gamePoints;
    private float spawnCadense;
    private float spawnLimit = 2f;
    private float obstacleSpeed = 1f;
    public GameObject player;

    private Gamepad pad;
    private Coroutine stopRumbleCoroutine;

    void Start()
    {
        PlayerPrefs.SetInt("Points", 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameLives.text = $"Vidas: {player.GetComponent<Player>().lives}";
        spawnCadense += Time.deltaTime;

        gamePoints.text = $"{PlayerPrefs.GetInt("Points")}";



        

        if(spawnCadense >= spawnLimit)
        {
            Obstacle newObstacle = Instantiate(drop);
            float spawnIndex = Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).x, Camera.main.ScreenToWorldPoint(Vector3.zero).x * -1);
            newObstacle.transform.position = new Vector2(spawnIndex, Camera.main.ScreenToWorldPoint(Vector3.zero).y * -1);
            obstacleSpeed+=0.5f;
            newObstacle.gravitySpeed += obstacleSpeed;
            
            if (spawnLimit >= 0.6f)
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
            //spawnLimit = 2f;
            //obstacleSpeed = 1f;
            player.transform.position = new Vector3(0f, -2.05f, 0f);
            player.GetComponent<Player>().isAlive = true;

        }
        if (player.GetComponent<Player>().lives == 0)
        {

            if (PlayerPrefs.GetString("Score") != "")
            {
                PlayerPrefs.SetString("Score", PlayerPrefs.GetString("Score") + "|" + PlayerPrefs.GetInt("Points").ToString());
                PlayerPrefs.SetString("ScorePlayers", PlayerPrefs.GetString("ScorePlayers").ToString() + "|" + PlayerPrefs.GetString("Player"));
            }
            else
            {
                PlayerPrefs.SetString("Score", PlayerPrefs.GetInt("Points").ToString());
                PlayerPrefs.SetString("ScorePlayers", PlayerPrefs.GetString("Player"));
            }
            SceneManager.LoadScene("LoseScene");


        }
    }

    void Win()
    {
        if (PlayerPrefs.GetInt("Points") >= 9999)
        {
            SceneManager.LoadScene("WinScene");//TODO
        }
    }

}
