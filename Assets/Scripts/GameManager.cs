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
    private float spawnCadense;
    private float spawnLimit = 2f;
    private float seconds;
    private float gameTime = 60f;
    private float obstacleSpeed = 1f;
    public GameObject player;

    private Gamepad pad;
    private Coroutine stopRumbleCoroutine;

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
            pad = Gamepad.current;
            if (pad != null) {
                pad.SetMotorSpeeds(0.125f, 0.500f);
                stopRumbleCoroutine = StartCoroutine(StopRumble(0.2f, pad));
            }
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

    private IEnumerator StopRumble(float durations, Gamepad gamepad)
    {
        float time = 0f;
        while (time < durations)
        {
            time += Time.deltaTime;
            yield return null;
        }

        gamepad.SetMotorSpeeds(0f, 0f);
    }
}
