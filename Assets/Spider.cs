using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

	public GameObject target;
	public float speed;
	private bool started = false, walking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started && isActiveAndEnabled) {
			started = true;
			StartCoroutine (wait ());
		}
		if (walking) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
		}
	}

	IEnumerator wait() {
		yield return new WaitForSeconds (3f);
		walking = true;
	}
}
