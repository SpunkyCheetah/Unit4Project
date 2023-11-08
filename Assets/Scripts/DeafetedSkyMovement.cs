using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeafetedSkyMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 8)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(0, 0);
        }
    }
}
