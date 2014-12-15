using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHasInventory : MonoBehaviour
{
    const float ItemMargin = 10;
    const float ItemHeight = 50;

    public GUIStyle itemStyle;
    public float SpeedBonus = 0;

    readonly List<QuestItem> bag = new List<QuestItem>();
    Rect _windowRect = new Rect(50, 50, Screen.width - 100, Screen.height - 100);
    bool _isWindowVisible;

    void Start()
    {
        _isWindowVisible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale = Time.timeScale > 0 ? 0 : 1;
            _isWindowVisible = !_isWindowVisible;
        }
    }

    void OnGUI()
    {
        if (_isWindowVisible)
        {
            GUI.Window(0, _windowRect, DrawInventoryWindow, "Inventaire");
        }
    }

    void DrawInventoryWindow(int windowID)
    {
        for (var i = 0; i < bag.Count; i++)
        {
            var item = bag[i];
            var itemRect = new Rect(ItemMargin, 25 + i * ItemHeight, _windowRect.width - 2 * ItemMargin, ItemHeight);

            GUI.Box(itemRect, "<b>" + item.friendlyName + "</b>:\n" + item.description, itemStyle);
        };
    }

    public void Add(QuestItem item)
    {
        if (item == null) return;

        bag.Add(item);
        SpeedBonus += item.speedBonus;
    }

    public void Remove(QuestItem item)
    {
        if (item == null) return;

        bag.Remove(item);
        SpeedBonus -= item.speedBonus;
    }

    public bool Have(QuestItem item)
    {
        return item != null && bag.Contains(item);
    }
}
