using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Narrator : MonoBehaviour {

	public Text text;
	public GameObject doorframe;

	// Use this for initialization
	void Start () {
		StartCoroutine (first ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator first() {
		yield return new WaitForSeconds (5f);
		text.text = "Try walking around your room!";
		yield return new WaitForSeconds (5f);
		text.text = "I think your mom is out shopping, want to go for an adventure??";
		yield return new WaitForSeconds (7f);
		text.text = "I see you've already picked up your magic pencil, just be careful, it's powerful!";
		yield return new WaitForSeconds (7f);
		text.text = "You can create just about anything simply by drawing it!";
		yield return new WaitForSeconds (6f);
		text.text = "This room is kind of boring, don't you think?";
		yield return new WaitForSeconds (5f);
		text.text = "Let's see if we DRAW ourselves a way out!";
		doorframe.SetActive (true);
		text.text = "Try drawing yourself a door - walk up to the blinking outline!";
		yield return new WaitForSeconds (8f);
		text.text = "Hold the Right Trigger to draw your shape";
		yield return new WaitForSeconds (5f);
		text.text = "but don't let go until you're done!!";
		yield return new WaitForSeconds (7f);
	}

	public IEnumerator doorDrawn() {
		text.text = "Hey, awesome job!";
		yield return new WaitForSeconds (5f);
		text.text = "A path hmm? Sounds like an adventure to me!";
		yield return new WaitForSeconds (5f);
	}
}
