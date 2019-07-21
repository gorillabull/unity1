using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Holds information about a frame of the ui 
/// </summary>
[System.Serializable]
public struct panelShipInfo
{
    public Text[] shipNames;
    public Text[] shipDesc;
    public Image[] shipSprites;
    public Sprite[] shipSpritesPrefab;  //contains the sprites for each ship the player can play 
}
public class CharacterCOntroller2D : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
    private CapsuleCollider2D cc2d; //to turn collision on off 
    private int count;
    public Text countText;
    public Text WinText;
    public Text lvlText;
    public BezierSpline spline;
    float progress;
    float duration=50; 

    int xpCount;
    int toNextLvl;
    int level = 0;
    List<bool> LevelsOpened;

    public GameObject panel;
    float parametricT = 0;
    public Slider slider;

    public GameObject panel1, panel2, panel3;

    private List<panelShipInfo> spi;
    public Text[] shipNames;
    public Text[] shipDesc;
    public Image[] shipSprites;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LevelsOpened = new List<bool>();//keeps track if a level has been opened. 
        spi = new List<panelShipInfo>();

        count = 0;
        SetCountText();
        WinText.text = "";
        lvlText.text = "";
        xpCount = toNextLvl = 0;
        toNextLvl = 120;

        //init ship names;
        panelShipInfo spi1 = new panelShipInfo();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPanelsMenu()
    {
        if (!LevelsOpened[level])
        {
            panel.SetActive(true);
            Animator a1 = panel1.GetComponent<Animator>();
            Animator a2 = panel2.GetComponent<Animator>();
            Animator a3 = panel3.GetComponent<Animator>();

            bool isopen = a1.GetBool("Open");
            a1.SetBool("Open", !isopen);

            isopen = a2.GetBool("Open");
            a2.SetBool("Open", !isopen);

            isopen = a3.GetBool("Open");
            a3.SetBool("Open", !isopen);

            //reset leveling stuff
            xpCount = 0;
            toNextLvl = (int)((double)toNextLvl * 1.3);

            LevelsOpened[level] = true;
            level++;

            
        }


    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveH, moveV);
        rb2d.AddForce(movement * speed);
    }
 
    void OnTriggerEnter2D(Collider2D other )
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("bac1"))
        {
            //Vector2 direction = transform.position - other.gameObject.transform.position;
           // other.GetComponent<Rigidbody2D>().AddForce(direction * 5000);

 
                other.gameObject.SetActive(false);
                //hide it
                xpCount++;
                lvlText.text = xpCount.ToString() +
                    "/" + toNextLvl.ToString();

                if (xpCount > 0)
                {
                    slider.value = ((float)xpCount / (float)toNextLvl);
                }

                if (xpCount > toNextLvl)
                {
                    OpenPanelsMenu();
                }
             

        }
        if (other.gameObject.CompareTag("cellWall"))
        {
            var velo = rb2d.velocity * -1;

            rb2d.AddForce(velo * speed * 8);
        }

        if (other.gameObject.CompareTag("NPCProjectile"))
        {
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("Cell1Wall") )
        {
            rb2d.AddForce(rb2d.velocity * 1 * 16);

            CellScript.CurrentCell = other.gameObject;
        }
        if (other.gameObject.CompareTag("Cell2Wall"))
        {
            rb2d.AddForce(rb2d.velocity * 1 * 16);
            CellScript.CurrentCell = other.gameObject;

        }
   

    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count>=5)
        {
            WinText.text = "Win!";
        }
    }

    public void TakeDamage(int damage)
    {
        xpCount--;
        lvlText.text = xpCount.ToString() +
                 "/" + toNextLvl.ToString();
        slider.value = ((float)xpCount / (float)toNextLvl);

    }
}
