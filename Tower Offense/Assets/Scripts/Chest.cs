using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private List<Item> items = new List<Item>();

    public override void Interact()
    {
        Debug.Log("Just a basic chest, try hitting it to see what happens!");
    }

    public void Die()
    {
        Debug.Log("I'm TRYING");
        foreach(Item i in items)
        {
            Inventory.mainInventory.Add(i);
        }
    }




}
