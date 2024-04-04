using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Unity Tutorial (2021) - Making the Player Attack" by Modding by Kaupenjoe
public class AttackArea : MonoBehaviour
{
    private int damage = 5;
    private void OnTriggerEnter2D(Collider2D collider) // Checks if collider has collided with a health component
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>(); // If health component detected
            health.Damage(damage); // do damage
        }
    }
}
