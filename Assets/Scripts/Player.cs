using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // [SerializeField]
    // RectTransform healthbarFill;

    // Movement
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    // Attack action from "Unity Tutorial (2021) - Making the Player Attack" by Modding by Kaupenjoe
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(1).gameObject; // .GetChild(Index in hierarchy)
    }

    // Update is called once per frame
    void Update() // Processing Inputs
    {
        // Using Unity's input manager
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Attack action from "Unity Tutorial (2021) - Making the Player Attack" by Modding by Kaupenjoe
        if(Input.GetKeyDown(KeyCode.Space)) // Checks if enemy is in attack area
        {
            attacking = true;
            attackArea.SetActive(attacking); 
        }

        if(attacking) // Resets attack
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // If all enemies defeated
        {
            Debug.Log("All enemies defeated");
            SceneManager.LoadScene("Victory"); // loads victory scene
        }
    }

    void FixedUpdate() // Physics calculations for movement
    {
        rb.velocity = new Vector2(moveDirection.x * MoveSpeed, moveDirection.y * MoveSpeed);
    }
}