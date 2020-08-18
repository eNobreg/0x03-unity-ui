using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float speed = 10;
    public float boostSpeed = 2;
    float moveHorizontal;
    float moveVertical;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public HealthBar healthBar;
    
    void SetScoreText()
    {
            scoreText.text = "Score: " + score.ToString();
    }
    void Start()
    {
        health = 5;
        rb = GetComponent<Rigidbody>();
        setText();
        healthBar.SetMaxHealth(health);
        
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            SceneManager.LoadScene("maze");
        }
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * speed);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            healthBar.SetHealth(health);
            Debug.Log($"Health: {health}");
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
        if (other.gameObject.CompareTag("Boost"))
        {
            Vector3 move = new Vector3 (moveHorizontal, 80.0f, moveVertical);
            rb.AddForce(move * speed);
        }


    }
}
