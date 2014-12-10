using UnityEngine;
using System.Collections;

public class ItemRotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0), 15*Time.deltaTime, Space.World);
	}
}
