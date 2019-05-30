using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum Fade{ In, Out };

public class Splash : MonoBehaviour {
    public string Scenename;
    public float TimeToWait;

	// Use this for initialization
	void Start () {
		StartCoroutine ("coroutine");
	}

	IEnumerator coroutine(){
		yield return new WaitForSeconds(TimeToWait);

		//yield return StartCoroutine (FadeGUITexture(fadeTime, Fade.Out));

		//yield return new WaitForSeconds(0.1f);
		
		SceneManager.LoadScene(Scenename);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

