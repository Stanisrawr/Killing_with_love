using UnityEngine;
using System.Collections;


public class Shooty : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public GameObject bulletHole;
	public AudioSource audioP;
	public GameObject[] kawaii;
	public AudioClip pew;
	public AudioClip[] motivation;
	RaycastHit hit;
	// Update is called once per frame
	void Update () 
	{		
		/*int nbTouches = Input.touchCount;


		for (int i=0;i<nbTouches;i++)
		{
			Touch touch = Input.GetTouch (i);
			Ray ray = new Ray (transform.position, transform.forward);
			audioP.clip = pew;
			audioP.Play();
			if (Physics.Raycast (ray, out hit, 1000f)) {
				if (hit.collider.tag == "Enemy") {
					int k = Random.Range (0, 5);
					Instantiate (kawaii[k],hit.point, Quaternion.identity);
					Destroy (hit.collider.gameObject);
					int j=Random.Range(0,19);
					audioP.clip = motivation[j];
					audioP.Play();
				}


				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));

			}

			}

*/
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = new Ray (transform.position, transform.forward);
			audioP.clip = pew;
			audioP.PlayOneShot (pew, 03f);
			if (Physics.Raycast (ray, out hit, 1000f)) {
				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));

				if (hit.collider.tag == "Enemy") {
					int k = Random.Range (0, 5);
					Instantiate (kawaii[k],hit.point, Quaternion.identity);
					Destroy (hit.collider.gameObject);
					int j=Random.Range(0,19);
					audioP.clip = motivation[j];
					audioP.Play();
				}



			}

		
		}

	}

}



	
					

