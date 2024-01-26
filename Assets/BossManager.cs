using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public bool bossActive = false;
    public GameObject boss;
    public GameObject player;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!bossActive && player.transform.position.x > 10)
        {
            bossActive = true;
            boss.SetActive(true);
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}
