using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{

    public static score_manager instance;
    public Text score_text;
    public TextMeshProUGUI time_game_text;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        score_text.text = "souls: " + (menu_manager.instance.souls).ToString();
    }

    public void add_points(int add_score)
    {
        menu_manager.instance.souls += add_score;
        score_text.text = "souls: " + (menu_manager.instance.souls).ToString();
       


    }
    // Update is called once per frame
    void Update()
    {
        time_game_text.text = "time:" + Math.Floor(menu_manager.instance.game_time).ToString() + "sec";
    }
}
