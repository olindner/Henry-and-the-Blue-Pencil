using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Canvas canvas;
	public GameObject spider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Tree Spot") {
			canvas.GetComponent<Narrator> ().treeSpot ();
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (col.gameObject.name == "Car Spot") {
			canvas.GetComponent<Narrator> ().carSpot ();
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (col.gameObject.name == "Tree Car Spot") {
			StartCoroutine (canvas.GetComponent<Narrator> ().treeCarSpot ());
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (col.gameObject.name == "Spider Spot") {
			StartCoroutine (canvas.GetComponent<Narrator> ().spiderSpot ());
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (col.gameObject.name == "Safe Spot" && spider.activeSelf) {
			canvas.GetComponent<Narrator> ().safeSpot ();
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
