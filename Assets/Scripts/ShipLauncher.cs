using UnityEngine;
using System.Collections;
using System.Linq;

public class ShipLauncher : MonoBehaviour
{

	private GameObject sourceplanet;
	private GameObject targetplanet;
	private GameController gameController;

	void Start ()
	{

		gameController = this.GetComponentInParent<GameController> ();
	}
	
	GameObject GetPlanetUserClickedOn ()
	{
	

		RaycastHit2D colliderhit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition),  Vector2.zero);



		foreach (GameObject planet in gameController.allPlanets) 
		{
			if(colliderhit.collider == planet.GetComponent<Collider2D>())
			{
				return planet;
			}
		}
		return null;
	}

	void OnGUI ()
	{
		if (Event.current.type == EventType.MouseDown) {

			sourceplanet = GetPlanetUserClickedOn ();
			Debug.Log (sourceplanet);
			TryEnableHalo (sourceplanet);
		}
		if (Event.current.type == EventType.MouseUp) {

			targetplanet = GetPlanetUserClickedOn ();
			Debug.Log (targetplanet);
			TryEnableHalo (targetplanet);
		
		
			if (sourceplanet != null && targetplanet != null && sourceplanet != targetplanet) {

				Debug.Log ("start fleet");
				StartCoroutine (disableAfterSeconds());

			} else {
				ResetPlanets();
			}
		}
		
	}

	IEnumerator disableAfterSeconds(){
		yield return new WaitForSeconds(1.5f);

		TryDisableHalo (sourceplanet);
		TryDisableHalo (targetplanet);

	}

	void TryEnableHalo (GameObject planet)
	{
		if (planet != null) {
			planet.GetComponentInChildren<Grow> ().EnableDragHalo ();
		}
	}

	void TryDisableHalo(GameObject planet)
	{
		if (planet != null) {
			planet.GetComponentInChildren<Grow>().DisableHalo();
			Debug.Log ("i work");
		}
	}

	void ResetPlanets()
	{
		TryDisableHalo(sourceplanet);
		TryDisableHalo(targetplanet);
		sourceplanet = null;
		targetplanet = null;
	}

}


