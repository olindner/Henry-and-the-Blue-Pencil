using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {

	Color temp;

	// Use this for initialization
	void Start () {
		temp = GetComponent<Renderer> ().material.color;
	}

	// Update is called once per frame
	void Update ()
	{
		temp.a = Mathf.Lerp (0f, 1f, Mathf.PingPong (Time.time, 0.75f));
		if (this != null) {
			this.GetComponent<Renderer> ().material.color = temp;
		}
	}
}
