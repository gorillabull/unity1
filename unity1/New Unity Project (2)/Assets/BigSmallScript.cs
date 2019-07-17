using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSmallScript : MonoBehaviour
{
    int interval = 3;
    int ct = 0;
    bool flip = true;
    int maxFlip = 10;
    int flipct = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ct>interval)
        {
            flipct++;
            if (flipct>maxFlip)
            {
                flip = !flip;
                flipct = 0;
            }
            ct = 0;
            if (flip)
            {
                transform.localScale *= .98f;
            }
            else
            {
                transform.localScale *= 1.02f;
            }
        }
        ct++;
    }
}
