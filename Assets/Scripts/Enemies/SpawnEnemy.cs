using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject copyUnit;

    protected float nextSpawn;
   	public float cooldown = 5f;
    public float range = 25;
	public int initNumber = 1;

	private bool activated = false;

	void Start(){
		for(int i=0; i<initNumber; i++){
			Spawn();
		}
	}

    void Update()
    {
		if(activated){
			if (Time.time > nextSpawn)
	        {
	            nextSpawn = Time.time + cooldown;
				Spawn();
	        }
		}else{
			Vector3 positionInScreen = Camera.main.WorldToViewportPoint(transform.position);
			if(positionInScreen.x >= 0 && positionInScreen.x <= 1 && positionInScreen.y >= 0 && positionInScreen.y <= 1){
				activated = true;
			};
		}
    }

	private void Spawn(){
		Vector3 randomPos = Random.insideUnitCircle * range;
		randomPos.z = randomPos.y;
		randomPos.y = 0;
		
		Instantiate(copyUnit, transform.position + randomPos, Quaternion.identity);
	}

}
