using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public GameObject planetPrototype;
	public Vector3 spawnRange;
	public List<GameObject> allPlanets;

	// Use this for initialization
	void Start () {
		for (int i =0; i < 10; i++) {
			Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.x * -1, spawnRange.x), Random.Range(spawnRange.y * -1, spawnRange.y),-2);
			
			while(IsPsitionTooCloseToOthers(spawnPosition)){
				spawnPosition = new Vector3(Random.Range(spawnRange.x * -1, spawnRange.x), Random.Range(spawnRange.y * -1, spawnRange.y),-2);
			}
			
			Quaternion rotation = Quaternion.identity;
			GameObject newPlanet = (GameObject)Instantiate(planetPrototype,spawnPosition,rotation);
			allPlanets.Add(newPlanet);
		}
	}
	bool IsPsitionTooCloseToOthers(Vector3 spawnPosition){
		foreach (GameObject planet in allPlanets) {
			float distandce = Vector3.Distance(spawnPosition,planet.transform.localPosition);
			if(distandce <6){
				return true;
			}
		}
		return false;
	}
}