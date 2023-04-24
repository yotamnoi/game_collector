using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menu_manager : MonoBehaviour
{
    public static menu_manager instance;
    public float game_time;
    [SerializeField]
    private GameObject panel;
    public GameObject manager;
    public int souls;
    public float faster;
    public int cur_hum;
    public int cur_hum_num;
    public int frenzy_blue;
    public int frenzy_purple;
    public bool satan_is_stronger_than_god = false;
    public int frenzy_b_price = 100;
    public int frenzy_p_price = 300;
    public int die_faster_price = 300;
    public int satan_almighty_price = 2500;
    public int killing_god_price = 10000;
    public bool visit_store = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        cur_hum = 1;
        cur_hum_num = 2;
        faster = 0.1f;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void start_game()
    {
        SceneManager.LoadScene("game_play");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
        
    }

    public void quit_game()
    {
        Application.Quit();
    }

    public void shop()
    {
        SceneManager.LoadScene("shop");
        visit_store = true;
    }
    public void howto()
    {
        Instantiate(panel);
    }
    public void cont_game()
    {
        
        SceneManager.LoadScene("game_play");

    }
    public void end_game()
    {
        SceneManager.LoadScene("end_game");
       

    }
}
