using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponEnemy : MonoBehaviour {

    public int demage = 1;

	void Start () {
	    
	}
	
	
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.name.Equals("Plane"))
        {
            GameObject life = GameObject.Find("Life");
           // double ofs = yellow.transform.localScale.x - (PlayerPrefs.GetFloat("LifeLength") * 0.2);
           // yellow.transform.localScale = new Vector3((float)ofs, yellow.transform.localScale.y, yellow.transform.localScale.z);
           // double newPos = (double)yellow.transform.position.x - (double)0.8;
           // yellow.transform.position = new Vector3((float)newPos, yellow.transform.position.y, yellow.transform.position.z);
            if (life != null)
            {
                string lifeTxt = life.GetComponent<Text>().text;
                //Debug.Log(" sigrze iyuo " + lifeTxt); 
                //Debug.Log(" sigrze"  + lifeTxt.Substring(2));
                life.GetComponent<Text>().text = lifeTxt.Substring(2);
            }
            PlayerPrefs.SetInt("PlaneDemage", PlayerPrefs.GetInt("PlaneDemage") - 1);
            if (PlayerPrefs.GetInt("Mute") == 0)
            {
                GameObject planeSound = Instantiate(Resources.Load("Prefabs/PlaneOverSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                Destroy(planeSound, 2);
            }
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("PlaneDemage") == 1)
            {
                 GameObject newParticleSystem = Instantiate(Resources.Load("Prefabs/PlanePartial"), GameObject.Find(otherCollider.name).transform.position, Quaternion.identity) as GameObject;
                 DestroyObject(newParticleSystem, 1);
                 Destroy(GameObject.Find(otherCollider.name));
                 PlayerPrefs.SetInt("Finish", 1);
                 PlayerPrefs.SetInt("PlaneDemage", 5);
                 life.GetComponent<Text>().text = "";
            }
        }
    }
}
