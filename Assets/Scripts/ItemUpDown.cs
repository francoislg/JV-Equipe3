using UnityEngine;
using System.Collections;

public class ItemUpDown : MonoBehaviour {
    public float amplitude;
    public float offset;
    private float i = 0.0f;
	// Update is called once per frame
	void Update () {
        i += Time.deltaTime;

        Vector3 newPos = new Vector3(transform.position.x,(Mathf.Sin(i) * amplitude) + offset,transform.position.z);
        transform.position = newPos;
	}
}
