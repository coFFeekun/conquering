using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour {
	public int maximum ; 
	public int timebetweengrows ;
	public int maxwachstumsrate;
	private int shipcounter ;
	private int wachstumsrate;

	void Start () {
				var startgrösse = Random.Range (1, 3);
		if (startgrösse == 1) {
					shipcounter = Random.Range (1, 20);
				}
		else if(startgrösse == 2) {
					shipcounter = Random.Range (20, 50);
				} 
		else if(startgrösse == 3) {
					shipcounter = Random.Range (50, 80);
		}

		transform.localScale = new Vector3 (startgrösse, startgrösse, 1);
		wachstumsrate = maxwachstumsrate / 3 * startgrösse;
		StartCoroutine (grow());
		}
	
	IEnumerator grow(){ //wachsen des Planetes
		while (true){
		if (shipcounter < maximum) {

			shipcounter = shipcounter + wachstumsrate;	
		
		string output = shipcounter.ToString();
		TextMesh textlabel = this.GetComponentInChildren<TextMesh> ();
		textlabel.text = output;

				yield return new WaitForSeconds(timebetweengrows);
	}
	}}
	void GenerateSize(){
			
		}

}