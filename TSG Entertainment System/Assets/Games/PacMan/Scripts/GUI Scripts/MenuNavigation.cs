using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour {

	public void MainMenu()
	{
		Application.LoadLevel("PacManMenu");
	}

	public void Quit()
	{
		Application.LoadLevel("MainMenu");
	}
	
	public void Play()
	{
		Application.LoadLevel("PacMan");
	}
	
	public void HighScores()
	{
		Application.LoadLevel("scores");
		
	}

    public void Credits()
    {
        Application.LoadLevel("credits");
    }

	public void SourceCode()
	{
		Application.OpenURL("https://github.com/vilbeyli/Pacman-Clone/");
	}
}
