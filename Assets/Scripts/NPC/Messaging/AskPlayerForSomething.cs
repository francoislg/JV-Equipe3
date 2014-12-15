using UnityEngine;

public class AskPlayerForSomething : TalkToPlayer
{
    const int PointsForCompletedQuest = 25;

    public QuestItem requestItem;
    public string questMessage;
    public string firstThanksMessage;
    public string thanksMessage;
    public int giveWeapon = -1;
    public int giveLifeBonus = 0;
    public GameObject doorToOpen;
    public int giveArmeBonus = -1;

    PlayerHasLife _playerLife;
    PlayerHasInventory _playerInventory;
    PlayerHasWeapon _playerWeapons;
    bool _questCompleted;

    protected override void Start()
    {
        base.Start();
        _playerLife = FindObjectOfType<PlayerHasLife>();
        _playerInventory = FindObjectOfType<PlayerHasInventory>();
        _playerWeapons = FindObjectOfType<PlayerHasWeapon>();
        _questCompleted = false;
    }

    protected override string InteractWithPlayer()
    {
        if (_questCompleted)
        {
            return thanksMessage;
        }
        else if (_playerInventory.Have(requestItem))
        {
            OnQuestCompleted();
            return firstThanksMessage;
        }
        return questMessage;
    }

    protected void OnQuestCompleted()
    {
        _questCompleted = true;
        PlayerStatus.Score += PointsForCompletedQuest;
        _playerInventory.Remove(requestItem);

        if (giveWeapon > -1)
        {
            _playerWeapons.GiveWeapon(giveWeapon);
        }
        if (giveLifeBonus > 0)
        {
            _playerLife.ReceiveBonus(giveLifeBonus);
        }

        if (giveArmeBonus > 0)
        {
            switch (giveArmeBonus)
            {
                case 1: _playerWeapons.giveBonusDamage(); break;
                case 2: _playerWeapons.giveBonusSpeed(); break;
                case 3: _playerWeapons.giveBonusSpecial(); break;
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
