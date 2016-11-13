using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
    public float speed;

	void Start () {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0, 0, 1) * -speed;
	}



    void OnTriggerEnter(Collider other)
    {

        //Destroy(other.gameObject);
    }
}
