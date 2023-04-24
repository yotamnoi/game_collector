using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class shop_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject save;
    public Text score_text;
    public TextMeshProUGUI h1;
    private int frenzy_b_price;
    private int frenzy_p_price;
    private int die_faster_price;
    private int satan_almighty_price;
    private int killing_god_price;
    public TextMeshProUGUI explain_text;
    private string button_clicked_last;
    public Dictionary<string, string> explain_dict;
    public TextMeshProUGUI curropt_hum_price_txt;
    public TextMeshProUGUI blue_price_txt;
    public TextMeshProUGUI purple_price_txt;
    public TextMeshProUGUI faster_price_txt;
    public TextMeshProUGUI statan_almighty_price_txt;
    public TextMeshProUGUI gods_death_txt;



    private void Awake()
    {
        button_clicked_last = "welcome";
    }
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        frenzy_b_price = menu_manager.instance.frenzy_b_price;
        frenzy_p_price = menu_manager.instance.frenzy_p_price;
        die_faster_price = menu_manager.instance.die_faster_price;
        satan_almighty_price = menu_manager.instance.satan_almighty_price;
        killing_god_price = menu_manager.instance.killing_god_price;


        explain_dict = new Dictionary<string, string>()
        {
            {"welcome", "welcome to the shop\r\n\r\nhere tou can buy alot of great things that will help you to collect the souls faster.\r\n\r\n\r\nbtw here you can buy god's mercy as well :)\r\n" },
            {"currpt_humanity", "bring curraption to humanity \n makes every soul count as "
            + (menu_manager.instance.cur_hum_num).ToString() },
             {"frenzy_blue", "makes alot of blue souls for 10 sec" },
             {"frenzy_purple", "makes alot of purple souls for 10 sec" },
             {"die_faster", "makes people die faster by " + Mathf.Min(0.7f,menu_manager.instance.faster).ToString() + " seconds. \r\n\r\n the max amount is 0.7 sec."},
             {"satan_almighty", "makes satan (you) greater then god and allow you \n" +
             "to collect all kinds of souls including red ones" },
             {"killing_god", "well... thats about it... \r\nif you buy this one you won the game \r\nyou are free to do whatever you want after that :)" },

        };

        score_text.text = "souls: " + (menu_manager.instance.souls).ToString();
        curropt_hum_price_txt.text = (20 + Convert.ToInt32(Math.Floor(Math.Pow(2, menu_manager.instance.cur_hum_num)))).ToString();
        blue_price_txt.text = frenzy_b_price.ToString();
        purple_price_txt.text = frenzy_p_price.ToString();
        faster_price_txt.text = die_faster_price.ToString();
        statan_almighty_price_txt.text = satan_almighty_price.ToString();
        explain_text.text = explain_dict[button_clicked_last];
        h1.text = button_clicked_last;
        if (menu_manager.instance.souls >= 5000)
            gods_death_txt.text = killing_god_price.ToString(); 
        
    }

    public void currpt_humanity()
    {
        if (menu_manager.instance.souls >= 20 + Convert.ToInt32(Math.Floor(Math.Pow(2,menu_manager.instance.cur_hum_num))))
        {
            menu_manager.instance.souls -= 20+ Convert.ToInt32(Math.Floor(Math.Pow(2, menu_manager.instance.cur_hum_num)));
            menu_manager.instance.cur_hum += 1;
            menu_manager.instance.cur_hum_num += 1;
        }
    }

    public void frenzy_blue()
    {
        if (menu_manager.instance.souls >= frenzy_b_price)
        {
            menu_manager.instance.souls -= frenzy_b_price;
            menu_manager.instance.frenzy_blue += 1;
            menu_manager.instance.frenzy_b_price += 50;
        }
    }

    public void frenzy_purple()
    {
        if (menu_manager.instance.souls >= frenzy_p_price)
        {
            menu_manager.instance.souls -= frenzy_p_price;
            menu_manager.instance.frenzy_purple += 1;
            menu_manager.instance.frenzy_p_price += 200;
        }
    }

    public void die_faster()
    {
        if (menu_manager.instance.souls >= die_faster_price && menu_manager.instance.faster <=0.7 )
        {
            menu_manager.instance.souls -= die_faster_price;
            menu_manager.instance.faster += 0.1f;
            menu_manager.instance.die_faster_price += 100;
        }
        if(menu_manager.instance.faster > 0.61 && !menu_manager.instance.satan_is_stronger_than_god)
        {
            FindObjectOfType<audio_manager>().Stop("menu");
            FindObjectOfType<audio_manager>().Play("funky");
        }
          
    }
    public void satan_almighty()
    {
        if (menu_manager.instance.souls >= satan_almighty_price && !menu_manager.instance.satan_is_stronger_than_god)
        {
            menu_manager.instance.souls -= satan_almighty_price;
            menu_manager.instance.satan_is_stronger_than_god = true;

            FindObjectOfType<audio_manager>().Stop("funky");
            FindObjectOfType<audio_manager>().Stop("menu");
            FindObjectOfType<audio_manager>().Play("dark");
        }
    }
    public void killing_god()
    {
        if (menu_manager.instance.souls >= killing_god_price)
        {
            menu_manager.instance.souls -= killing_god_price;
            menu_manager.instance.end_game();
            menu_manager.instance.cur_hum = 200;
            menu_manager.instance.faster = 0.7f;
            menu_manager.instance.frenzy_blue = 100;
            menu_manager.instance.frenzy_purple = 100;
        }

        
    }


    public void button_picker()
    {
        button_clicked_last = EventSystem.current.currentSelectedGameObject.name ;
    }

    public void buy_picked()
    {
        Invoke(button_clicked_last, 0f);
    }
}
