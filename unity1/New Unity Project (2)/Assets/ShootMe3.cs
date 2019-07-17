using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script used by the projectiles from the germs 
public class ShootMe3 : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D rb;
    public GameObject FirePoint3;
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = FirePoint3.transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        CharacterCOntroller2D enemy = hitInfo.GetComponent<CharacterCOntroller2D>();
        if (enemy != null)
        {
            if (enemy.name == "Player")
            {
                enemy.TakeDamage(45);
                Destroy(gameObject);

            }

        }


    }


}
