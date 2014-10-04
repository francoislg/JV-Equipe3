using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Enemy"){
			Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
			Destroy(col.gameObject, 0.1f);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
