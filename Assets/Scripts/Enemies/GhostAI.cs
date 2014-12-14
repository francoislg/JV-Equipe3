using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	private string pathToRandom = "JellyMonsters/Prefabs/";
	GameObject myObject;
	private GameObject target;
	private float velY = 0.1f;
	private float originalY;
	public float speed = 1f;

	public GameObject QuestItemMalus;

	void Start ()
	{
		myObject = Resources.Load(pathToRandom + randomJelly()) as GameObject;
		GameObject ghost = Instantiate(myObject, transform.position, Quaternion.identity) as GameObject;
		ghost.transform.parent = transform;
		originalY = transform.position.y;
		target = GameObject.FindGameObjectWithTag("Player");
	}

	private string randomJelly() {
		ArrayList names = new ArrayList(){"Blue","Red","Orange","Purple","Red"};
		return names[Random.Range(0,5)] + "Jelly";
	}

	void Update(){
		transform.LookAt(target.transform.position);
		transform.position += new Vector3(0, velY, 0);
		transform.position += transform.forward * speed * Time.deltaTime;
		if(Mathf.Abs(originalY - transform.position.y) > 1){
			velY = -velY;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject.Instantiate(QuestItemMalus, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
