using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public AudioClip background;
	public AudioClip gameover;
	public GameObject plane;

	void OnTriggerStay (Collider col) {
		if (col.tag == "Enemy") {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = gameover;
			audio.Play();
			plane.GetComponent<spawn> ().enabled = false;
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < gameObjects.Length; i++) {
				Destroy (gameObjects[i]);
			}


		}
			
		//GAME OVER
	}
}
