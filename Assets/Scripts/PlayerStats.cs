using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private PlayerController playerController;

    private HealthBar healthBar;

    private int maxHealth = 100;
    internal int currentHealth;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        GameObject healthBarObject = GameObject.Find("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
