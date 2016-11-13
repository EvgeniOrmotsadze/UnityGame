using UnityEngine;
using System.Collections;

public class DestroyPassed : MonoBehaviour {
    public float startZPosition;

	void FixedUpdate () {
        if (transform.position.z < startZPosition) {
            Destroy(gameObject);
        }
	}
}
