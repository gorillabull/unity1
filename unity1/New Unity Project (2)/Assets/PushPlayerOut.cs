﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PushPlayerOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(CapsuleCollider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("on Wall!!");


        }
    }
}
