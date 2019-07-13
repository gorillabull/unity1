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


    private void Start()
    {

        projectiles = new List<Bulnode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
