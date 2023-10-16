using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    private bool isObject1Active = true;

    private void Start()
    {
        InvokeRepeating("ToggleObjects", 0.25f, 0.25f);
    }

    private void ToggleObjects()
    {
        isObject1Active = !isObject1Active;
        object1.SetActive(isObject1Active);
        object2.SetActive(!isObject1Active);
    }
}
