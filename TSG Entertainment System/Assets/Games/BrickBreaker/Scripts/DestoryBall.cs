using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestoryBall : MonoBehaviour
{

    AudioSource Sound;
    GameObject Gameover;
    Text pointdisp;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.FindGameObjectWithTag("GameoverSound").GetComponent<AudioSource>();
        Gameover = GameObject.Find("GameOver");
        Gameover.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Gameover.SetActive(true);
        pointdisp.text = GameObject.Find("Points").GetComponent<Text>().text = PlayerPrefs.GetInt("Points") + "";
        Sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
