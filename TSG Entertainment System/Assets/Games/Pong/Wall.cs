using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour {

	void Start ()
    {

    }

	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
