using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterCOntroller2D : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        WinText.text = "";
        lvlText.text = "";
        xpCount = toNextLvl = 0;
        toNextLvl = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveH, moveV);
        rb2d.AddForce(movement * speed);
    }
 
    void OnTriggerEnter2D(Collider2D other)
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

        }
        if (other.gameObject.CompareTag("cellWall"))
        {
            var velo = rb2d.velocity * -1;

            rb2d.AddForce(velo * speed * 8);
        }

        if (xpCount>10)
        {
            panel.SetActive(true);
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
    }
}
