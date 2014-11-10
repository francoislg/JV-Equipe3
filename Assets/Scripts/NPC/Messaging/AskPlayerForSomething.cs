using UnityEngine;
using System.Collections;

public class AskPlayerForSomething : TalkToPlayer
{
    public string requestObject;

    public string questMessage;
    public string firstThanksMessage;
    public string thanksMessage;

    public string giveWeaponName = "";
    public int giveLifeBonus = 0;

    PlayerHasLife playerLife;
    PlayerHasInventory playerInventory;
    PlayerHasWeapon playerWeapons;

    bool questCompleted = false;

    protected override void Start()
    {
        base.Start();
        playerLife = GameObject.FindObjectOfType<PlayerHasLife>();
        playerInventory = GameObject.FindObjectOfType<PlayerHasInventory>();
        playerWeapons = GameObject.FindObjectOfType<PlayerHasWeapon>();
    }

    protected override string InteractWithPlayer()
    {
        if (questCompleted)
        {
            return thanksMessage;
        }
        else if (playerInventory.HaveQuestObject(requestObject))
        {
            OnQuestCompleted();
            return firstThanksMessage;
        }
        else
        {
            return questMessage;
        }
    }

    void OnQuestCompleted()
    {
        questCompleted = true;
        playerInventory.RemoveQuestObject(requestObject);

        if (giveWeaponName.Length > 0)
        {
            playerWeapons.GiveWeapon(giveWeaponName);
        }
        if(giveLifeBonus > 0)
        {
            playerLife.ReceiveBonus(giveLifeBonus);
        }
    }

}
