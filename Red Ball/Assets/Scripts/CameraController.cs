using UnityEngine;
using System.Collections;
using Assets.Scripts;


[System.Serializable]
public class CameraEdge
{
    public float top;
    public float bottom;
}

public class CameraController : MonoBehaviour {
    public Transform target;
    public CameraEdge edge;
    public Transform startAlarm;
    public Transform endAlarm;
    public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ball != null)
        {
            if (startAlarm.position.x <= ball.position.x)
            {
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, edge.bottom, edge.top), transform.position.z);
            }
            Vector3 seeMe = Camera.main.WorldToViewportPoint(ball.position);
            bool onScreen = seeMe.z > 0 && seeMe.x > 0 && seeMe.x < 1 && seeMe.y > 0 && seeMe.y < 1;


            if (!onScreen)
            {
                Time.timeScale = 1.0f;
                if (PlayerPrefs.GetInt(ConstantType._muteSound) == 0)
                {
                    GameObject dieSound = Instantiate(Resources.Load("Prefabs/DieSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                    DontDestroyOnLoad(dieSound);
                    Destroy(dieSound, 2);
                }

                Application.LoadLevel(ConstantType._level + PlayerPrefs.GetString(ConstantType._currentLevel));

            }
            if (endAlarm.position.x <= ball.position.x 
                    && isBallNearFinish(endAlarm.position.x, ball.position.x, endAlarm.position.y, ball.position.y))
            {

                if (ConstantType.finish == 0 && PlayerPrefs.GetInt(ConstantType._starN) == ConstantType.starArr[int.Parse(PlayerPrefs.GetString("CurrentLevel")) - 1])
                {
                    ConstantType.finish = 1;
                   
                  //  Rigidbody2D bd = ball.GetComponent<Rigidbody2D>();
                    endAlarm.position = new Vector2(endAlarm.position.x, endAlarm.position.y + 0.5f);
                    Time.timeScale = 0.0f;
                    PlayerPrefs.SetInt(ConstantType._win, 1);
                   // System.Threading.Thread.Sleep(1000);
                    Time.timeScale = 1.0f;
                    int nextLevel = int.Parse(PlayerPrefs.GetString(ConstantType._currentLevel)) + 1;
                    if (nextLevel < 5)
                    {
                        
                        PlayerPrefs.SetString(ConstantType._currentLevel, nextLevel + "");
                        PlayerPrefs.SetString(ConstantType._level + nextLevel, ConstantType._unblock);
                        Application.LoadLevel(ConstantType._level + nextLevel);
                    }
                    else
                    {
                        int k = nextLevel - 1;
                        Application.LoadLevel(ConstantType._level + k);  
                    }
                    
                }
            }
        }
	}


    IEnumerator LoadNextLevel()
    {
        print("loaded ");
        yield return new WaitForSeconds(2);
        print("continue");


    }

    private bool isBallNearFinish(float alarmX,float ballX,float alarmY,float ballY)
    {
        float diffX = alarmX > ballX ? alarmX - ballX : ballX - alarmX;
        float diffY = alarmY > ballY ? alarmY - ballY : ballY - alarmY;
        if (diffX < 1.5 && diffY < 1)
            return true;
        return false;
    }
}

