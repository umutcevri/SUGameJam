using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawnScript : MonoBehaviour
{
    public GameObject mousePrefab;
    public float spawnRate = 2;
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
        Instantiate(mousePrefab, transform.position, transform.rotation);
    }
}
