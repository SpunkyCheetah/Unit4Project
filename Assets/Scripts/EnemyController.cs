using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D enemyRB;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(lookDirection * moveSpeed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
