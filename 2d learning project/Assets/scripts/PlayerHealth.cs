using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    //this is the place where you set the health bar at the start
    public int maxHealth = 100;
    //health who will be updated
    public int currentHealth;
    //adding healthbar component
    public HealthBar healthBar;
    //reference to player
    public GameObject Player;


    void Start()
    {
        //set the cursor value and the variable max value frome slider to 100
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //if the H key is pressed
        if(Input.GetKeyDown(KeyCode.H))
        {
            //the health bar take 3 damages
            TakeDamage(20);
        }

        //if the life reach 0
        if(currentHealth <= 0)
        {
            //set the position of the player to the base position
            Player.transform.position = new Vector3(-11.162f, 1.5f, 0f);
            //set the cursor value and the variable max value frome slider to 100
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        //update the variable of health
        currentHealth -= damage;
        //update the fill and the gradient
        healthBar.SetHealth(currentHealth);
    }
}
