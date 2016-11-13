using UnityEngine;
using System.Collections;

public class AsteroidRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}

