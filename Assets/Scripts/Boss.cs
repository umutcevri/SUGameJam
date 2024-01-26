using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 4f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerSystems>().PlayerDeath();
        }
    }

    public void SlowDownBoss()
    {
        if (moveSpeed == 2f)
        {
            return;
        }
        StartCoroutine(SlowDown());
    }

    //IENumerator to decrease movespeed for 3 seconds
    IEnumerator SlowDown()
    {
        moveSpeed = 2f;
        yield return new WaitForSeconds(3f);
        moveSpeed = 4f;
    }
}
