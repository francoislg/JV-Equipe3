using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHasInventory : MonoBehaviour
{
    Dictionary<string, int> inventory = new Dictionary<string, int>();

    public void AddQuestObject(string questObjectName)
    {
        if (!inventory.ContainsKey(questObjectName))
        {
            inventory[questObjectName] = 0;
        }
        inventory[questObjectName]++;
    }

    public void RemoveQuestObject(string questObjectName)
    {
        if (inventory.ContainsKey(questObjectName) ||
            inventory[questObjectName] > 0)
        {
            inventory[questObjectName]--;
        }
    }

    public bool HaveQuestObject(string questObjectName)
    {
        return inventory.ContainsKey(questObjectName) &&
               inventory[questObjectName] > 0;
    }
}
