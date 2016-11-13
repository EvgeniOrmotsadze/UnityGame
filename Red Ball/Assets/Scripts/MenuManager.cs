using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {


    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("MenuScene");
    }


    public void ResumeGame()
    {
        SoundController.initialSound();
        Destroy(GameObject.Find("MenuCanvas"));
        Time.timeScale = 1.0f;
    }


    

}
