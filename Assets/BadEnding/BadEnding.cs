using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding : MonoBehaviour
{
    public Sprite[] sprites; // Array containing 9 sprites to display
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;

    UIManager uIManager;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeSpriteWithDelay(0.5f));
    }

    IEnumerator ChangeSpriteWithDelay(float delay)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            // Change the sprite
            spriteRenderer.sprite = sprites[currentIndex];

            // Increment the index for the next sprite
            currentIndex++;

            // Wait for the specified delay
            yield return new WaitForSeconds(delay);
        }

        uIManager.StartScreenFade();
    }
}
