using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    public GameObject flash_text;
    public GameObject flash_arrow;
    [SerializeField]
    float diss_time = 5f;
    float diss_time_first = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        flash_text.SetActive(false);
        flash_arrow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if ((menu_manager.instance.souls > 35) && (menu_manager.instance.cur_hum < 2))
        {
            flash_text.SetActive(true);
            flash_arrow.SetActive(true);

            diss_time_first -= Time.deltaTime;
            if (diss_time_first < 0)
            {
                flash_text.SetActive(false);
                flash_arrow.SetActive(false);
            }
        }

        if ((menu_manager.instance.souls > 120)&&(menu_manager.instance.cur_hum < 3))
        {
            flash_text.SetActive(true);
            flash_arrow.SetActive(true);

            diss_time -= Time.deltaTime;
            if (diss_time < 0)
            {
                flash_text.SetActive(false);
                flash_arrow.SetActive(false);
            }

        }
    }

}
