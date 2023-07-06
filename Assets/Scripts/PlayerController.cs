using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float verticalInput;
    private float rangeX = 12.6f;
    private float rangeZ = 7.3f;
    private bool attacking;
    private float attackRange = 1.0f;
    private float attackTimer;
    private float attackCd = 0.1f;
    Enemy nearestEnemy;
    private float damage = 20.0f;

    private float maxHealth = 100;
    private float health;
    private PlayerHealthController healthController;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.LoadPlayerDetails(); /* load player name and health from file */
        ShowHealthBar(); /* show player name and health on health bar */
        WakeButtons();   /* Add listeners to buttons on scene */
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get user movement input and move player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);

        // Prevent out of bounds
        if (transform.position.x < -rangeX)
            transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
        if (transform.position.x > rangeX)
            transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        if (transform.position.z < -rangeZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, -rangeZ);
        if (transform.position.z > rangeZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeZ);
    }

    private void FixedUpdate()
    {
        nearestEnemy = Enemy.FindClosestEnemy(transform.position, attackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Exit")
        {
            GameManager.instance.SavePlayerDetails();
            SceneManager.LoadScene(GameManager.scenes["Main"]); // Exit Safari, enter Main
        }
    }

    private void Attack()
    {
        Debug.Log("attack button pressed");

        if (nearestEnemy != null)
        {
            if (!attacking) /* if not attacking before this */
            {
                attacking = true;
                attackTimer = attackCd;
                nearestEnemy.UpdateHealth(-damage); /* reduce enemy health */
                Debug.Log("Player attacking");
            }
            else           /* if already attacking */
            {
                if (attackTimer > 0) /* if still within the same attack */
                {
                    attackTimer -= Time.deltaTime;
                    nearestEnemy.UpdateHealth(-damage); /* reduce enemy health */
                }
                else                 /* if just ended attack */
                {
                    attacking = false;
                }
            }
        }
    }

    void ShowHealthBar()
    {
        health = GameManager.instance.health;
        string name = GameManager.instance.playername;

        healthController = GetComponent<PlayerHealthController>();
        healthController.SetMaxHealth(maxHealth);
        healthController.SetHealth(health);

        TextMeshProUGUI nameText = GameObject.Find("Player Name").GetComponent<TextMeshProUGUI>();
        nameText.text = $"{name}";
    }

    void WakeButtons()
    {
        Button quitButton = GameObject.Find("Quit Button").GetComponent<Button>();
        quitButton.onClick.AddListener(GoToMenu);

        Button attackButton = GameObject.Find("Attack Button").GetComponent<Button>();
        attackButton.onClick.AddListener(Attack);
    }

    public void UpdateHealth(float value)
    {
        if (health <= 0)
        {
            health = 0;
            healthController.SetHealth(health);
            Debug.Log("Game Over!");
        }
        else
        {
            health += value;
            healthController.UpdateHealth(value);
        }
    }

    void GoToMenu()
    {
        GameManager.instance.SavePlayerDetails();
        SceneManager.LoadScene(GameManager.scenes["Menu"]);
    }
}
