using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;
    private bool hasLineOfSight = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // "How to make Line of Sight in Unity 2D with Raycast" by Game Dev by Kaupenjoe
    void Update()
    {
        if(hasLineOfSight)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        // if (GameObject.FindGameObjectsWithTag("Player").Length == 0) // If player is defeated
        // {
        //     Debug.Log("Player defeated");
        //     SceneManager.LoadScene("Defeat"); // loads defeat scene
        // }
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if(hasLineOfSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            } 
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }

    // "Unity Tutorial (2021) - Adding Enemies" by Modding by Kaupenjoe
    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10000);
            }
        }
    }
}
