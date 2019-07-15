using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Bulnode
{
    public GameObject p;
    public int dur; 
}

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet1;
    static int duration =200;
    static int interval =1 ;
    private List<Bulnode> projectiles;

    int shot_interval = 13;
    int time_Since_last_shot = 0;

    int perShotInterval = 0;
    private void Start()
    {

        projectiles = new List<Bulnode>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            //pl didnt shoot in last frame 
            //still check if they shot recently 
            if (time_Since_last_shot>1)
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

            if (projectiles[i].dur<=0)
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

        GameObject res =  Instantiate(bullet1, firepoint.position, firepoint.rotation);
        Bulnode bn = new Bulnode();
        bn.p = res;
        bn.dur = duration;
        projectiles.Add(bn);

    }
}
