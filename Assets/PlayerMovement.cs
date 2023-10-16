using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // The speed the player moves at
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // walk right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TrapAura"))
        {
            moveSpeed = 1f;
        }
    }
}
