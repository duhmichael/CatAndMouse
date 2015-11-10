using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public Transform mouse; 
	public float thrust = 5f; 
	public AudioSource Eat, Happy;
	public float myVolume = 1f;

	private AudioSource source;  
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		source = GetComponent<AudioSource>();
	}


	
	// Update is called once per frame
	void FixedUpdate () {


		for (int x = 0; x < GameManager.listOfMice.Count; x++)
		{
		//declare a var of type Vector3, called "directionToMouse",
		//set to a vector that goes from [current position] to [mouse's current position]
		Vector3 directionToMouse = (mouse.position - transform.position);

		//if the angle between [current forward direction] vs. [directionToMouse] is less than 90 degrees, then...
		if (Vector3.Angle (transform.forward, directionToMouse) < 180f)
		{
			// declare a var of type Ray, called "catRay" that starts from [current position] and goes along [directionToMouse]
			Ray catRay = new Ray (transform.position, directionToMouse);

			//declare a var of type RaycastHit, called "catRayHitInfo"
			RaycastHit catRayHitInfo = new RaycastHit();

			//if raycast with catRay and catRayHitInfo for 100 units is TRUE...
			if (Physics.Raycast (catRay, out catRayHitInfo, 100f))
			    {
				//  if catRayHitInfo.collider.tag is exactly equal to the word "Mouse"... (Cat sees the mouse!)
				if (catRayHitInfo.collider.tag == "Mouse")
				{
					//if catRayHitInfo.distance is less than or equal to 5...
					Eat.Play ();
					if (catRayHitInfo.distance <= 0.5)
					{
						// then destroy the mouse gameObject (we caught the mouse!)
						Happy.Play ();
						Destroy ( mouse.gameObject ); 

					}
					else{
						//add force on rigidbody, along [directionToMouse.normalized * 1000f] (chase it!)
						rb.AddForce(directionToMouse.normalized *1000f);
					}
				}
				}
		}

	}
	}
}


