using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	public GameObject copyUnit;
	protected float nextSpawn;
	protected float cooldown = 2f;
	protected float range = 25;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + cooldown;
			Vector3 randomPos = Random.insideUnitCircle * range;
			randomPos.z = randomPos.y;
			randomPos.y = 0;
			MonoBehaviour.Instantiate(copyUnit, transform.position + randomPos, Quaternion.identity);
		}
	}
}
