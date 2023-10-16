using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HangingMonsterScript : MonoBehaviour
{
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // other.GetComponent<PlayerController>().TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
