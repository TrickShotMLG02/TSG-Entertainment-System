using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBlock : MonoBehaviour
{

    AudioSource Sound;
    int points;
    int pointstosave;
    public int PointsToAdd = 10;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.FindGameObjectWithTag("BreakSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Sound.Play();
        pointstosave = points + PointsToAdd;
        PlayerPrefs.SetInt("Points", pointstosave);
    }

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetInt("Points");
    }
}
