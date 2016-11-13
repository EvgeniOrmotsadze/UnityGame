using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class StarCollect : MonoBehaviour {

    public GameObject score;

	void Start () {
        score = GameObject.Find("ScoreTxt");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        int s = (int.Parse(score.GetComponent<Text>().text.Substring(0, 1)) + 1);
        PlayerPrefs.SetInt(ConstantType._starN, s);
        score.GetComponent<Text>().text = s + score.GetComponent<Text>().text.Substring(1);
        if (PlayerPrefs.GetInt(ConstantType._muteSound) == 0)
        {
            GameObject collectSound = Instantiate(Resources.Load("Prefabs/StarMusic"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            Destroy(collectSound, 1);
        }
        Destroy(gameObject);
    }
	
}
