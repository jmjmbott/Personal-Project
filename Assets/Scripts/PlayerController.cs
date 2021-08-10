using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 60.0f;
    private float topBound = 11;
    private float bottomBound = -2;

    private Rigidbody playerRb;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Player Movement Restrain
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

        //Powerup location
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0, 0);
    }

    //Moves player with arrow keys
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

    }


    // Boundaries for restricted movement
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
        }
    }
    //Powerup indicator active and display
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
    
   
