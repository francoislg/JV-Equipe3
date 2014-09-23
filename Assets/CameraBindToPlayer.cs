using UnityEngine;
using System.Collections;

public class CameraBindToPlayer : MonoBehaviour {

	public Transform target;
	float depthOffset = 25f;
	// Use this for initialization
	void Start () {
	
	}

	void LateUpdate() {
		Vector3 pos = target.position;
		//transform.LookAt(target);
		transform.position = new Vector3(pos.x, pos.y + depthOffset, pos.z);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
