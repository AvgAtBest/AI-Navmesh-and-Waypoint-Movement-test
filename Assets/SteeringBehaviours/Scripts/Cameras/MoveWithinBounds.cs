using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithinBounds : MonoBehaviour
{
    public CameraBounds camBounds;
    public float zoomSpeed = 100f;
    public float moveSpeed = 15f;

	void LateUpdate ()
    {
        //Move camera left & right
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(inputH, 0, inputV);
        //position += (direction x speed) x deltaTime. 
        //                      |
        //                      V
        //                    Velocity       x deltaTime
        transform.position += inputDir * moveSpeed * Time.deltaTime;
        //zoom camera in & out
        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * inputScroll * zoomSpeed * Time.deltaTime;
        //Cap the position to stay within the cam bounds
        transform.position = camBounds.GetAdjustedPosition(transform.position);
	}
}
