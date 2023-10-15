using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampItem : MonoBehaviour
{
     public float targetY = -3.40f;
    public float targetRotationZ = -90f;
    public float duration = 2f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private IEnumerator FallAndRotate()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor between 0 and 1
            float t = Mathf.SmoothStep(0, 1, elapsedTime / duration);

            // Update position smoothly
            Vector3 newPosition = Vector3.Lerp(initialPosition, new Vector3(initialPosition.x, targetY, initialPosition.z), t);

            // Update rotation smoothly
            Quaternion newRotation = Quaternion.Euler(0, 0, Mathf.Lerp(initialRotation.eulerAngles.z, targetRotationZ, t));

            // Apply new position and rotation
            transform.position = newPosition;
            transform.rotation = newRotation;

            // Increment the elapsed time by the time.deltaTime
            elapsedTime += Time.deltaTime;

            // Yield and continue execution next frame
            yield return null;
        }

        // Ensure the object reaches the exact target position and rotation
        transform.position = new Vector3(initialPosition.x, targetY, initialPosition.z);
        transform.rotation = Quaternion.Euler(0, 0, targetRotationZ);
    }

    public void StartFallAndRotate()
    {
        StartCoroutine(FallAndRotate());
    }

}
