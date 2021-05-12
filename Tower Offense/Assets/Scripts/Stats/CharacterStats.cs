using UnityEngine;
using System.Collections;

public class CharacterStats: MonoBehaviour
{

    private Animator m_animator;
    public int maxHealth = 100;
    public int currentHealth { get; protected set; }
    public Stat dmg;
    public Stat armor;
    public HealthBar healthbar;
    private void Awake()
    {
        currentHealth = maxHealth;

        

        m_animator = GetComponentInChildren<Animator>();
    }
    public void Start()
    {
        healthbar.setHealth(maxHealth);
    }
    public virtual void TakeDamage (int damage)
    {
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage.");

        healthbar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            m_animator.SetTrigger("TakeDmg");
        }
    }

    public virtual void Die()
    {
        //To be overritten
        //But by default we know we are gonna do something then get destroyed
        Destroy(this.gameObject);
    }

    protected IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait * Time.deltaTime);
    }
}
