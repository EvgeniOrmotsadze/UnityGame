using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


    public GameObject mute;
    public GameObject play;

    void Start()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            PlayerPrefs.SetInt("Mute", 0);
            mute.SetActive(false);
            play.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 1);
            mute.SetActive(true);
            play.SetActive(false);
        }
    }


    public void clickOnButton()
    {
        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            Debug.Log("Sound");
            mute.SetActive(false);
            play.SetActive(true);
            PlayerPrefs.SetInt("Mute", 0);
        }
        else
        {
            Debug.Log("Mute");
            mute.SetActive(true);
            play.SetActive(false);
            PlayerPrefs.SetInt("Mute", 1);
        }
    }
	

}
