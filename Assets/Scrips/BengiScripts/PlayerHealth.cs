using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarr healthBar;


    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        player = GameObject.Find("Player");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            player.transform.position = new Vector3(-2.5f, 2.175f, -3f);

            currentHealth = maxHealth;
        }
    }
}
