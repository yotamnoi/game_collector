using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] pgs;

    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        for (int i = 0; i < pgs.Length; i++)
        {
            if (i == counter)
                pgs[i].SetActive(true);
            else
                pgs[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        counter++;
        if (counter == pgs.Length){
            menu_manager.instance.start_game();
        }
        for (int i = 0; i < pgs.Length; i++)
        {
            if (i == counter)
                pgs[i].SetActive(true);
            else
                pgs[i].SetActive(false);
        }
    }
    public void back()
    {
        counter --;
        if (counter < 0)
            counter = 0;
        if (counter == pgs.Length)
        {
            menu_manager.instance.start_game();
        }
        for (int i = 0; i < pgs.Length; i++)
        {
            if (i == counter)
                pgs[i].SetActive(true);
            else
                pgs[i].SetActive(false);
        }
    }

    public void skip()
    {
        counter = pgs.Length - 1;
        next();
    }
}
