using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Points", 0);
        direction = Random.Range(1, 3);

        if(direction == 1)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
            Debug.Log("Left");
        }
        else if(direction == 2)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
            Debug.Log("Right");
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
