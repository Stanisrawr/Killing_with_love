using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	public Transform sphere;

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void fixedUpdate() {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)){
		}
		//Activated PressUp on the TouchPad
		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)){
			sphere.transform.position = Vector3.zero;
			sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerStay (Collider col) {
		//When trigger is pulled

		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent(gameObject.transform);
			col.gameObject.transform.position = Vector3.zero;
			col.gameObject.transform.rotation = gameObject.transform.rotation;

		}
		//When trigger is let go
		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			col.attachedRigidbody.isKinematic = false;
			col.gameObject.transform.SetParent(null);

			tossObject(col.attachedRigidbody);
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
