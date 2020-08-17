using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public OVRInput.Controller Controller;
	public float grabRadius;
	public LayerMask mask;
	private GameObject sensedObject;

	void Sense (char hand)
	{
		RaycastHit[] hits;

		hits = Physics.SphereCastAll (transform.position, grabRadius, transform.forward, 0f, mask);


		if (hits.Length > 0) {

			int closestHit = 0;

			for (int i = 0; i < hits.Length; i++) {
				if (hits [i].distance < hits [closestHit].distance) {
					closestHit = i;
				}
			}

			sensedObject = hits [closestHit].transform.gameObject;

			if (hand == 'l') {
				sensedObject.GetComponent<Renderer> ().material.color = Color.red;
			}
			if (hand == 'r') {
				sensedObject.GetComponent<Renderer> ().material.color = Color.blue;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = OVRInput.GetLocalControllerPosition (Controller);
		transform.localRotation = OVRInput.GetLocalControllerRotation (Controller);

		if (Input.GetAxis("LHandTrigger") > 0.5) {
			Sense ('l');
		}
		if (Input.GetAxis("RHandTrigger") > 0.5) {
			Sense ('r');
		}
	}
}
