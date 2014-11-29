using UnityEngine;
using System.Collections;

public class FilletteDealsDamage : DealsDamageToPlayerOnHit
{
    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (isActive && other.gameObject.tag == "Player")
        {
            Debug.Log("TEST");
            DealDamage();
        }
    }

}
