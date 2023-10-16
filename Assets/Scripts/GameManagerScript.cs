using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerScript : MonoBehaviour
{
    // Singleton pattern to ensure there's only one GameManager in the scene
    public static GameManagerScript Instance { get; private set; }

    public bool isCrowbarPicked = false;

    // Declare an event for when the crowbar gets picked up
    public event Action OnCrowbarPickedUp;

    private void Awake()
    {
        // Set up singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure GameManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PickUpCrowbar()
    {
        isCrowbarPicked = true;
        // Trigger the event
        OnCrowbarPickedUp?.Invoke();
    }
}