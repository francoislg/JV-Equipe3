using UnityEngine;
using System.Collections;

public class FilletteDealsDamage : DealsDamageToPlayerOnHit
{
    protected override void OnCollisionWithPlayer()
    {
        DealDamage();
    }
}
