using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	// Update is called once per frame
	void FixedUpdate () {


		//set rigidbody velocity equal to [current forward direction] * 10f + Physics.gravity
		rb.velocity = (transform.forward * 10f) + Physics.gravity;

		//declare a var of type Ray, called "moveRay" that starts from [current position] and goes [current forward direction]
		Ray moveRay = new Ray (transform.position, transform.forward); 

		//if Raycast with moveRay for 3 units is TRUE... (if there is an obstacle in front of us...)
		if  ( Physics.Raycast (moveRay, 3)){

			// then randomly turn 90 degrees left or right (around Y axis)
			int randomNumber = Random.Range (0, 2); // random num, 0 or 1
			if ( randomNumber == 0) {
				// turn left
				transform.Rotate (0f, -90f, 0f);
			} else {
				// turn right
				transform.Rotate (0f, 90f, 0f);
			}
		}
	}
}

