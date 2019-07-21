using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public static GameObject CurrentCell;
    public static Dictionary<GameObject, bool> cellsNPCSCreated;
    public static GameObject c1, c2, c3, c4;

    bool NPCSCreated = false;

    public GameObject ball;
    public GameObject[] sprites;
    System.Random r;
    List<GameObject> balls;
    static bool created = false;

    Dictionary<int, GameObject> frag1;
    List<GameObject> destoyList;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTING CELLL");
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void Awake()
    {
        Debug.Log("active scqirpt");
        if (balls == null)
        {
            balls = new List<GameObject>();
            frag1 = new Dictionary<int, GameObject>();
            destoyList = new List<GameObject>();
            cellsNPCSCreated = new Dictionary<GameObject, bool>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            //clean up any bubbles. 
            foreach (var item in frag1)
            {
                destoyList.Add(item.Value);
            }

            for (int i = 0; i < destoyList.Count; i++)
            {
                Destroy(destoyList[i]);
            }
            frag1.Clear();
            destoyList.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

         
        if (other.gameObject.CompareTag("Player1"))
        {
            if (!cellsNPCSCreated.ContainsKey(this.gameObject))
            {
                cellsNPCSCreated.Add(this.gameObject, true  );
                    create();
            }


        }

        if (other.gameObject.CompareTag("bac1"))
        {
            if (!frag1.ContainsKey(other.GetInstanceID()))
            {
                frag1.Add(other.GetInstanceID(), other.gameObject);
            }

        }

    }

    public void create()
    {


        Vector3 pos =   GetComponent<CircleCollider2D>().bounds.center;
                                   
        for (int i = 0; i < 5; i++)
        {
            GameObject p =
            Instantiate(ball, pos, this.transform.rotation);
            p.SetActive(false);

            p.GetComponent<SpriteRenderer>().sprite =
              sprites[i].GetComponent<SpriteRenderer>().sprite;

            p.GetComponent<Enemy>().center = GetComponent<Collider2D>().bounds.center;

            balls.Add(p);
        }
        cellsNPCSCreated[this.gameObject] = true;

        foreach (var item in balls)
        {
            item.SetActive(true);
        }
        created = true;
    }


}
