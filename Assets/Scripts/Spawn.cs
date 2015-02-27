using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 

{
	public GameObject Planet;
	public Transform[] spawnPoints; 

	void Start()
	{
		planets ();
	}			
	

	void planets()
	{
		Instantiate (Planet, spawnPoints[0].position, spawnPoints[0].rotation);
	}

}