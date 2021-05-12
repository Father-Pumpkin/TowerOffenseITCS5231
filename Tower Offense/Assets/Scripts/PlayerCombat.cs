using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackLocation;
    public float attackRange = 1f;
    public LayerMask attackableLayer;
    public Animator m_animator;
    public Equipment weapon;
    public float timeBetweenAttacks = 1f;


    bool canAttack = true;
    float attackTimer;
    private void Start()
    {
        attackTimer = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Strength is " + PlayerPrefs.GetInt("Strength"));
            Attack(weapon.getWeaponType(), weapon.dmg + (PlayerPrefs.GetInt("Strength") * 5));
        }
        if(attackTimer <= 0)
        {
            canAttack = true;
        }
        attackTimer -= Time.deltaTime;

    }

    void Attack(string attackType, int dmg)
    {
        if (!canAttack)
        {
            return;
        }
        // Put attack on CD
        attackTimer = timeBetweenAttacks;
        canAttack = false;

        m_animator.SetTrigger(attackType);

        Collider[] enemies = Physics.OverlapSphere(attackLocation.position, attackRange,attackableLayer);
        
        foreach (Collider e in enemies)
        {
            e.GetComponent<CharacterStats>().TakeDamage(dmg + this.GetComponent<PlayerStats>().dmg.getValue());
            Debug.Log("HYAH");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
