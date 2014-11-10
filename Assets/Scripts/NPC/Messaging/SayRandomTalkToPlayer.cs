using UnityEngine;
using System.Collections;

public class SayRandomTalkToPlayer : TalkToPlayer
{
    protected override string InteractWithPlayer()
    {
        string[] messages = {   
            "SALUT !", 
            "COMMENT CA VA ?", 
            "IL FAIT ASSEZ BEAU AUJOURD HUI ...",
            "ON SE CONNAIT ?", 
            "CA SE VOIT QUE JE SUIS OCCUPE NON ?",
            "JE T AI DEJA VU NON ?",
            "BONJOUR !",
            "BELLE JOURNEE, NON ?"
        };
        return messages[Random.Range(0, messages.Length)];
    }
}
