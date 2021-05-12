using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : Interactable
{
    [SerializeField]
    bool isLocked = true;

    public Item keyType;

    public override void Interact()
    {
        if (isLocked) { 
            Unlock();
        }
        else
        {
            Open();
        }
       
    }

    private void Unlock()
    {
        if (Inventory.mainInventory.items.Contains(keyType))
        {
            foreach(Item i in Inventory.mainInventory.items)
            {
                if(i.name == keyType.name)
                {
                    i.RemoveFromInventory();
                    break;
                }
            }
            Debug.Log("Unlocking");
            isLocked = false;
            Open();
        }
        if (isLocked && !Inventory.mainInventory.items.Contains(keyType))
        {
            Debug.Log("Find a key!");
        }
    }
    public virtual void Open()
    {
        // Open The Object
        Debug.Log("Open Sesame");
    }
}
