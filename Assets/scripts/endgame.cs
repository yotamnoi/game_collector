using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class endgame : MonoBehaviour
{
    public leaderboard leaderboard;
    public TextMeshProUGUI finished_text;
    // Start is called before the first frame update
    void Start()
    {
        leaderboard.submit(menu_manager.instance.game_time);
    }

    // Update is called once per frame
    void Update()
    {
        finished_text.text = "well done.\r\nyou killed god in " + Math.Floor(menu_manager.instance.game_time).ToString() +
    " second and won the game congratz!\r\n\r\ni hope thatyou had fun!\r\n\r\nthanks for playing!    :)";
    }
}
