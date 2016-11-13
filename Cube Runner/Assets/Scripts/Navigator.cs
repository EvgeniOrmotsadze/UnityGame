using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour
{
    public float speed;
    public float tilt;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xVelocity = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(xVelocity, 0.0f, 0.0f);
        rigidBody.velocity = movement * speed;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rigidBody.velocity.x * tilt);
    }
}