using UnityEngine;
using System.Collections;
using System.Collections.Generic; // we need this line to use lists

public class GameManager : MonoBehaviour {

	public GameObject mousePrefab; 
	public GameObject catPrefab;

	public static List<GameObject> listOfCats = new List<GameObject>();
	public static List<GameObject> listOfMice = new List<GameObject>();


	
	// Update is called once per frame
	void Update () {
	
		//click to place cat or mouse
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayHit = new RaycastHit();

		//Left click instantiates cat
		if (Input.GetMouseButtonDown (0))
		{
			if (Physics.Raycast (mouseRay, out mouseRayHit, 100f))
			{
				GameObject newCatClick = (GameObject) Instantiate (catPrefab, mouseRayHit.point, Quaternion.Euler (0f, 0f, 0f));
				listOfMice.Add (newCatClick);
			}
		}

		//Right click instantiates mouse
		if (Input.GetMouseButtonDown (1))
		{
			if (Physics.Raycast (mouseRay, out mouseRayHit, 100f))
			{
				GameObject newMouseClick = (GameObject) Instantiate (mousePrefab, mouseRayHit.point, Quaternion.Euler (0f, 0f, 0f));
				listOfMice.Add (newMouseClick);

			}
	}
}
}