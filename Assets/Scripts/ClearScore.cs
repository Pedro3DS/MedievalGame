using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScore : MonoBehaviour
{
    private string[] konamiCode = { "u", "u", "d", "d", "l", "r", "l", "r", "b", "a" };
    private string[] runningCode;

    private bool up = false;
    private bool down = false;
    private bool left = false;
    private bool right = false;

    private int codeIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        runningCode = new string[konamiCode.Length];
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Vertical") > 0 && !up)
        {
            up = true;
            codeIndex++;
            runningCode[codeIndex] = "u";
        }
        if (Input.GetAxis("Vertical") < 0 && !down)
        {
            down = true;
            codeIndex++;
            runningCode[codeIndex] = "d";
        }
        if (Input.GetAxis("Horizontal") > 0 && !right)
        {
            right = true;
            codeIndex++;
            runningCode[codeIndex] = "r";
        }
        if (Input.GetAxis("Horizontal") < 0 && !left)
        {
            left = true;
            codeIndex++;
            runningCode[codeIndex] = "l";
        }
        if (Input.GetAxis("Horizontal") < 0 && !left)
        {
            left = true;
            codeIndex++;
            runningCode[codeIndex] = "l";
        }
        if (Input.GetButtonDown("Fire1"))
        {
            codeIndex++;
            runningCode[codeIndex] = "a";
        }
        if (Input.GetButtonDown("Fire2"))
        {
            codeIndex++;
            runningCode[codeIndex] = "b";
        }
        if (runningCode[codeIndex] != konamiCode[codeIndex] && codeIndex >= 0)
        {
            codeIndex = -1;
            runningCode = new string[konamiCode.Length];
        }
        else if(runningCode[konamiCode.Length-1] == konamiCode[konamiCode.Length - 1] && codeIndex >= 0)
        {
            Debug.Log("Bingo");
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            right= false;
            left = false;
        }
        if(Input.GetAxis("Vertical") == 0)
        {
            down = false;
            up = false;

        }
    }
}
