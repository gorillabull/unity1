using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Script : MonoBehaviour
{
    public GameObject panel;
    public GameObject button1, button2, button3;
    public GameObject player_sprite;
    public Sprite ship2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dostuff(int a)
    {
        player_sprite.GetComponent<SpriteRenderer>().sprite
            = ship2;
        Vector3 newScale = new Vector3(
            player_sprite.transform.localScale.x*3,
            player_sprite.transform.localScale.y*3);
        player_sprite.transform.localScale = newScale;

        panel.SetActive(false);
        
    }
}
