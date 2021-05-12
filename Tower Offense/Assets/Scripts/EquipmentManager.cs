using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;
    private GameObject weaponObj;

    private void Start()
    {
        inventory = Inventory.mainInventory;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        
        Debug.Log("Start");
    }

    public void Equip(Equipment newItem)
    {
        weaponObj = GameObject.FindGameObjectsWithTag("Weapon")[0];
        int slotIndex = (int) newItem.equipSlot;
        if(slotIndex == 5)
        {
            Debug.Log("Equiping New Weapon");
            weaponObj.GetComponent<Transform>().localScale = newItem.physicalItem.GetComponent<Transform>().localScale;
            weaponObj.GetComponent<MeshFilter>().sharedMesh = newItem.physicalItem.GetComponent<MeshFilter>().sharedMesh;
            weaponObj.GetComponent<MeshRenderer>().sharedMaterial = newItem.physicalItem.GetComponent<MeshRenderer>().sharedMaterial;
        }
        Equipment oldItem = null;
        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
        currentEquipment[slotIndex] = null;

    }
}
