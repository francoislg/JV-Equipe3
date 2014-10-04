using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour
{
	float speed = 10.0f;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		float movement = Time.deltaTime * speed;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			moveXY(-movement, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			moveXY(movement, 0);
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			moveXY(0, movement);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			moveXY(0, -movement);
		}
	}

	void moveXY(float x, float y){
		Vector3 position = this.transform.position;
		position.x += x;
		position.z += y;
		this.transform.position = position;
	}
}
