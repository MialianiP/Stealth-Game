using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Unity Tutorial (2021) - Adding Enemies" by Modding by Kaupenjoe
public class Health : MonoBehaviour
{
[SerializeField] private int health = 100;

    private int maxHealth = 100;

    public void SetHealth(int maxHealth, int health)
    {
        this.maxHealth = maxHealth;
        this.health = health;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Debug.Log("Enemy killed");
            Destroy(gameObject);
        }
    }
}
