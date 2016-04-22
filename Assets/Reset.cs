using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Reset : MonoBehaviour {
	public AudioClip gameover;

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = gameover;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {


			SceneManager.LoadScene ("KillingwithRove",LoadSceneMode.Single);
	}
}
}