using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStats : CharacterStats
{
    public Chest c;
    public override void TakeDamage(int damage)
    {
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        healthbar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        StartCoroutine(Wait(.5f));
        c.Die();
        base.Die();
    }
}
