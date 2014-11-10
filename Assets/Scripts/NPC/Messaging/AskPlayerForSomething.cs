using UnityEngine;
using System.Collections;

public class AskPlayerForSomething : TalkToPlayer
{
    public string requestObject;
    public string questMessage;
    public string firstThanksMessage;
    public string thanksMessage;

    PlayerHasInventory playerInventory;

    bool questCompleted = false;

    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindObjectOfType<PlayerHasInventory>();
    }

    protected override string InteractWithPlayer()
    {
        if (questCompleted)
        {
            return thanksMessage;
        }
        else if (playerInventory.HaveQuestObject(requestObject))
        {
            questCompleted = true;
            playerInventory.RemoveQuestObject(requestObject);
            return firstThanksMessage;
        }
        else
        {
            return questMessage;
        }
    }

}
