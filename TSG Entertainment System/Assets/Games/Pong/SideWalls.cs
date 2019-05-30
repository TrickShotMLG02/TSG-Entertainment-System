using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hitInfo) {
		if (hitInfo.name == "Ball")
		{
            this.gameObject.GetComponent<AudioSource>().Play();
			string wallName = transform.name;
			PongGameManager.Score (wallName);
			hitInfo.gameObject.SendMessage ("RestartGame", 1, SendMessageOptions.RequireReceiver);
		}
	}
}
