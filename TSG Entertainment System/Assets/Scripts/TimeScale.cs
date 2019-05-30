using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public int TimeScaleValue;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = TimeScaleValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
