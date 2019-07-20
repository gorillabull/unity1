using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public GameObject panel;
    float parametricT = 0;
    public Slider slider;

    public GameObject panel1, panel2, panel3;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        WinText.text = "";
        lvlText.text = "";
        xpCount = toNextLvl = 0;
        toNextLvl = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPanelsMenu()
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
            other.gameObject.SetActive(false);
            //hide it
            xpCount++;
            lvlText.text = xpCount.ToString() +
                "/" + toNextLvl.ToString();

            if (xpCount > 0)
            {
                slider.value=((float)xpCount / (float)toNextLvl);
            }

            if (xpCount > 10)
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
            CellScript.cellsNPCSCreated[CellScript.CurrentCell] = false;


             
        }
        if (other.gameObject.CompareTag("Cell2Wall"))
        {
            CellScript.CurrentCell = other.gameObject;
            CellScript.cellsNPCSCreated[CellScript.CurrentCell] = false;
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
