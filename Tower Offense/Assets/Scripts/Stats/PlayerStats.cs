using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    // Update is called once per frame
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armor);
            dmg.AddModifier(newItem.dmg);
        }
        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armor);
            dmg.RemoveModifier(oldItem.dmg);
        }
    }

}
