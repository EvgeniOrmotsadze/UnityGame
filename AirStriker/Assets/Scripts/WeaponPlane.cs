using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!otherCollider.name.Equals("enemyFire") && !otherCollider.name.Equals("Plane"))
        {
            GameObject newParticleSystem = Instantiate(Resources.Load("Prefabs/Partial"),GameObject.Find(otherCollider.name).transform.position,Quaternion.identity) as GameObject;
            DestroyObject(newParticleSystem,1);
            Destroy(GameObject.Find(otherCollider.name));
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("Mute") == 0)
            {
                GameObject planeSound = Instantiate(Resources.Load("Prefabs/EnemyExpSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                Destroy(planeSound, 1);
            }
            GameObject Score = GameObject.Find("Text");
            int score = 0;
            if (otherCollider.name.StartsWith("Terrorist"))
            {
                score = PlayerPrefs.GetInt("Score") + 5;
            }
            else if (otherCollider.name.StartsWith("Enemy2"))
            {
                score = PlayerPrefs.GetInt("Score") + 2;
            }
            else 
            {
                 score = PlayerPrefs.GetInt("Score") + 1;
            }
            //int score = PlayerPrefs.GetInt("Score") + 1;
            Score.GetComponent<Text>().text = "Score : " + score;
            PlayerPrefs.SetInt("Score",score);
        }
    }
}
