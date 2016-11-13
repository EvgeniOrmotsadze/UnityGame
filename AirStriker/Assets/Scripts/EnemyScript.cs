using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 2);

    private Vector2 move;

    private Rigidbody2D planeRigid;

    private Vector2 dir = new Vector2(0, -1);
    // Use this for initialization
    void Start()
    {
      
        planeRigid = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("shootEnemy", Random.Range(1,3), 1);
    
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(speed.x * dir.x, speed.y * dir.y);
        planeRigid.velocity = move;

    }

    void shootEnemy()
    {
        GameObject enemFire = Instantiate(Resources.Load("Prefabs/enemyFire"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
        Rigidbody2D enemFireRig = enemFire.GetComponent<Rigidbody2D>();
        if(gameObject.name.StartsWith("Terrorist")){
            enemFireRig.velocity = new Vector2(0, -15);
        }
        else if (gameObject.name.StartsWith("Enemy2"))
        {
            enemFireRig.velocity = new Vector2(0, -10);
        }
        else
        {
            enemFireRig.velocity = new Vector2(0, -5);//(Random.Range(3,8)));
        }
        Destroy(enemFire, 4);
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.name.Equals("Plane"))
        {
            Destroy(GameObject.Find(otherCollider.name));
            GameObject life = GameObject.Find("Life");
            if (life != null)
            {
                life.GetComponent<Text>().text = "";
            }
            GameObject newParticleSystem = Instantiate(Resources.Load("Prefabs/PlanePartial"), GameObject.Find(otherCollider.name).transform.position, Quaternion.identity) as GameObject;
            DestroyObject(newParticleSystem, 1);
            if (PlayerPrefs.GetInt("Mute") == 0)
            {
                GameObject planeSound = Instantiate(Resources.Load("Prefabs/PlaneOverSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                Destroy(planeSound, 2);
            }
         
            PlayerPrefs.SetInt("Finish", 1);
            Destroy(gameObject);
        }
    }
}
