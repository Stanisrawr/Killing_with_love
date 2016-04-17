using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ParentFixedJoint: MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public Transform gun;
	public Rigidbody rigidBodyAttachPoint;
	public GameObject bulletHole;
	FixedJoint fixedJoint;
	bool toggle = false;
	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent <SteamVR_TrackedObject>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		/*if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			gun.transform.position = Vector3.zero;
			gun.GetComponent<Rigidbody>().velocity=Vector3.zero;
			gun.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			fixedJoint = null;
		}*/
	}

	void OnTriggerStay(Collider col)
	{
		Debug.Log("You have collided with "+col.name+" and activated OnTriggerStay");

		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit, 100f)) {

				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
			}
		}

		if (device.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {
			if (toggle) {
				toggle = false;
			} else {
				toggle = true;
			}
		}


		if (fixedJoint == null && toggle) {
			col.transform.position = gameObject.transform.position;
			col.transform.rotation = gameObject.transform.rotation;
			fixedJoint = col.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = rigidBodyAttachPoint;
		} else if(fixedJoint!=null &&toggle==false){
			GameObject go = fixedJoint.gameObject;
			Rigidbody rigidBody = go.GetComponent<Rigidbody> ();
			Object.Destroy(fixedJoint);
			fixedJoint = null;
			tossObject (rigidBody);
		}
	}

	void tossObject(Rigidbody rigidBody){
		Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
		if (origin != null) {
			rigidBody.velocity = origin.TransformVector (device.velocity);
			rigidBody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} else {
			rigidBody.velocity = device.velocity;
			rigidBody.angularVelocity = device.angularVelocity;
		}
	}
}
