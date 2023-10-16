using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidMonsterBehavior : MonoBehaviour
{

    private GameObject player;
    private bool isUserOnLeft = true;

    private float moveSpeed = 3f;

    private int health = 3;


    private Transform myTransform;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        myTransform = transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        isUserOnLeft = player.transform.position.x <= myTransform.position.x;


    }

    // Update is called once per frame
    void Update()
    {
        MoveHumanoidMonster();
    }

    private void MoveHumanoidMonster()
    {
        if (isUserOnLeft)
        {
            myTransform.position += Vector3.left * moveSpeed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        else
        {
            myTransform.position += Vector3.right * moveSpeed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flashlight"))
        {
            // take damage and slow down
            moveSpeed = 1f;
        }
    }

    private void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }


}
