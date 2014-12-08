using UnityEngine;
using System.Collections;

public class SaySomething : TalkToPlayer
{
    protected override string InteractWithPlayer()
    {
        return message;
    }
}
