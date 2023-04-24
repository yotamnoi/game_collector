using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class random_spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] souls;
    private GameObject soul;
    private int random_index_blue;
    private int random_index_purple;
    private float random_pos_y;
    private float skill_time;
    private bool skill_activated = false;

    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine(summoner_normal());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        menu_manager.instance.game_time += Time.deltaTime;
    }
    IEnumerator summoner_normal()
    {
        while (!skill_activated)
        {
            random_index_blue = Random.Range(1, 3);
            random_index_purple = Random.Range(1, 20);

            yield return new WaitForSecondsRealtime(Mathf.Max(0.1f, 0.8f - menu_manager.instance.faster));

            if (random_index_blue == 1)
            {
                random_pos_y = Random.Range(-3.0f, 2.5f);
                soul = Instantiate(souls[0]);
                soul.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + random_pos_y, gameObject.transform.position.z);
                souls[0].GetComponent<move_control>().speed = Random.Range(2, 8);
            }
            else
            {
                random_pos_y = Random.Range(-3.0f, 2.5f);
                soul = Instantiate(souls[2]);
                soul.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + random_pos_y, gameObject.transform.position.z);
                souls[2].GetComponent<move_control>().speed = Random.Range(1, 6);
            }
            if (random_index_purple == 1)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                random_pos_y = Random.Range(-3.0f, 2.7f);
                soul = Instantiate(souls[1]);
                soul.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + random_pos_y, gameObject.transform.position.z);
                souls[1].GetComponent<move_control>().speed = Random.Range(4, 8);
            }

        }
    }

    public void summon_blue()
    {
        if (!skill_activated && menu_manager.instance.frenzy_blue>0)
        {
            menu_manager.instance.frenzy_blue -= 1;
            skill_activated = true;
            StopCoroutine(summoner_normal());
            StartCoroutine(summoner_blue());
        }
        
    }
    IEnumerator summoner_blue()
    {
        if (!menu_manager.instance.satan_is_stronger_than_god)
        {
            FindObjectOfType<audio_manager>().Stop("menu");
            FindObjectOfType<audio_manager>().Play("funky");
        }
            
        skill_time = menu_manager.instance.game_time;
        
        while (menu_manager.instance.game_time - skill_time < 10)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            random_pos_y = Random.Range(-3.0f, 2.5f);
            soul = Instantiate(souls[0]);
            soul.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + random_pos_y, gameObject.transform.position.z);
            souls[0].GetComponent<move_control>().speed = Random.Range(2, 8);

        }

        skill_activated = false;
        if (!menu_manager.instance.satan_is_stronger_than_god)
        {
            FindObjectOfType<audio_manager>().Stop("funky");
            FindObjectOfType<audio_manager>().Play("menu");
        }


        StartCoroutine(summoner_normal());
    }

    public void summon_purple()
    {
        if (!skill_activated && menu_manager.instance.frenzy_purple > 0)
        {
            menu_manager.instance.frenzy_purple -= 1;
            skill_activated = true;
            StopCoroutine(summoner_normal());
            StartCoroutine(summoner_purple());
        }

    }
    IEnumerator summoner_purple()
    {
        if (!menu_manager.instance.satan_is_stronger_than_god)
        {
            FindObjectOfType<audio_manager>().Stop("menu");
            FindObjectOfType<audio_manager>().Play("funky");
        }
        skill_time = menu_manager.instance.game_time;

        while (menu_manager.instance.game_time - skill_time < 10)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            random_pos_y = Random.Range(-3.0f, 2.7f);
            soul = Instantiate(souls[1]);
            soul.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + random_pos_y, gameObject.transform.position.z);
            souls[1].GetComponent<move_control>().speed = Random.Range(2, 8);

        }

        if (!menu_manager.instance.satan_is_stronger_than_god)
        {
            FindObjectOfType<audio_manager>().Stop("funky");
            FindObjectOfType<audio_manager>().Play("menu");
        }

        skill_activated = false;
        StartCoroutine(summoner_normal());
    }
}
