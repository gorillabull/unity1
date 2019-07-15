﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 100;
    public GameObject deathEff;
    public GameObject bac1;
    public GameObject player;
    public Transform firepoint;
    public GameObject bullet; 


    public Rigidbody2D me;
    float x, y;
    System.Random r = new System.Random();
    float t = 0;
    float R = 1.5f;

    //for bullets
    static int duration = 400;
    static int interval = 1;
    private List<Bulnode> projectiles;
    int shot_interval = 200;
    int time_Since_last_shot = 0;
    int perShotInterval = 0;

    //


    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        projectiles = new List<Bulnode>();
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
        //create some bacteria around itt
        for(int i =35; i<r.Next(35,155);i++)
        {
            Instantiate(bac1,
                new Vector3(
            gameObject.transform.position.x + r.Next(1, 10),
            gameObject.transform.position.y + r.Next(1, 10)),
            transform.rotation);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        //for rotation 
        Vector2 direction = player.transform.position 
            - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5f * Time.deltaTime);

        //movement
        R = R * t; 
        x = 4 * (float)Math.Cos(t);
        y = 3  * (float)Math.Sin(t);
        t += .01f;

        transform.position = new Vector3(
            x,
            y, 0);


        //GameObject res = Instantiate(bullet, firepoint.position, firepoint.rotation);

        //shooting 
        if (true)
        {
            //pl didnt shoot in last frame 
            //still check if they shot recently 
            if (time_Since_last_shot > 1)
            {
                time_Since_last_shot = 0;

                if (perShotInterval > shot_interval)
                {
                    perShotInterval = 0;
                    Shoot();
                }
            }
            else
            {
                time_Since_last_shot = 0;
                perShotInterval++;
                if (perShotInterval > shot_interval)
                {
                    perShotInterval = 0;
                    Shoot();
                }
            }

        }


        for (int i = 0; i < projectiles.Count; i++)
        {
            Bulnode temp = new Bulnode();
            temp.p = projectiles[i].p;
            temp.dur = projectiles[i].dur;
            temp.dur -= interval;
            projectiles[i] = temp;

            if (projectiles[i].dur <= 0)
            {
                Destroy(projectiles[i].p);
                projectiles.Remove(projectiles[i]);
            }
        }

        perShotInterval++;
        time_Since_last_shot++;
    }


    private void Shoot()
    {

        GameObject res = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Bulnode bn = new Bulnode();
        bn.p = res;
        bn.dur = duration;
        projectiles.Add(bn);

    }


}
