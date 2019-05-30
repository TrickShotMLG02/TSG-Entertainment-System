using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum InputDevice { Keyboard, Controller, Both };
    public InputDevice Selected;

    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Input.GetAxis("Controller"));
        if (Selected == InputDevice.Keyboard)
        {
            float x = Input.GetAxisRaw("Keyboard");
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0) * speed;
        }



        if (Selected == InputDevice.Controller)
        {
            float x = Input.GetAxisRaw("Controller");
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0) * speed;
        }


        if (Selected == InputDevice.Both)
        {
            if (Input.GetAxis("Controller") != 0)
            {
                float x = Input.GetAxisRaw("Controller");
                GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0) * speed;
            }
            else if (Input.GetAxis("Keyboard") != 0)
            {
                float x = Input.GetAxisRaw("Keyboard");
                GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0) * speed;
            }     
            
        }

        
    }
}
