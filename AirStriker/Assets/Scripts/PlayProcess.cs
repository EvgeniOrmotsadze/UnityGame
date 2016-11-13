using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayProcess : MonoBehaviour {

    private bool isPause;

    private GameObject offset;
    private int planeNumber = 1;
	// Use this for initialization
	void Start () {
      //  PlayerPrefs.DeleteAll();
        GameObject life = GameObject.Find("Life");
        life.GetComponent<Text>().text = " * * * * *";
        offset = GameObject.Find("offset");
        InvokeRepeating("CreatEnemy", 1, 1);
        initialDemageLength();
        PlayerPrefs.SetInt("PlaneDemage", 6);
        PlayerPrefs.SetInt("Score", 0);
        if(PlayerPrefs.GetInt("BestScore") == 0) PlayerPrefs.SetInt("BestScore", 0);
        initialSound();
        if (GameObject.Find("PopMenu") != null)
        {
            Destroy(GameObject.Find("PopMenu"));
        }
	}

    private void initialSound()
    {
        AudioSource soundrack = GameObject.Find("Sounds").GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            soundrack.mute = true;
            print("gamoirto xma");
        }
        else
        {
            soundrack.mute = false;
            print("chairto xma");
        }
    }

    private void initialDemageLength()
    {
       // GameObject yellow = GameObject.Find("YellowLine");
       // PlayerPrefs.SetFloat("LifeLength", yellow.transform.localScale.x);
        PlayerPrefs.SetFloat("Length", 0);
        //double ofs = yellow.transform.localScale.x - (yellow.transform.localScale.x * 0.2);
        //yellow.transform.localScale = new Vector3((float)ofs, yellow.transform.localScale.y, yellow.transform.localScale.z);
    }

   
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("Finish") == 1)
        {
            CancelInvoke("CreatEnemy");
            impoveBestScore();
            showPopUp();
            PlayerPrefs.SetInt("Finish", 0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameObject.Find("PopMenu") == null)
            {
                if (isPause)
                {
                    Time.timeScale = 1.0f;
                    isPause = false;
                    GameObject planeSound = Instantiate(Resources.Load("Prefabs/PauseSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                    Destroy(planeSound, 1);
                }
                else
                {
                    Time.timeScale = 0.0f;
                    isPause = true;
                    GameObject planeSound = Instantiate(Resources.Load("Prefabs/PauseSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                    Destroy(planeSound, 1);
                }
            }
        }
	}

    private void showPopUp()
    {
        GameObject popUp = Instantiate(Resources.Load("Prefabs/PopMenu"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        popUp.name = "PopMenu";
        popUp.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }

    private void impoveBestScore()
    {
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("Score"));
        }
        PlayerPrefs.SetInt("Score", 0);
    }


    void CreatEnemy()
    {
        float rand = Random.Range(offset.transform.position.x - 8, offset.transform.position.x + 8);

        if (planeNumber % 10 == 0)
        {
            GameObject enem = Instantiate(Resources.Load("Prefabs/Terrorist"), new Vector3(rand, offset.transform.position.y, 0), Quaternion.identity) as GameObject;
            enem.name = "Terrorist" + planeNumber;
            Destroy(enem, 4);
        }    
        else if (planeNumber % 4 == 0)
        {
            GameObject enem = Instantiate(Resources.Load("Prefabs/Enemy2"), new Vector3(rand, offset.transform.position.y, 0), Quaternion.identity) as GameObject;
            enem.name = "Enemy2" + planeNumber;
            Destroy(enem, 6);
        }
        else
        {
            GameObject enem = Instantiate(Resources.Load("Prefabs/Enemy1"), new Vector3(rand, offset.transform.position.y, 0), Quaternion.identity) as GameObject;
            enem.name = "Enemy" + planeNumber;
            Destroy(enem, 8);
        }
        planeNumber++;
       
    }
}
