using UnityEngine;
using System.Collections;

public class ShipLauncher : MonoBehaviour {

	private GameObject sourceplanet;
	private GameObject targetplanet;

	void Start () {
	
	}
	
	GameObject GetPlanetUserClickedOn () {
		Camera currentCamera = Camera.main;
		
		Vector3 mousepos = Input.mousePosition;
		
		Ray screenRay = currentCamera.ScreenPointToRay (mousepos);
		
		RaycastHit rayHit;
		Physics.Raycast (screenRay, out rayHit);
		
		foreach (GameObject planet in GameController.allPlanets) {
			if (planet.collider == rayHit.collider) {
				Debug.Log ("Collision " + rayHit.collider);
				return planet;
			}
		}
		return null;
		
		//GameObject planetUserClicked = GameController.allPlanets.FirstOrDefault(prop=>p.collider);
	}
	void OnGUI{
		if (Event.current.type == EventType.MouseDown){
			sourceplanet = GetPlanetUserClickedOn();

		}
		if(Event.current.Types == EventType.MouseUp){
			targetplanet = GetPlanetUserClickedOn();

	}

}
}


