using UnityEngine;
using System.Collections;

public class LoadLevels : MonoBehaviour {


    public void PlayAgain()
    {
        print("play again");
        Application.LoadLevel("scene" + PlayerPrefs.GetString("CurrentScene"));
    }


    public void PlayNextLevel()
    {
         int nextLevel = int.Parse(PlayerPrefs.GetString("CurrentScene")) + 1;
         PlayerPrefs.SetString("CurrentScene", "" +nextLevel);
         Application.LoadLevel("scene" + nextLevel);
    }

    public void ReturnMenu()
    {
        Application.LoadLevel("startGame");
    }

}
