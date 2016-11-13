using UnityEngine;

public class StopResume : MonoBehaviour {
    public GameObject stopMenu;

	void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            stopMenu.SetActive(true);
            Time.timeScale = 0;
        }
	}
	
	public void Resume () {
        stopMenu.SetActive(false);
        Time.timeScale = 1;
	}

    public void Quit () {
        Application.Quit();
    }
}
