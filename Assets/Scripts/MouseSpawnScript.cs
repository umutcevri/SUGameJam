using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawnScript : MonoBehaviour
{
    public GameObject mousePrefab;
    public float spawnRate = 2;
    public int maxMice = 5; // Maximum number of mice that can be spawned
    private int currentMiceCount = 0; // Current number of spawned mice
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnMouse();
            timer = 0;
        }
    }

    void SpawnMouse()
    {
        if (currentMiceCount < maxMice)
        {
            Instantiate(mousePrefab, transform.position, transform.rotation);
            currentMiceCount++; // Increase the count of current mice
        }
    }
}
