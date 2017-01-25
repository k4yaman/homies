using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : GravityObject {

	public float gravityFactor = 1f; // then tune this value  in editor too

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * 365f);

		//GetComponent<Rigidbody2D>().AddForce((planet.transform.position - transform.position).normalized * GetComponent<Rigidbody2D>().mass * gravityFactor / (planet.transform.position - transform.position).sqrMagnitude);

		applyGravity();
	}


}
