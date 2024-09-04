using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateUserName : MonoBehaviour
{
    public TMP_InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("Player", playerName.text.ToString());

    }
    
}
