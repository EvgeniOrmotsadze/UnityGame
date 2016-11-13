using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

    public Vector2 speed = new Vector2(50, 50);

    public float bulletSpeed = 25f;

    private Vector2 move;

    private Rigidbody2D planeRigid;

    private bool isRotate;


	// Use this for initialization
	void Start () {
        planeRigid = GameObject.Find("Plane").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");

        move = new Vector2(speed.x * ix, speed.y * iy);
        planeRigid.velocity = move;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, 20, 10));
            isRotate = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, -20, -10));
            isRotate = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isRotate = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRotate = false;
        }

       

         if(Input.GetKeyDown(KeyCode.Space)){
             shootBullet();
         }

         remainPlanePosition();
	}

    private void remainPlanePosition()
    {
        if (!isRotate)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
       
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;


        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;
       
        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }

    private void shootBullet()
    {
        GameObject bullet = Instantiate(Resources.Load("Prefabs/fire1"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
        //bullet.name = "Bullet";
     //    bullet.transform.SetParent(canvas.transform, false);
       // bullet.transform.position = point.transform.position;
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(0,1 * bulletSpeed);
        Destroy(bullet, 5);
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            GameObject planeSound = Instantiate(Resources.Load("Prefabs/PlaneSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            Destroy(planeSound, 1);
        }
        // leftBullet--;
    }

   

    
}
