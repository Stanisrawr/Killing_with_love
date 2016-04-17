using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {



	void OnTriggerStay (Collider col) {
		if (col.tag == "Enemy")
			Destroy (col.gameObject);
		//GAME OVER
	}
}
