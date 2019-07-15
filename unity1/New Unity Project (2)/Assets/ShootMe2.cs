using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMe2 : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D rb;
    public GameObject firepnt;
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
