using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for Text component

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float horizontalScreenLimit;
    private float verticalScreenLimit;

    public GameObject explosion;
    public GameObject bullet;
    public Text livesText; // Reference to the UI Text component
    public int lives = 3; // Initial lives value set to 3

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        horizontalScreenLimit = 11.5f;
        verticalScreenLimit = 7.5f;
        UpdateLivesText(); // Update the text at the start
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    // Call this method whenever the lives value changes
    public void LoseALife()
    {
        lives--;
        UpdateLivesText();

        if (lives <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            // Handle player death, e.g., game over
        }
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}
