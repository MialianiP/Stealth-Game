using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity Tutorial (2021) - Adding Enemies by Modding with Kaupenjoe
// Will allow the implmentation of different enemy types with different stats
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject // ScriptableObject holds data that we can change
{
    public int hp;
    public int damage;
    public float speed;
}
