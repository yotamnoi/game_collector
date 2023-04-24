using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class dmg_popup : MonoBehaviour
{
    public static dmg_popup itself;
    public Rigidbody2D rb;
    public TextMeshPro TextMeshPro;
    public GameObject soul_pop;
    public float dissTimer;
    public Color textColor;

    private void Awake()
    {
        itself = this;

        rb = GetComponent<Rigidbody2D>();
        TextMeshPro = GetComponent<TextMeshPro>();
        textColor = TextMeshPro.color;
        dissTimer = 0.3f;


    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, 4);
        dissTimer -= Time.deltaTime;    
        if(dissTimer < 0)
        {
            float dissSpeed = 3f;
            textColor.a -= dissSpeed*Time.deltaTime;
            TextMeshPro.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }

  
    }

}
