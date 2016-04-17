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
	RaycastHit hit;
	public float spinSpeed;
	public float shrinkSpeed;

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

	void Update()
	{
		if (hit.collider.tag == "Enemy") {
			hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			hit.collider.gameObject.transform.Rotate (Vector3.up, spinSpeed * Time.deltaTime);
			hit.collider.gameObject.transform.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;
			//play smoke animation
			if (hit.collider.gameObject.transform.localScale.y < 0.1f)
				Destroy (hit.collider.gameObject);
			//Spawn Happy Thing
		}
	}


	void OnTriggerStay(Collider col)
	{
		Debug.Log("You have collided with "+col.name+" and activated OnTriggerStay");

		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit, 1000f)) {

				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
			}
		}



	
		if (fixedJoint == null && device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
			col.transform.position = gameObject.transform.position;
			col.transform.rotation = gameObject.transform.rotation;
			fixedJoint = col.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = rigidBodyAttachPoint;
		} else if(fixedJoint!=null &&device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)){
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
