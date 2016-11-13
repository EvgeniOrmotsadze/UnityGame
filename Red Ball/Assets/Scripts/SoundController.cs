using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{



    public GameObject offSound;
    public GameObject onSound;
    public GameObject offMusic;
    public GameObject onMusic;

    void Start()
    {
        InitSounds("MuteSound",onSound,offSound);
        InitSounds("MuteMusic",onMusic,offMusic);
    }

    private void InitSounds(string sound,GameObject on,GameObject off)
    {
        if (PlayerPrefs.GetInt(sound) == 0)
        {
            PlayerPrefs.SetInt(sound, 0);
            off.SetActive(false);
            on.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt(sound, 1);
            off.SetActive(true);
            on.SetActive(false);
        }
    }


    public void clickOnButtonSound(string muteSound)
    {
        if (PlayerPrefs.GetInt(muteSound) == 1)
        {
            print("sound on");
            offSound.SetActive(false);
            onSound.SetActive(true);
            PlayerPrefs.SetInt(muteSound, 0);
        }
        else
        {
            print("sound off");
            offSound.SetActive(true);
            onSound.SetActive(false);
            PlayerPrefs.SetInt(muteSound, 1);
        }
        initialSound();
    }

    public void clickOnButtonMusic(string muteSound)
    {
        if (PlayerPrefs.GetInt(muteSound) == 1)
        {
            print("music on");
            offMusic.SetActive(false);
            onMusic.SetActive(true);
            PlayerPrefs.SetInt(muteSound, 0);
        }
        else
        {
            print("music off");
            offMusic.SetActive(true);
            onMusic.SetActive(false);
            PlayerPrefs.SetInt(muteSound, 1);
        }
        initialSound();
    }

    public static void initialSound()
    {
        AudioSource soundrack = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
        {
            soundrack.mute = true;
        }
        else
        {
            soundrack.mute = false;
        }
    }


   


}

