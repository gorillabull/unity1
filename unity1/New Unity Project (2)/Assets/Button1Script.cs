using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Script : MonoBehaviour
{
    public GameObject panel;
    public GameObject button1, button2, button3;
    public GameObject player_sprite;
    public Sprite ship2;

    public GameObject panel1, panel2, panel3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //a func call to this is registered inside the editor 
    public void dostuff(int a)
    {
        Animator a1 = panel1.GetComponent<Animator>();
        Animator a2 = panel2.GetComponent<Animator>();
        Animator a3 = panel3.GetComponent<Animator>();

        bool isopen = a1.GetBool("Open");
        a1.SetBool("Open", !isopen);

        isopen = a2.GetBool("Open");
        a2.SetBool("Open", !isopen);

        isopen = a3.GetBool("Open");
        a3.SetBool("Open", !isopen);


        player_sprite.GetComponent<SpriteRenderer>().sprite
            = ship2;
        Vector3 newScale = new Vector3(
            player_sprite.transform.localScale.x*3,
            player_sprite.transform.localScale.y*3);
        player_sprite.transform.localScale = newScale;


        panel.SetActive(false);
       
        
    }
}
