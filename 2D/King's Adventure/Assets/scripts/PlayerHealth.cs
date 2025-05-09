using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    /*******************************************************************************/
    //SET HEALTH
    //this is the place where you set the health bar at the start
    public int maxHealth = 100;
    //health who will be updated
    public int currentHealth;
    //adding healthbar component
    /*******************************************************************************/
    // IF PLAYER IS HIT
    //sprite renderer of player
    public SpriteRenderer graphics;
    //active when the player is hit
    public bool isInvincible = false;
    //delay beteween alpha 0.0 and alpha 1.0 of player
    public float invincibilityFlashDelay = 1f;
    //duration of invicibility
    public float invicibilityAfterHit = 1.5f;
    /*******************************************************************************/
    //PHYSICS HEALTH BAR
    public HealthBar healthBar;
    //reference to player
    public GameObject Player;
    /*******************************************************************************/
    private Transform playerSpawn;
    private Animator fadeSystem;
    /*******************************************************************************/
    public AudioSource audioSource;
    public AudioClip playerHitSound;
    public AudioClip playerDieSound;
    public AudioClip gameOverSound;
    public AudioClip playerRespawnSound;
    public AudioClip playerHealSound;
    /*******************************************************************************/

    public static PlayerHealth instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance PlayerHealth");
        }
        instance = this;

        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    void Start()
    {
        //set the cursor value and the variable max value frome slider to 100
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        if(PlayerPrefs.GetInt("PlayerIsRespawning") == 1)
        {
            audioSource.PlayOneShot(playerRespawnSound);
            PlayerMovement.instance.animator.SetTrigger("LaunchRespawn");
            PlayerPrefs.SetInt("PlayerIsRespawning", 0);
        }
        else
        {
            PlayerMovement.instance.animator.SetTrigger("StartLevel");
        }
    }

    void Update()
    {
        //if the H key is pressed
        if(Input.GetKeyDown(KeyCode.H))
        {
            //the health bar take 3 damages
            TakeDamage(60);
        }
    }

    public void TakeDamage(int damage)
    {
        //take damade only if isInvincible = false
        if(!isInvincible)
        {
            //update the variable of health
            currentHealth -= damage;
            //update the fill and the gradient
            healthBar.SetHealth(currentHealth);

            //if the life reach 0
            if(currentHealth <= 0)
            {
                audioSource.PlayOneShot(playerDieSound);
                Die();
                return;
            }
            audioSource.PlayOneShot(playerHitSound);
            isInvincible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(handleInvincibilityDelay());
        }
    }

    public void Die()
    {
        TimerDisplay.instance.PauseTimer();
        PlayerMovement.instance.enabled = false;
        AudioManager.instance.audioSource.Stop();
        audioSource.PlayOneShot(gameOverSound);
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        PlayerMovement.instance.rigidBody.velocity = Vector2.zero;
        GameOverManager.instance.OnPlayerDeath();
    }

        public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        audioSource.PlayOneShot(playerRespawnSound);
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        PlayerMovement.instance.rigidBody.velocity = Vector2.zero;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void HealPlayer(int healthPoints)
    {
        audioSource.PlayOneShot(playerHealSound);
        if (currentHealth + healthPoints > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthPoints;
        }
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvicibilityFlash()
    {
        //while variable isInvincible is true, the graphics alpha of character altern from 0 to 1 every xf time
        while (isInvincible)
        {
            graphics.color = new Color(1F, 1F, 1F, 0F);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1F, 1F, 1F, 1F);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator handleInvincibilityDelay()
    {
        //handle the duration of invicibility
        yield return new WaitForSeconds(invicibilityAfterHit);
        isInvincible = false;
    }

    private IEnumerator ReplacePlayer(GameObject player)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        // player return to the start position
        player.transform.position = playerSpawn.position;
        healthBar.SetMaxHealth(maxHealth);
    }
}
