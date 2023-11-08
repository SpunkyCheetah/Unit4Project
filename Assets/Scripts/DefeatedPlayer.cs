using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedPlayer : MonoBehaviour
{
    public int turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
