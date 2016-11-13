using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets;

public class PlayProcess : MonoBehaviour {
  
    public GameObject tankTube;
    public GameObject prefBullet;
    private bool mauseDown;
    private GameObject canvas;
    private GameObject descript;
    private static int leftBullet;
    private GameObject displayRes;
    private bool finish;
    private GameObject point;
    private Rigidbody2D monsterRigid;
    private bool startMoving;
    private GameObject monster;
    private static float monsterVelocity = 4f;
    private int currLevel;
    private GameObject point2; 
    private Vector2 direction;
    public float speed = 12f;

    void Start()
    {
        leftBullet = 5;
        currLevel = int.Parse(PlayerPrefs.GetString("CurrentScene"));
        PlayerPrefs.SetInt("Win", 0);
        tankTube = GameObject.Find("Tube");
        descript = GameObject.Find("SceneDescript");
        redrawDescription();
        canvas = GameObject.Find("Canvas");
        point = GameObject.Find("point");
        point2 = GameObject.Find("point2");
        startMoving = false;
        displayMonster();
    }

    private void displayMonster()
    {
        if (currLevel > 4)
        {
             monster = GameObject.Find("monster");
             monsterRigid = monster.GetComponent<Rigidbody2D>();
             monsterRigid.velocity = new Vector3(0, -1, 0) * monsterVelocity;
             startMoving = true;
        }
    }

    
   

    void Update()
    {
        if (startMoving)
        {
            if (monster.transform.position.y < tankTube.transform.position.y + 1)
            {
                monsterRigid.velocity = new Vector3(0, 1, 0) * monsterVelocity;
            }
            else if (monster.transform.position.y > tankTube.transform.position.y + 4.0)
            {
                monsterRigid.velocity = new Vector3(0, -1, 0) * monsterVelocity;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            mauseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mauseDown && !finish)
            {
                if(GameObject.Find("Bullet") == null){
                     shootBullet();
                }
            }
            mauseDown = false;
        }
        if (mauseDown && !finish)
        {
            moveTube();
        }
        if (leftBullet == 0 && PlayerPrefs.GetInt("CrashNum") == 5 && !finish)
        {
            displayFinish(); 
        }
        if (PlayerPrefs.GetInt("Win") == 1 && !finish)
        {
            displayFinish();
        }
    }

    private void displayFinish()
    {
        finish = true;
        displayRes = Instantiate(Resources.Load("Prefabs/NextLevel"), new Vector3(-80, 100, 0), Quaternion.identity) as GameObject;
        displayRes.transform.SetParent(GameObject.Find("Canvas").transform, false);
        showPopUp();
    }

    private void showPopUp()
    {
        updateScore(leftBullet+1);
        redrawDescription();
        GameObject txt = GameObject.Find("TextPop");
        GameObject nextLvl = GameObject.Find("NextLevelDirection");
        if (PlayerPrefs.GetInt("Win") == 1)
        {
            int nextLevel = int.Parse(PlayerPrefs.GetString("CurrentScene")) + 1;
            if(nextLevel > 5)
            {
                stopMovingMonster();
            }
            if (nextLevel > 5 && nextLvl != null)
            {
                Destroy(nextLvl);
            }
            PlayerPrefs.SetString("Level" + nextLevel, ConstantType._unblock);
            if (nextLevel > 5)
            {
                txt.GetComponent<Text>().text = ConstantType._finishText + getCurrentScore();
            }
            else
            {
                txt.GetComponent<Text>().text = ConstantType._winText + nextLevel;
            }
            GameObject monsterHappy = GameObject.Find("happyMonster"); //.transform.Find("happyMonster") as GameObject;
            monsterHappy.SetActive(false);
        }
        else
        {
            txt.GetComponent<Text>().text = ConstantType._looseText;
            if ( nextLvl!= null)
            {
                Destroy(nextLvl);
            }
        }

        PlayerPrefs.SetInt("Win", 0);
    }

    private void stopMovingMonster()
    {
        monsterRigid.velocity = new Vector3(0,-1,0);
        startMoving = false;
    }

    private void shootBullet()
    {
        GameObject bullet = Instantiate(Resources.Load("Prefabs/Ball"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
        bullet.name = "Bullet";
        bullet.transform.SetParent(canvas.transform, false);
        bullet.transform.position = point.transform.position;
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.velocity = direction * speed;
        leftBullet--;
        if (leftBullet == 0)
        {
            PlayerPrefs.SetInt("CrashNum", 0);
        }
        redrawDescription();
        mauseDown = false;
    }


    //private void moveTube()
    //{
    //    Vector3 mouse = Input.mousePosition;
    //    Vector3 tubePoint = point.transform.position;
    //    Vector3 tubePoint2 = point2.transform.position;
    //    Vector2 vec1 = new Vector3(mouse.x - tubePoint.x, mouse.y - tubePoint.y, 0); //new Vector3(mouse.x, mouse.y, mouse.z - Camera.main.transform.position.z);
    //   // Vector3 vec2 = new Vector3(transform.position.x,transform.position.y,0);
    //    Vector2 vec2 = new Vector3(tubePoint2.x - tubePoint.x, tubePoint2.y - tubePoint.y, 0);
    //    float angle =  Mathf.Atan2(vec1.y - vec2.y,vec1.x - vec2.x) * Mathf.Rad2Deg;
    //    print("kutxe " + angle);
    //    if (angle != 0)
    //    {
    //        tankTube.transform.RotateAround(point.transform.position, new Vector3(0, 0, 1), angle);
    //    }//(mouse.y- tankTube.transform.position.y), (mouse.x - tankTube.transform.position.x)) * Mathf.Rad2Deg;
    //  //  tankTube.transform.rotation.eulerAngles.z = Mathf.Atan2((mouse.y - tankTube.transform.position.y), (mouse.x - tankTube.transform.position.x)) * Mathf.Rad2Deg;

    //}

    private void moveTube()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 tubePoint = point.transform.position;
        Vector2 tubePoint2 = point2.transform.position; 
        direction = new Vector2(tubePoint2.x - tubePoint.x, tubePoint2.y - tubePoint.y); 
        Vector2 mouseReal = new Vector2(mouse.x - tubePoint.x, mouse.y - tubePoint.y);
        float angle = Mathf.Atan2(direction.x * mouseReal.y - mouseReal.x * direction.y, direction.x * mouseReal.x + direction.y * mouseReal.y) * Mathf.Rad2Deg;
       // float angle = Mathf.Atan2(mouseReal.y - direction.y, mouseReal.x - direction.x) * Mathf.Rad2Deg;
        if (angle != 0)
        {
            tankTube.transform.RotateAround(point.transform.position, new Vector3(0, 0, 1), angle);
        }//(mouse.y- tankTube.transform.position.y), (mouse.x - tankTube.transform.position.x)) * Mathf.Rad2Deg;
       // tankTube.transform.rotation.eulerAngles.z = Mathf.Atan2((mouse.y - tankTube.transform.position.y), (mouse.x - tankTube.transform.position.x)) * Mathf.Rad2Deg;

    }

    private void redrawDescription()
    {
        if (leftBullet >= 0)
        {
            descript.GetComponent<Text>().text = "Level " + PlayerPrefs.GetString("CurrentScene") + " - Bullet " + leftBullet + " - Score " + getCurrentScore();
        }
    }

    private int getCurrentScore()
    {
        int totalScore = 0;
        for (int i = 1; i <= currLevel; i++)
        {
            if(PlayerPrefs.HasKey("Score" +i)){
                totalScore += PlayerPrefs.GetInt("Score" + i);
            }
        }
        return totalScore;
    }

    private void updateScore(int point)
    {
        int getPoint = PlayerPrefs.GetInt("Score" + currLevel);
        if (getPoint <= point)
        {
            PlayerPrefs.SetInt("Score" + currLevel, point);
        }
        else
        {
            PlayerPrefs.SetInt("Score" + currLevel, getPoint);
        }
    }
}