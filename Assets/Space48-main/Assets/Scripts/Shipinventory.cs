using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipInventory : MonoBehaviour
{
    public event Action<string> OnItemUsed;
    public event Action<Color> OnItemChanged;

    private readonly List<Color> items = new();
    private int index = -1;

    public void AddItem(Color color)
    {
        items.Add(color);
        index = items.Count - 1;
        OnItemChanged?.Invoke(color);
    }

    public void Cycle()
    {
        if (items.Count == 0) return;
        index = (index + 1) % items.Count;
        OnItemChanged?.Invoke(items[index]);
    }

    public void Use()
    {
        if (index < 0 || index >= items.Count) return;

        Color c = items[index];
        if (c == Color.blue) OnItemUsed?.Invoke("SpeedUp");
        else if (c == Color.red) OnItemUsed?.Invoke("FireRate");
        else if (c == Color.green) OnItemUsed?.Invoke("Rotation");

        items.RemoveAt(index);
        if (items.Count == 0)
            index = -1;
        else
            index = Mathf.Clamp(index - 1, 0, items.Count - 1);
    }
}