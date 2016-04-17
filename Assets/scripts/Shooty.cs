using UnityEngine;
using System.Collections;


public class Shooty : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	// Use this for initialization
	void Start () {

	}
	object CLONE;
	public GameObject bulletHole;
	// Update is called once per frame
	void Update () 
	{		
		device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))

			{
			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit, 100f)) {
			
				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
			}

			}




	}

}



	
					

