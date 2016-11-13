using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Scrolling : MonoBehaviour {

  public Vector2 speed = new Vector2(2, 2);

  /// <summary>
  /// Moving direction
  /// </summary>
  public Vector2 direction = new Vector2(-1, 0);

  /// <summary>
  /// Movement should be applied to camera
  /// </summary>
  public bool isLinkedToCamera = false;


  public bool isLooping = false;

  private List<Transform> backgroundPart;

  public bool isCloud;

  public GameObject cloud;
 // private bool isSeen = false;

  void Start()
  {

      if (isLooping)
      {
          // Get all the children of the layer with a renderer
          backgroundPart = new List<Transform>();

          for (int i = 0; i < transform.childCount; i++)
          {
              Transform child = transform.GetChild(i);
              if (child.GetComponent<Renderer>() != null)
              {
                  backgroundPart.Add(child);
              }
          }
         
      }

  }

  void Update()
  {
    // Movement
    Vector3 movement = new Vector3(
      speed.x * direction.x,
      speed.y * direction.y,
      0);

    movement *= Time.deltaTime;
    transform.Translate(movement);

    // Move the camera
    if (isLinkedToCamera)
    {
      Camera.main.transform.Translate(movement);
    }

    if (isCloud)
    {
        if (cloud.transform.position.x + 25 < Camera.main.transform.position.x)
        {
            cloud.transform.position = new Vector3(Camera.main.transform.position.x+20, cloud.transform.position.y, cloud.transform.position.z);
        }
    }

    if (isLooping)
    {
      
        Transform firstChild = backgroundPart.FirstOrDefault();

        if (firstChild != null)
        {
            if (firstChild.position.y < Camera.main.transform.position.y - 21)  // first position is 21, than if camera position > backg.position ( e.x back positon became negative)
            {
                                                         // then up background set vertical position 12.8 
                 firstChild.position = new Vector3(firstChild.position.x, 12.8f, firstChild.position.z);  // it make scrolling :)
                 backgroundPart.Remove(firstChild);
                 backgroundPart.Add(firstChild);
            }
        }
    }
  }
}

