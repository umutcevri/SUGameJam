using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTemp : MonoBehaviour
{
    public float monsterSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(monsterSpeed * Time.deltaTime, 0, 0);
    }
}
