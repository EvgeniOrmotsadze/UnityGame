using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {


    void Start()
    {

        GameObject BestScore = GameObject.Find("BestScore");
        if (BestScore != null)
        {
            BestScore.GetComponent<Text>().text = "Best Score Is : " + PlayerPrefs.GetInt("BestScore");
        }
    }


    public void changeMenuScene(string scene)
    {

        Application.LoadLevel(scene);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }


}
