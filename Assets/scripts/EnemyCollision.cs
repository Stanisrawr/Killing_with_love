using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public AudioClip background;
	public AudioClip gameover;
	public GameObject plane;
	bool dead=false;
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

			//dead=true;
			DEAD();

		}
			
		//GAME OVER
	}



	void DEAD()
	{
		//if (a == true) {
			//yield return new WaitForSeconds (14.0f);
			SceneManager.LoadScene ("Game OVer",LoadSceneMode.Single);
		//}
	}


}
