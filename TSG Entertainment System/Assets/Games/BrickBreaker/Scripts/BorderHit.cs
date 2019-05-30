using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHit : MonoBehaviour
{

    AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.FindGameObjectWithTag("WallSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
