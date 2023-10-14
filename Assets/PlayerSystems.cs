using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour
{
    bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Pickup")
        {
            
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("PickUp");
                
                if(!pickedUp)
                {
                    PickUp(other.gameObject, transform.position, 0.5f);
                    pickedUp = true;
                }
            }
        }
    }

    public void PickUp(GameObject targetObject, Vector3 targetPosition, float duration)
    {
        StartCoroutine(ShrinkAndMoveCoroutine(targetObject, targetPosition, duration));
    }

    private IEnumerator ShrinkAndMoveCoroutine(GameObject targetObject, Vector3 targetPosition, float duration)
    {
        Vector3 initialScale = targetObject.transform.localScale;
        Vector3 initialPosition = targetObject.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            targetObject.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
            targetObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the exact target position and scale
        Destroy(targetObject);

        pickedUp = false;
    }
}
