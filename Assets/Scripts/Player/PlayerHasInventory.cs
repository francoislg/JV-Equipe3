using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHasInventory : MonoBehaviour
{
    public GUIStyle itemStyle;

    List<QuestItem> bag = new List<QuestItem>();
    Rect windowRect = new Rect(50, 50, Screen.width - 100, Screen.height - 100);
    bool isWindowVisible = false;

	float speedBonus = 0;
	public float speed {
		get{
			return speedBonus;
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale = Time.timeScale > 0 ? 0 : 1;
            isWindowVisible = !isWindowVisible;
        }
    }

    void OnGUI()
    {
        if (isWindowVisible)
        {
            GUI.Window(0, windowRect, InventoryWindowContent, "Inventaire");
        }
    }

    void InventoryWindowContent(int windowID)
    {
        float itemMargin = 10;
        float itemWidth = windowRect.width - 2 * itemMargin;
        float itemHeight = 50;

        for (int i = 0; i < bag.Count; i++)
        {
            QuestItem item = bag[i];

            GUI.Box(new Rect(itemMargin, 25 + i * itemHeight, itemWidth, itemHeight), "<b>" + item.friendlyName + "</b>:\n" + item.description, itemStyle);
        };
    }

    public void Add(QuestItem item)
    {
        if (item != null)
        {
            bag.Add(item);
			speedBonus += item.speedBonus;
        }
    }

    public void Remove(QuestItem item)
    {
        if (item != null)
        {
            bag.Remove(item);
			speedBonus -= item.speedBonus;
        }
    }

    public bool Have(QuestItem item)
    {
        if (item == null)
        {
            return false;
        }
        return bag.Contains(item);
    }
}
