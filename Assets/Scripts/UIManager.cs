using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float fadeDuration = 3f;

    public float scrollTargetY = 1508f;
    public float scrollSpeed = 50f;
    UnityEngine.UI.Image fadeImage;

    GameObject scrollText;
    private float currentAlpha = 0f;
    private float targetAlpha = 1f;
    void Start()
    {
        fadeImage = GetComponentInChildren<UnityEngine.UI.Image>();
        scrollText = GameObject.Find("ScrollText");
        fadeImage.color = new Color(1f, 1f, 1f, currentAlpha);
        fadeImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScreenFade()
    {
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(1f, 1f, 1f, newAlpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the fade is complete by setting the alpha to the target value
        fadeImage.color = new Color(1f, 1f, 1f, 1f);

        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        
        while(scrollText.transform.position.y < scrollTargetY)
        {
            Debug.Log("ScrollText " + scrollText.transform.position);
            scrollText.transform.position += new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);

            yield return null;
        }

        Application.Quit();
    }


}
