using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicLoopScript : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.playOnAwake = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
