using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject chestUI;

    Inventory inv;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inv = this.GetComponent<Inventory>();

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    public void OpenUI()
    {
       chestUI.SetActive(!chestUI.activeSelf);
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inv.items.Count)
            {
                slots[i].AddItem(inv.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    public void CloseUI()
    {
        chestUI.SetActive(!chestUI.activeSelf);
    }
}
