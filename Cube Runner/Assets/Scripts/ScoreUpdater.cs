using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {
    public GameController gameController;
    public Text currentScore;
    public Text bestScore;

	void Update () {
        currentScore.text = "Score: " + gameController.GetCurrentScore();
        bestScore.text = "High: " + gameController.GetHighScore();
	}
}
