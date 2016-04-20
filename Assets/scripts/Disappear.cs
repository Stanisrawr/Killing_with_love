using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	public float time=5;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime * 10;
		if (time < 0) {
			Destroy (gameObject);
		}
	}
}
