using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public bool isOnGround;
    private Rigidbody2D playerRB;
    [Header("Powerup")]
    public bool hasPowerup = false;
    private float powerupStrength = 15;
    public SpriteRenderer powerupIndicatorSR;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        powerupIndicatorSR = GameObject.Find("Powerup Indicator").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerRB.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerRB.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody2D enemyRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            hasPowerup = true;
            powerupIndicatorSR.enabled = true;
            StartCoroutine(PowerupCooldown());
        }
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        powerupIndicatorSR.enabled = false;
    }
}
