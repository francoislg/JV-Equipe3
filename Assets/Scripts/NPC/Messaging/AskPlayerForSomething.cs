using UnityEngine;
using System.Collections;

public class AskPlayerForSomething : TalkToPlayer
{
    public QuestItem requestItem;

    public string questMessage;
	int pointsForCompletedQuest = 25;

    public string firstThanksMessage;
    public string thanksMessage;

    public int giveWeapon = -1;
    public int giveLifeBonus = 0;
    public GameObject doorToOpen;
    public int giveArmeBonus = -1;

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
        else if (playerInventory.Have(requestItem))
        {
            OnQuestCompleted();
            return firstThanksMessage;
        }
        else
        {
            return questMessage;
        }
    }

    protected void OnQuestCompleted()
    {
        questCompleted = true;
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsForCompletedQuest);
        playerInventory.Remove(requestItem);

        if (giveWeapon > -1)
        {
            playerWeapons.GiveWeapon(giveWeapon);
        }
        if(giveLifeBonus > 0)
        {
            playerLife.ReceiveBonus(giveLifeBonus);
        }

        if (giveArmeBonus> 0)
        {
            switch (giveArmeBonus)
            {
                case 1: playerWeapons.giveBonusDamage(); break;
                case 2: playerWeapons.giveBonusSpeed(); break;
                case 3: playerWeapons.giveBonusSpecial(); break;
                default: Debug.Log("Ce choix d'arme n'existe pas"); break;
            }
        }

        if (doorToOpen != null)
        {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject door in doors)
            {
                 door.transform.Rotate(new Vector3(0, 90, 0));
                 door.transform.Translate(new Vector3(-10, 0, 10));
            }
        }



    }

}
