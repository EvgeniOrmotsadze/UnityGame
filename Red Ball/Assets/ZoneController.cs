using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ZoneController : MonoBehaviour {


    public float upForce = 9.8f;
    private bool isWater = false;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == ConstantType._ball)
        {
            collision.GetComponent<BallMoving>().InZone(new Vector2(0, upForce));
            if (gameObject.name == "water" && PlayerPrefs.GetInt(ConstantType._muteSound) == 0 && !isWater)
            {
                isWater = true;
                GameObject waterSound = Instantiate(Resources.Load("Prefabs/WaterSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                Destroy(waterSound, 1);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == ConstantType._ball)
        {
            collision.GetComponent<BallMoving>().LeaveZone();
            if (gameObject.name == "water" && PlayerPrefs.GetInt(ConstantType._muteSound) == 0 && isWater)
            {
                isWater = false;
                //GameObject waterSound = Instantiate(Resources.Load("Prefabs/WaterSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                //Destroy(waterSound, 1);
            }
        }
    }
}
