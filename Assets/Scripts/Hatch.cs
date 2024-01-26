using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hatch : MonoBehaviour
{
    PlayerSystems playerSystems;
    void Start()
    {
        playerSystems = FindObjectOfType<PlayerSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Hatch");
                
                if(playerSystems.hasCrowbar)
                {
                    SceneManager.LoadScene("LevelThree");
                }
            }
        }
    }
}
