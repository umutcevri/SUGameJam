using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public GameObject bg1;

    public GameObject bg2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackground()
    {
        bg1.SetActive(false);
        bg2.SetActive(true);
    }
}
