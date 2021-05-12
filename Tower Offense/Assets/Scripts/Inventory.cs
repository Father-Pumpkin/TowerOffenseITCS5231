using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory mainInventory;


    private void Awake()
    {
        if(mainInventory != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        mainInventory = this;
    }

    #endregion

    public List<Item> items = new List<Item>();
    public int space = 20;

    // Setting up a delegate
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough Space");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
