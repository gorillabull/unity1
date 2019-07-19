using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCreator : MonoBehaviour
{
    public GameObject ball;
    public GameObject [] sprites;
     System.Random r;
    List<GameObject> balls;
    static bool created = false;

    // Start is called before the first frame update
    void Start()
    {
        balls = new List<GameObject>();
        
        create();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void create()
    {
        if (!created)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject p =
                Instantiate(ball, new Vector3(0,0), this.transform.rotation);
                p.SetActive(false);

                p.GetComponent<SpriteRenderer>().sprite =
                  sprites[i].GetComponent<SpriteRenderer>().sprite;

                balls.Add(p);
            }
        }
        foreach (var item in balls)
        {
            item.SetActive(true);
        }
        created = true;
    }
}
