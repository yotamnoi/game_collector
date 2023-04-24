using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collect : MonoBehaviour
{
    public TextMeshProUGUI blue_amount_txt;
    public TextMeshProUGUI purple_amount_txt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        blue_amount_txt.text = menu_manager.instance.frenzy_blue.ToString();
        purple_amount_txt.text = menu_manager.instance.frenzy_purple.ToString();
    }
}