using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    UIManager uIManager;

    PlayerSystems playerSystems;
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        playerSystems = FindObjectOfType<PlayerSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            playerSystems.goodEnding = true;
            uIManager.StartScreenFade();
        }
    }
}
