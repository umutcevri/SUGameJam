using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSystems : MonoBehaviour
{
    public bool goodEnding;
    public bool isInFinalScene = false;
    public int health = 100;
    AudioSource audioSource;
    Animator animator;
    BackgroundChange backgroundChange;
    LampItem lampItem;
    bool pickedUp = false;

    public bool hasShovel = false;

    public bool hasCrowbar = false;

    public bool hasLamp = false;

    public bool hasKey = false;

    //UIManager uiManager;
    void Start()
    {
        //uiManager = FindObjectOfType<UIManager>();
        animator = GetComponent<Animator>();
        backgroundChange = FindObjectOfType<BackgroundChange>();
        audioSource = GetComponent<AudioSource>();

        if (hasLamp)
        {
            AnimatorSwitchToLamp();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickup")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("PickUp");

                if (!pickedUp)
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
        targetObject.GetComponent<SpriteRenderer>().sortingLayerName = "Item";
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

        //uiManager.UpdateHeldItem(targetObject.GetComponent<SpriteRenderer>().sprite);

        if (targetObject.name == "Lamp")
        {
            AnimatorSwitchToLamp();

            //enable children gameobject GasLamp
            transform.GetChild(0).gameObject.SetActive(true);

            hasLamp = true;
        }

        if (targetObject.name == "Crowbar")
        {
            hasCrowbar = true;

            backgroundChange.ChangeBackground();

            lampItem = FindObjectOfType<LampItem>();
            lampItem.StartFallAndRotate();

            // Use the GameManager to set the crowbar state
            GameManagerScript.Instance.PickUpCrowbar();
        }

        if (targetObject.name == "Key")
        {
            hasKey = true;
        }

        Destroy(targetObject);

        pickedUp = false;

        hasShovel = true;
    }

    public void AnimatorSwitchToLamp()
    {
        animator.SetLayerWeight(0, 0f); // Base layer
        animator.SetLayerWeight(1, 1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health: " + health);
        if(health <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("Player Death");
        
        if(isInFinalScene)
        {
            if(!goodEnding)
                SceneManager.LoadScene("BadEnding");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
