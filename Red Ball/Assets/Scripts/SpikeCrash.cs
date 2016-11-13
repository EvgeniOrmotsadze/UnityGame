using UnityEngine;
using System.Collections;
using Assets.Scripts;


public class SpikeCrash : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Equals(ConstantType._ball))
        {
               
             StartCoroutine(MyMethod(coll));
            
            //Time.timeScale = 1.0f;
        
            
        }

    }



    IEnumerator MyMethod(Collision2D coll)
    {
        GameObject newParticleSystem = Instantiate(Resources.Load("Prefabs/Explosion"), GameObject.Find(coll.gameObject.name).transform.position, Quaternion.identity) as GameObject;
        DestroyObject(newParticleSystem, 1);
        Destroy(GameObject.Find(coll.gameObject.name));
        if (PlayerPrefs.GetInt(ConstantType._muteSound) == 0)
        {
            GameObject expSound = Instantiate(Resources.Load("Prefabs/ExpSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            Destroy(expSound, 1);
        }
        yield return new WaitForSeconds(2);
        Application.LoadLevel(ConstantType._level + PlayerPrefs.GetString(ConstantType._currentLevel));
    }
	
	
}
