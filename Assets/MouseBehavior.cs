using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MouseBehavior : MonoBehaviour
{
    private bool isUserOnLeft = true;
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
        GameObject user = GameObject.Find("User");
        isUserOnLeft = user.transform.position.x <= myTransform.position.x;
    }

    private void Update()
    {
        MoveMouse(isCaught);

        if (isCaught)
        {
            timer += Time.deltaTime;
            if (timer > 4f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void MoveMouse(bool isReverse)
    {
        bool faceLeft = isUserOnLeft; // If the user is on the right, mouse faces left
        if (isReverse)
        {
            faceLeft = !faceLeft; // Reverse the facing direction
        }

        spriteRenderer.flipX = faceLeft;

        Vector3 direction = (isUserOnLeft ? Vector3.left : Vector3.right) * (isReverse ? -1 : 1);
        myTransform.position += direction * moveSpeed * Time.deltaTime;
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
