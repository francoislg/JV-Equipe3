using UnityEngine;
using System.Collections;

public class fireHydrantWaterDmgFeild : MonoBehaviour
{
    public int dps = 5;

    bool _isActive;
    float _dmgTick;

    void Start()
    {
        _isActive = false;
        _dmgTick = 1;
    }

    void OnTriggerStay(Collider other)
    {
        _dmgTick -= Time.deltaTime;
        if (_isActive && _dmgTick < 0)
        {
            var otherWithLife = other.gameObject.GetComponent("HasLife") as HasLife;
            if (otherWithLife == null) return;
            
            otherWithLife.ReceiveDamage(dps);
            _dmgTick = 1;
        }
    }

    public void ActivateFeild()
    {
        _isActive = true;
        Destroy(gameObject, 10f);
    }
}
