using UnityEngine;
using System.Collections;
using System;

public class InputControll : MonoBehaviour {

    public event Action<float> OnMovementX;
    

    
    protected virtual void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        if (OnMovementX != null) OnMovementX(directionX);
     //   float directionY = Input.GetAxis("Vertical");
      //  if (OnMovementY != null) OnMovementY(directionY);
    }
}
