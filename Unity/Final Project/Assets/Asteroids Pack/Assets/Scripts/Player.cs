using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 35;
    public float yRange = 0;
    public float zRange = -25;

    public GameObject projectilePrefab;
    public GameObject[] hearts;
    public AudioClip laserShooter;
    public AudioClip PowerUp;

    private AudioSource playerAudio;

    public bool hasPowerUp = false;
    public bool gameOVer = false;

    private float powerupStrength = 15.0f;
    public GameObject titleScreen;
    private int score = 0;
    private int highScore = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public int pointValue;
    public HealthBar healthBar;
    public Button restartButton;
    
   
    public Rigidbody rb;

    public GameObject powerupIndicator;
    public ParticleSystem astExplosion;
    public ParticleSystem shipFire;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public static Player instance;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    





    }


    // Update is called once per frame
    void Update()
    {
        //Range of the player

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, yRange, zRange);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, yRange, zRange);
        }


     
        //When the game is active player will use arrows and spacebar to play game
        if (isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Launch a projectile from the player
                GameObject go = GameObject.Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation) as GameObject;

                GameObject.Destroy(go, 3f);

                playerAudio.PlayOneShot(laserShooter, 1.0f);

            }
        }

       
        //To indicate the powerup works
        powerupIndicator.transform.position = transform.position;

       

    }
   
   
    //Update score also to keep highscore
    public void UpdateScore()
    {
        
            score += 10;
            scoreText.text = score.ToString() + "";
            if (highScore < score)
                PlayerPrefs.SetInt("highscore", score);
        
 
    }
   


    void OnTriggerEnter(Collider other)
    {
        //to indicate that player collided with powerup for certain amount second
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            playerAudio.PlayOneShot(PowerUp, 1.0f); // will be a powerup sound when player collides with powerup
            UpdateScore();

        }
        if (other.CompareTag("Weakness"))
        {

            //Player health bar goes down when collided with ring after a certain amount of rings the healthbar goes down and game is over
            TakeDamage(20);

            if (currentHealth <= 0)
            {
                restartButton.gameObject.SetActive(true);
                gameOverText.gameObject.SetActive(true);
                gameOVer = true;
                isGameActive = false;

            }

        }

    }
    // Power will be on player for 7 seconds
    IEnumerator PowerupCountdownRoutine()
    {
        
            yield return new WaitForSeconds(10);
            hasPowerUp = false;
            powerupIndicator.gameObject.SetActive(false);
        
        
      
    }

    void OnCollisionEnter(Collision collision)
    {
        //Particle system for the ship
        if (collision.gameObject.tag.Equals("Player"))
        {
            
            shipFire.Play();
           
        }//When a asteroids collids the player will be hit
        if (collision.gameObject.tag.Equals("Enemy"))
        {

            
            
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            


        }
        

    }
  //Player taking damage from the ring
    void TakeDamage(int d)
    {
        currentHealth -= d;

        healthBar.SetHealth(currentHealth);

    }
  //Restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
    }
    //Start Game
    public void StartGame()
    {
        
        isGameActive = true;
        
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " ";
        highscore.text = "HighScore: " + highScore.ToString();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


        titleScreen.gameObject.SetActive(false);
    }


}
