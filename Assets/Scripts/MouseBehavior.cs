using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MouseBehavior : MonoBehaviour
{
    private bool isUserOnLeft = true;
    public float minDirectionChangeInterval = 3.0f;  // Minimum time in seconds before changing direction
    public float maxDirectionChangeInterval = 7.0f;  // Maximum time in seconds before changing direction
    private float directionChangeTimer = 0.0f;
    private float currentDirectionChangeInterval;


    private bool hasCrowbarBeenPicked = false;

    private GameObject player; // Keep track of the player

    private bool isCaught = false;
    private float timer = 0f;

    public float moveSpeed = 3f;

    private Transform myTransform;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        myTransform = transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        isUserOnLeft = player.transform.position.x <= myTransform.position.x;

        currentDirectionChangeInterval = Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
        // Add a listener to the crowbar picked up event
        GameManagerScript.Instance.OnCrowbarPickedUp += CrowbarPickedUp;
    }


    private void Update()
    {
        MoveMouse();


        if (isCaught)
        {
            timer += Time.deltaTime;
            if (timer > 4f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        // It's a good practice to remove listeners when they're no longer needed
        GameManagerScript.Instance.OnCrowbarPickedUp -= CrowbarPickedUp;
    }

    private void CrowbarPickedUp()
    {

        hasCrowbarBeenPicked = true;
    }

    private void MoveMouse()
    {
        if (hasCrowbarBeenPicked)
        {
            // Move towards the player
            Vector3 direction = (player.transform.position - myTransform.position).normalized;
            myTransform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            directionChangeTimer += Time.deltaTime;

            if (directionChangeTimer >= currentDirectionChangeInterval)
            {
                isUserOnLeft = !isUserOnLeft;  // Switch direction
                directionChangeTimer = 0.0f;  // Reset the timer
                                              // Set the next random interval
                currentDirectionChangeInterval = Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
            }

            Vector3 direction = isUserOnLeft ? Vector3.left : Vector3.right;
            myTransform.position += direction * moveSpeed * Time.deltaTime;
        }


        // Update sprite facing direction based on the movement direction
        spriteRenderer.flipX = (myTransform.position.x > player.transform.position.x);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCaught && other.CompareTag("Flashlight"))
        {
            StartCoroutine(CaughtByFlashlight());
        }
    }

    private IEnumerator CaughtByFlashlight()
    {
        moveSpeed = 1f;
        yield return new WaitForSeconds(0.5f);

        isCaught = true;
        moveSpeed = 5f;
    }


}
