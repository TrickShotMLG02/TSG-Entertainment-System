using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool pauseToggle;

    public GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        current = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {          
            if (pauseToggle)
            {
                Time.timeScale = 1;
                this.GetComponent<PausePopup>().OpenPanel();
            }                
            else
            {
                Time.timeScale = 0;
                this.GetComponent<PausePopup>().OpenPanel();
            }
                
            pauseToggle = !pauseToggle;
        }
    }
}
