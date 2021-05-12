using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        //base.Interact();
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("PICKUP " + item.name);
        if (Inventory.mainInventory.Add(item))
        {
            Debug.Log("Adding item " + item.name + " to inventory");
            Destroy(this.gameObject);
        }
    }
}
