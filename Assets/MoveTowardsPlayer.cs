using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

	public float speed;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,Camera.main.transform.position,step);
		if (transform.position==Camera.main.transform.position){
			print("got there");
			GameObject.DestroyObject (gameObject);
		}
	}
}
