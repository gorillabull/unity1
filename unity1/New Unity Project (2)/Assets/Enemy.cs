using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 100;
    public GameObject deathEff;
    public Rigidbody2D me;
    float x, y;
    System.Random r = new System.Random();
    float t = 0;
    float R = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 zerov = new Vector2(0, 0);
        Vector2 minus = new Vector2(1, 1);
 
 

        
        Vector2 rand = new Vector2(r.Next(-11, 10), r.Next(-11, 10));

        Debug.Log(me.position.ToString());
        me.rotation += .1f;         //just rotates it
       // me.angularVelocity += 1f; //makes it spin very fast
        Vector2 forceDir = new Vector2(
            new System.Random().Next(1,5),
            new System.Random().Next(1,5));


        Vector2 moveDirection = me.velocity;
        float angle  = 1f; // Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(
            me.rotation+.1f, Vector3.forward);

        transform.Rotate(new Vector3(1, 1, 1));


        R = R * t; 
        x = 40 * (float)Math.Cos(t);
        y = 30  * (float)Math.Sin(t);
        t += .01f;

        transform.position = new Vector3(
            x,
            y, 0);
    }
}
