using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GasLamp : MonoBehaviour
{
    public float initialGas = 20f;

    bool gasLock = false;

    float currentGas;

    Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
        currentGas = initialGas;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gasLock && currentGas > 0)
            currentGas -= Time.deltaTime;
            light2D.intensity = currentGas / initialGas;
    }

    public void Refill()
    {
        currentGas = initialGas;
        gasLock = true;
        LerpFloatOverTime();
    }

    private IEnumerator LerpFloatOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1)
        {
            light2D.intensity = Mathf.Lerp(0f, 1, elapsedTime / 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the float value reaches the exact target value
        light2D.intensity = 1;
        gasLock = false;
    }


}
