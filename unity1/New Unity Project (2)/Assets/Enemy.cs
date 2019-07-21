using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 500;
    public int split_damage_min = 10;
    public GameObject deathEff;
    public GameObject bac1;
    public GameObject player;
    public Transform firepoint;
    public GameObject bullet;


    public Rigidbody2D me;
    public float x, y;
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

    Vector3 position;
    private Vector2 addPos;

    Collider2D myCollider;
    public GameObject mycell;
    /// <summary>
    /// represents the center of the cell the npc is currently in 
    /// </summary>
    public Vector2 center;


    private GameObject inWhatcell;

    //


    // Start is called before the first frame update
    void Start()
    {
        x = 1;
        y = 1;
        projectiles = new List<Bulnode>();
        position = new Vector3(transform.position.x,transform.position.y);
        

        myCollider = GetComponent<CircleCollider2D>();

        //me = GetComponent<Rigidbody2D>();

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        int fragSpawn = damage / split_damage_min;
        FragSpawn(1);


        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //create some bacteria around itt
        for (int i = 35; i < r.Next(35, 155); i++)
        {
            Instantiate(bac1,
                new Vector3(
            gameObject.transform.position.x + r.Next(1, 10),
            gameObject.transform.position.y + r.Next(1, 10)),
            transform.rotation);
        }
    }

    private void FragSpawn(int count)
    {
        Instantiate(bac1,
                new Vector3(
            gameObject.transform.position.x + r.Next(1, 10),
            gameObject.transform.position.y + r.Next(1, 10)),
            transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        //for rotation 
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5f * Time.deltaTime);


        if (Vector2.Distance(center, new Vector2(transform.position.x, transform.position.y)) > 50)
        {
            addPos = Quaternion.AngleAxis(UnityEngine.Random.Range(90f,189f)
                , Vector3.forward) * 
                (transform.position - new Vector3(center.x,center.y));

            Vector2 norm = addPos.normalized;



            x = addPos.x/100;
            y = addPos.y/100;

            position.x += x;
            position.y += y;

            x = norm.x / 3;
            y = norm.y / 3;
        }
        else
        {
            if (UnityEngine.Random.Range(0,100)<1.5f)  // a chance to move in a diff direction
            {
                float stat1 = .05f;

                x += UnityEngine.Random.Range(-stat1, stat1);
                y += UnityEngine.Random.Range(-stat1, stat1);
            }

            position.x += x ;
            position.y += y;
        }

        transform.position = position;



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

        GameObject res = Instantiate(bullet, transform.position, transform.rotation);
        ShootMe2 shootme2 = res.GetComponent<ShootMe2>();
        shootme2.speed = r.Next(10, 50);

        shootme2.InstantiateMe(transform.right);


        Bulnode bn = new Bulnode();
        bn.p = res;
        bn.dur = duration;
        projectiles.Add(bn);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

 

        if (other.gameObject.CompareTag("Player"))
        {
            //create the sprites and set flag for created. 
        }

        if (other.gameObject.CompareTag("Cell1Wall"))
        {

            inWhatcell = other.gameObject;
        }

        if (other.gameObject.CompareTag("Cell2Wall"))
        {
             
            inWhatcell = other.gameObject;

        }

    }

 


}
