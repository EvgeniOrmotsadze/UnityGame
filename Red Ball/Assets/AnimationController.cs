using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {


    public GameObject pad;

	// Use this for initialization
	void Start () {
        Animator anim = pad.GetComponent<Animator>();
        print(" anim + " + anim.GetAnimatorTransitionInfo(0));
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
