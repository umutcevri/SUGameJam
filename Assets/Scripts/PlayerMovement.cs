using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isFinalScene = false;
    AudioSource audioSource;
    public float leftBound = -57f;

    public float rightBound = 57f;
    Animator animator;

    Cinemachine.CinemachineVirtualCamera vcam;
    bool pickedUp = false;
    Collider2D playerCollider; // The player's collider
    public float moveSpeed = 10f; // The speed the player moves at
    void Start()
    {
        playerCollider = GetComponent<Collider2D>(); 
        animator = GetComponent<Animator>(); // Get the player's collider
        vcam = GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //ClimbDownLadder();
    }

    void MovePlayer()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(transform.position.x < leftBound)
        {
            if(horizontalInput == -1)
            {
                horizontalInput = 0;
            }
        }

        if(transform.position.x > rightBound)
        {
            if(horizontalInput == 1)
            {
                horizontalInput = 0;
            }
        }

        if (horizontalInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if(horizontalInput != 0)
        {
            if(!audioSource.isPlaying)
            {
                PlayAudio();
            }
        }
        else
        {
            StopAudio();
        }

        // Calculate the new position based on the input
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);

        // Update the player's position
        transform.position = newPosition;

        //rotate the player if they are moving left or right
        if (horizontalInput > 0)
        {
            if(!isFinalScene)
                vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.25f;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            if(!isFinalScene)
                vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.75f;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void ClimbDownLadder()
    {
        // Check if the player is pressing the down arrow
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
            {
                // Move the player down
                transform.position += new Vector3(0f, -moveSpeed * Time.deltaTime, 0f);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ladder")
        {
            Debug.Log("Ladder");
            if(Input.GetAxisRaw("Vertical") < 0)
            {
                transform.position += new Vector3(0f, -moveSpeed * Time.deltaTime, 0f);
            }
        }
    }

    void PlayAudio()
    {
        audioSource.Play();
    }

    void StopAudio()
    {
        audioSource.Stop();
    }

    
}
