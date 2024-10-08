using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class CreateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform field;
    public GameObject scoreText;
    public string scores;
    public string[] playersList;
    public int[] scoresList;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        scores = PlayerPrefs.GetString("Score");
        scoresList = Array.ConvertAll(scores.Split("|"), int.Parse);
        playersList = PlayerPrefs.GetString("ScorePlayers").Split("|");
        //Array.Sort(scoresList);
        var PlayerInfos = scoresList.Zip(playersList, (point, player) => new { Point = point, Player = player });
        Dictionary<int, string> dict = new Dictionary<int, string>();
        foreach (var playerInfo in PlayerInfos)
        {
            dict.Add(playerInfo.Point, playerInfo.Player);
        };

        var sortedDict = dict.OrderByDescending(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);


        foreach (KeyValuePair<int, string> pair in sortedDict)
        {
            GameObject newScoreText = Instantiate(scoreText, field);
            newScoreText.GetComponent<TMP_Text>().text = $"{pair.Value} - {pair.Key}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
