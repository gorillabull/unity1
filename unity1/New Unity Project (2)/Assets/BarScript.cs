using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public  Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void SliderSetValue(float value)
    {
        slider.value = value;
    }
}
