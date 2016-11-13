using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public GameObject tankTube;
    public GameObject bullet;
    public static int crash;

    void Start()
    {
        PlayerPrefs.SetInt("CrashNum", 0);
        crash = 0;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
       // print(coll.gameObject.name.ToString());
        if (coll.gameObject.name.Equals("monster"))
        {
            if (GameObject.Find("Bullet") != null)
            {
                Destroy(GameObject.Find("Bullet"));
            }
            PlayerPrefs.SetInt("Win", 1);
        }
        crash++;
    }

    void Update()
    {
        if (crash == 5)
        {
            PlayerPrefs.SetInt("CrashNum", 5);
            bullet = GameObject.Find("Bullet");
            if (bullet != null)
            {
                Destroy(bullet);
            }
            crash = 0;
        }
    }
}

//mausePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//Debug.Log("Left Click");
//xDeg -= mausePosition.x * speed * friction;
//yDeg += mausePosition.y * speed * friction;
//Quaternion fromRotation = transform.rotation;
//Quaternion toRotation = Quaternion.Euler(yDeg,xDeg,0);
//tankTube.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
//Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// vec = vec - transform.position;
// float angle = Mathf.Atan2(vec.y, vec.x); //* Mathf.Rad2Deg;
// tankTube.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
// Debug.Log("log");
