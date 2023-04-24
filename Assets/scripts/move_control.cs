using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move_control : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject soul_pop;
    [SerializeField] private GameObject popup;
   

    public int speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
           
    }

    void Update()
    {
        rb.velocity = new Vector2 (speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.name == "blue_soul(Clone)")
        {
            PopDmg(2 * menu_manager.instance.cur_hum);
            Destroy(gameObject);
            score_manager.instance.add_points(2 * menu_manager.instance.cur_hum);
            FindObjectOfType<audio_manager>().Play("vanish");
            
        }

        if (Input.GetMouseButtonDown(0) && gameObject.name == "purple_soul(Clone)")
        {
            PopDmg(10 * menu_manager.instance.cur_hum);
            dmg_popup.itself.textColor = Color.green;
            dmg_popup.itself.TextMeshPro.color = Color.green;
            Destroy(gameObject);
            score_manager.instance.add_points(10 * menu_manager.instance.cur_hum);
            FindObjectOfType<audio_manager>().Play("vanish");

        }
        if (Input.GetMouseButtonDown(0) && gameObject.name == "red_soul(Clone)")
        {
            FindObjectOfType<audio_manager>().Play("vanish");
            Destroy(gameObject);
            if (menu_manager.instance.satan_is_stronger_than_god)
            {
                score_manager.instance.add_points(5 * menu_manager.instance.cur_hum);
                PopDmg(5 * menu_manager.instance.cur_hum);
            }
            else
            {
                PopDmg(-5 * menu_manager.instance.cur_hum);
                dmg_popup.itself.textColor = Color.red;
                dmg_popup.itself.TextMeshPro.color = Color.red;
                score_manager.instance.add_points(menu_manager.instance.cur_hum * -5);
            }
               

        }
    }

    public void PopDmg(int amount)
    {
        soul_pop = Instantiate(popup);
        soul_pop.transform.position = transform.position;
        dmg_popup.itself.TextMeshPro.text = amount.ToString();

    }

}
