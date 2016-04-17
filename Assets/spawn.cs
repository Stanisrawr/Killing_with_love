using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
	public Rigidbody spider;
	public float velocity = 10.0f;
	public Transform Player;
	float timeLeft = 20.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () 
	{
		timeLeft -= Time.deltaTime*10;
		if(timeLeft < 0)
		{
			Rigidbody newSpider = Instantiate (spider, new Vector3(Random.Range(-20,20),0,Random.Range(10,30)), Player.rotation) as Rigidbody;
			newSpider.transform.LookAt (Player);
			timeLeft = 20;
		}

	}
}
