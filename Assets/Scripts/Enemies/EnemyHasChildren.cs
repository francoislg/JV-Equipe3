using UnityEngine;
using System.Collections;

public class EnemyHasChildren : HasLife
{
	public string childrenType;

    public override void OnDeath()
    {
		GameObject[] go = GameObject.FindGameObjectsWithTag(childrenType);
		for(int i=0; i<go.Length; i++)
        {
			Debug.Log("kill : " + childrenType);
			Destroy(go[i]);
        }
        Destroy(gameObject);
        
    }

}

