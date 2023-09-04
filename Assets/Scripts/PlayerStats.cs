using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private PlayerController playerController;

    private HealthBar healthBar;

    internal int maxHealth = 100;
    internal int currentHealth;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        healthBar = GetComponent<HealthBar>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }

    void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
