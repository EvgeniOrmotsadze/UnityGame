using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartMenuController : MonoBehaviour {
    public Text HighScoreText;
	
	void Start () {
        HighScoreText.text = "High Score: " + PlayerScores.GetBestScore();
	}

    public void LeaderBoard ()
    {
        Application.LoadLevel(0);
    }

    public void Restart ()
    {
        Application.LoadLevel(1);
    }
}
