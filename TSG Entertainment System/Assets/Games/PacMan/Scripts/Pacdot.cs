using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

    public AudioSource EatPointSound;

    private void Start()
    {
        EatPointSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "pacman")
		{
			GameManager.score += 10;
		    GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
            Destroy(gameObject);
            EatPointSound.Play();

		    if (pacdots.Length == 1)
		    {
		        GameObject.FindObjectOfType<GameGUINavigation>().LoadLevel();
		    }
		}
	}
}
