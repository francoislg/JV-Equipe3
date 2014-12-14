using UnityEngine;
using System.Collections;

public class fireHydrantWaterDmgFeild : MonoBehaviour {

    public int dps = 5;
    private bool isActive;
    private float dmgTick;

	// Use this for initialization
	void Start () {
        isActive = false;
        dmgTick = 1;
	}

    void OnTriggerStay(Collider other)
    {
        dmgTick -= Time.deltaTime;
        if (isActive && (dmgTick < 0))
        {
            HasLife otherWithLife = other.gameObject.GetComponent("HasLife") as HasLife;
            otherWithLife.ReceiveDamage(dps);
            dmgTick = 1;
        }
    }

    public void ActivateFeild()
    { 
        isActive = true;
        Destroy(gameObject, 10f);
    }
}
