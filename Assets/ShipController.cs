using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public int movespeed;

	void Start () {
		rigidbody2D.velocity = transform.up * 20;

	}



}
