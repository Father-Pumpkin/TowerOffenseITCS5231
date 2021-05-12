using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weaponType { Stab, Slash };
public enum EquipmentSlot { Head, Chest, Legs, Feet, Hands, Weapon, Shield };
[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public weaponType weapon;
    public int dmg = 10;
    public int armor;
    public int strModifier;
    public int getDmg()
    {
        return dmg + PlayerPrefs.GetInt("Strength") * strModifier;
    }
    public string getWeaponType()
    {
        return weapon.ToString();

    }

    public override void Use()
    {
        base.Use();
        //Equip the item
        EquipmentManager.instance.Equip(this);
        //Remove from inventory
        RemoveFromInventory();
    }
}
