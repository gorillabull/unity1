using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script used by the projectiles only from the players 
public class ShootMe : MonoBehaviour
{
    public float speed = 200f;
    public Rigidbody2D rb;
    public GameObject firepnt;
    public  AudioSource source;
    public AudioClip a;
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = firepnt.transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy!=null )
        {
            if (enemy.name == "bigball")
            {
                enemy.TakeDamage(45);
              
                source.PlayOneShot(a, 1);

                Destroy(gameObject);

            }

            if (enemy.name=="bigball2")
            {
                enemy.TakeDamage(45);
                Destroy(gameObject);
            }
                
        }
        

    }
}
