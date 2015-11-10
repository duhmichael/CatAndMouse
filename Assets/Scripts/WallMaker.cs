using UnityEngine;
using System.Collections;

public class WallMaker : MonoBehaviour {
	
	// put this on a small sphere, it will drop a "breadcrumb" trail of floor tiles
	public float moveSpeed = 5f;
	private int counter = 0;
	//public Transform floorPreFab;
	public Transform wallPreFab;
	//public Transform pathmakerPrefab;
	
	
	
	float x;
	float y;
	float z;
	Vector3 pos;
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (counter<30) //makes up to 50 tiles
		{
			float randomNumber;
			float tileOrWall;
			randomNumber = Random.Range (0.0f, 1.0f);
			tileOrWall = Random.Range (0.0f, 1.0f);
			
			
			
			
			if (randomNumber < 0.25f)
			{
				transform.Rotate (0f, 90f, 0f);
			}
			else if (randomNumber > 0.25f && randomNumber < 0.5f)
			{
				transform.Rotate (0f,-90f, 0f);
			}
//			else if  (randomNumber > 0.99f && randomNumber < 1.0f)
//			{
//				Instantiate (pathmakerPrefab, transform.position, transform.rotation);
//			}
			else if (randomNumber > 0.70f && randomNumber < .80f)
			{
				Instantiate (wallPreFab, transform.position, transform.rotation);
			}
			
			//Instantiate (wallPreFab, transform.position, transform.rotation);
			//Instantiate (floorPreFab, transform.position, transform.rotation);

			x = Random.Range (-10f, 10f);
			y = 1f;
			z = Random.Range (-7f, 7f);

			pos = new Vector3(x, y, z);
			transform.position = pos;
			//Increment Counter
			counter++;
		}
		else
		{
			
			Destroy (this.gameObject);
			
		}
		
		
		
	}
}
