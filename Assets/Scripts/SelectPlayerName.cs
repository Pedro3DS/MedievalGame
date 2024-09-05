using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerName : MonoBehaviour
{
    private string[] characters = { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","0","1","2","3","4","5","6","7","8","9",".","_","-","+","*","," };
    public TMP_Text[] lettersField;
    private int lettersFieldIndex = 0;
    public Dictionary<int, int> charFields;
    private bool movedRight = false;
    private bool movedLeft = false;
    private bool movedUp = false;
    private bool movedDown = false;

    public string playerName;

    void Start()
    {
        lettersField[lettersFieldIndex].fontStyle = FontStyles.Underline;

        charFields = new Dictionary<int, int>(lettersField.Length-1);

        for(int i = 0; i < lettersField.Length; i++)
        {
            charFields.Add(i, 0);
        }
    }

    void Update()
    {
 
        ChangeLetterIndex();
        ChangeLetterChar();

        if (Input.GetButtonDown("Start"))
        {
            for (int i = 0; i < lettersField.Length; i++)
            {
                playerName += lettersField[i].text;
            }
            PlayerPrefs.SetString("Player", playerName);
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void ChangeLetterChar()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || (Input.GetAxis("Vertical") > 0 && !movedUp))
        {
            movedUp = true;
            if (charFields[lettersFieldIndex] >= characters.Length - 1)
            {

                charFields[lettersFieldIndex] = 0;
            }
            else
            {
                charFields[lettersFieldIndex]++;

            }
            //Debug.Log(charFields[lettersFieldIndex]);


        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || (Input.GetAxis("Vertical") < 0 && !movedDown))
        {
            movedDown = true;
            if (charFields[lettersFieldIndex] <= 0)
            {
                charFields[lettersFieldIndex] = characters.Length -1;
            }
            else
            {
                charFields[lettersFieldIndex]--;

            }
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            movedUp = false;
            movedDown = false;
        }
        lettersField[lettersFieldIndex].text = characters[charFields[lettersFieldIndex]];
    }

    private void ChangeLetterIndex()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || (Input.GetAxis("Horizontal") > 0 && !movedRight))
        {
            movedRight = true;
            if (lettersFieldIndex >= lettersField.Length - 1)
            {

                lettersFieldIndex = 0;
            }
            else
            {
                lettersFieldIndex++;

            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || (Input.GetAxis("Horizontal") < 0 && !movedLeft))
        {
            movedLeft = true;
            if (lettersFieldIndex <= 0)
            {

                lettersFieldIndex = lettersField.Length - 1;
            }
            else
            {
                lettersFieldIndex--;

            }
            
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            movedRight = false;
            movedLeft = false;
        }
        RemoveUnderline(lettersField);
        UnderlineTxt(lettersFieldIndex);
    }


    private void UnderlineTxt(int index)
    {
        lettersField[lettersFieldIndex].fontStyle = FontStyles.Underline;
    }

    private void RemoveUnderline(TMP_Text[] letters)
    {
        foreach (var letter in letters)
        {

            letter.fontStyle = FontStyles.Normal;
        }
    }
}
