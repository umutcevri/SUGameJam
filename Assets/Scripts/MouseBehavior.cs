using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{

    private bool isUserOnLeft = true;
    private bool isCaught = false;
    private float timer = 0;

    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameObject user = GameObject.Find("User");
        Vector3 userPosition = user.transform.position;
        if (userPosition.x > transform.position.x)
        {
            isUserOnLeft = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCaught)
        {
            MoveMouse(false);
        }
        else
        {
            MoveMouse(true);
            timer = timer + 1 * Time.deltaTime;
            if (timer > 4)
            {
                Destroy(gameObject);
            }
        }

    }

    void MoveMouse(bool isReverse = false)
    {
        if (isUserOnLeft)
        {
            if (isReverse)
            {
                // Move the mouse right
                transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Move the mouse forward
                transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (isReverse)
            {
                // Move the mouse left
                transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Move the mouse forward
                transform.position = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCaught || other.gameObject.tag == "Flashlight")
        {
            isCaught = true;
        }
    }

}
