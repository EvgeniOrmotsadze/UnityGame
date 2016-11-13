using UnityEngine;
using System.Collections;

public class CloudMoving : MonoBehaviour {

    public float _cloudSpeed = 0f;
    public Renderer RoadL;
    public Renderer RoadR;
    public GameObject Cloud;

    void Start()
    {
        RoadL = GameObject.Find("BackRoadL").GetComponent<Renderer>();
       // RoadR = GameObject.Find("BackRoadR").GetComponent<Renderer>();
        Cloud = GameObject.Find("BackCloud");
    }

	// Update is called once per frame
	void Update () {
        Cloud.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * _cloudSpeed, 0f);
        RoadL.material.mainTextureOffset = new Vector2(0f,Time.time * _cloudSpeed);
     //   RoadR.material.mainTextureOffset = new Vector2(0f, Time.time * _cloudSpeed);
	}
}
