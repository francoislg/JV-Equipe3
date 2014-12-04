using UnityEngine;
using System.Collections;

public class MeshWithColor : MonoBehaviour {

	public Color color;
	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponentInChildren<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Color[] colors = new Color[vertices.Length];
		int i = 0;
		while (i < vertices.Length) {
			colors[i] = color;
			i++;
		}
		mesh.colors = colors;
	}
}
