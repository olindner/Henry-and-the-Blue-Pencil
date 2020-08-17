using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour {

	public float senseRadius;
	public LayerMask mask;
	private GameObject sensedObject, objectToHide;
	public GameObject trail;
	private bool doorStart = false, treeStart = false, carStart = false, treeCarStart = false;
	public GameObject doorFrame, door, tree, car, treeCar;
	public Canvas canvas;

	void Sense ()
	{
		RaycastHit[] hits;

		hits = Physics.SphereCastAll (transform.position, senseRadius, transform.forward, 0f, mask);

		if (hits.Length > 0) {

			int closestHit = 0;

			for (int i = 0; i < hits.Length; i++) {
				if (hits [i].distance < hits [closestHit].distance) {
					closestHit = i;
				}
			}

			sensedObject = hits [closestHit].transform.gameObject;
			trail.GetComponent<TrailRenderer> ().enabled = true;

			if (sensedObject.name == "Tree outline") {
				treeStart = true;
				objectToHide = sensedObject;
			} else if (sensedObject.name == "Car outline") {
				carStart = true;
				objectToHide = sensedObject;
			} else if (sensedObject.name == "Tree outline (1)" || sensedObject.name == "Car outline (1)") {
				treeCarStart = true;
				objectToHide = sensedObject;
			} else if (sensedObject.name == "Doorframe") {
				doorStart = true;
				objectToHide = sensedObject;
			} else {
				//
			}

		}
	}

	// Use this for initialization
	void Start () {
		trail.GetComponent<TrailRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("RHandTrigger") > 0.5) {
			Sense ();
		} else {
			trail.GetComponent<TrailRenderer> ().enabled = false;
			if (treeStart == true) {
				tree.SetActive (true);
			} 
			if (carStart == true) {
				car.SetActive (true);
			} 
			if (treeCarStart == true) {
				treeCar.SetActive (true);
			}
			if (doorStart == true) {
				door.SetActive (false);
				doorFrame.SetActive (false);
				StartCoroutine (canvas.GetComponent<Narrator> ().doorDrawn ());
			}
			if (objectToHide != null) {
				objectToHide.SetActive (false); //hides outline
			}
		}
	}
}
