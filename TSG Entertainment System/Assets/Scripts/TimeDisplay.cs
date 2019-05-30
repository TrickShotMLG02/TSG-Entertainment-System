using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{

    public GameObject Display;

    public int hour;
    public int minutes;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Display = this.gameObject;
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        Display.GetComponent<Text>().text = "" + hour.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
