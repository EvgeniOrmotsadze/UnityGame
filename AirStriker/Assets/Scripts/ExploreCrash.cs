using UnityEngine;
using System.Collections;

public class ExploreCrash : MonoBehaviour {

    public ParticleSystem particle;

	void Start () {
        Destroy(gameObject, particle.duration); 
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
