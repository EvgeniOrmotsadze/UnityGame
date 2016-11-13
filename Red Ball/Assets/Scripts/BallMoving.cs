using UnityEngine;
using System.Collections;
using Assets.Scripts;


[RequireComponent(typeof(Rigidbody2D))]
public class BallMoving : MonoBehaviour {

    private GameObject ball;
    public InputControll inputControll;
    private Rigidbody2D ballRg;
    private bool onGround;
    public float jump;
    public float downSpeed = 9;
    public float speed;
    public float zoneSpeed = 4.5f;
    private bool isPressed = false;
    public Transform startAlarm;
    protected bool inZone;
    public GameObject pad;

    
	void Start () {
        onGround = false;
        ball = GameObject.Find(ConstantType._ball);
        ballRg = ball.GetComponent<Rigidbody2D>();
        inputControll.OnMovementX += Controll_OnMovementX;
        //if(pad != null){
        //    pad.GetComponent<Animator>().
        //}
     //   inputControll.OnMovementY += Controll_OnMovementY;
	}

    //private void Controll_OnMovementY(float obj)
    //{
    //    if(obj > 0 )
    //    {
    //        print(obj);
    //        Jump();
    //    }
    //}


    public void InZone(Vector2 vectore)
    {
        inZone = true;
        ballRg.AddForce(vectore);
    }

    public void LeaveZone()
    {
        inZone = false;

    }


    private void Controll_OnMovementX(float obj)
    {
         if (ConstantType.finish == 0){
            Move(obj);
         }
    }

    protected virtual void Jump()
    {
        if (onGround)
        {
            if (PlayerPrefs.GetInt(ConstantType._muteSound) == 0)
            {
                
                GameObject planeSound = Instantiate(Resources.Load("Prefabs/JumpSound"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
                Destroy(planeSound, 1);
            }
         
            ballRg.AddForce(new Vector2(0, jump));
        }
    }


    private void Stop()
    {
        ballRg.velocity = ballRg.velocity * 0.9f;
    }

    public virtual void Move(float dir)
    {
       
       
            if (onGround)
            {
                Vector2 direction = new Vector2(dir * speed, 0);
                ballRg.AddForce(direction);
            }
            else
            {
                Vector2 direction = new Vector2((dir * speed) / 2, 0);
                ballRg.AddForce(direction);
            }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(onGround);
        if (collision.gameObject.name.Equals(ConstantType._grass))
        {
            onGround = true;
            isPressed = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        print(onGround);
        if (collision.gameObject.name.Equals(ConstantType._grass)) onGround = false;
    }

    void Update()
    {

        if (inZone)
        {
            ballRg.AddForce(new Vector2(0,zoneSpeed));
        }
        //if (startAlarm.position.x < transform.position.x)
        //{
        //    ballRg.velocity = Vector2.zero;
        //}

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!isPressed)
            {
                isPressed = true;
                if (onGround)
                {
                    Jump();
                }
              
            }

            if (inZone)
            {
                ballRg.AddForce(new Vector2(0, jump / 50));
            }
           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (inZone)
            {
                ballRg.AddForce(new Vector2(0,-downSpeed));
            }

        }

    }
}
