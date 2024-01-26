using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GasLamp : MonoBehaviour
{
    public float defaultSpotAngle = 34f;
    public float defaultIntensity = 1f;
    public float focusedSpotAngle = 5f;
    public float focusedIntensity = 12f;
    public float focusSpeed = 1f;

    public float focusTime = 3f;

    float currentFocusTime = 0f;

    private Light2D light2D;
    private bool isFocusing = false;
    private float focusProgress = 1f;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        //SetFocusedLightValues();
    }

    void Update()
    {
        if (isFocusing)
        {
            currentFocusTime += Time.deltaTime;

            focusProgress = currentFocusTime / focusTime;

            light2D.pointLightInnerAngle = Mathf.Lerp(focusedSpotAngle, defaultSpotAngle, focusProgress);
            light2D.pointLightOuterAngle = Mathf.Lerp(focusedSpotAngle, defaultSpotAngle, focusProgress);
            light2D.intensity = Mathf.Lerp(focusedIntensity, defaultIntensity, focusProgress);

            if (focusProgress >= 1f)
            {
                focusProgress = 1f;
                isFocusing = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && focusProgress >= 1f)
            {
                SetFocusedLightValues();
                isFocusing = true;
                focusProgress = 0f;
                currentFocusTime = 0f;
            }
        }
    }

    void SetFocusedLightValues()
    {
        light2D.pointLightInnerAngle = focusedSpotAngle;
        light2D.pointLightOuterAngle = focusedSpotAngle;
        light2D.intensity = focusedIntensity;

        BeamAttack();
    }

    void BeamAttack()
    {
        Debug.Log("Beam Attack");

        Vector2 hitDirection = transform.parent.eulerAngles.y == 0 ? Vector2.right : Vector2.left;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, hitDirection, 20f);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.tag == "EldritchEnemy")
            {
                hit.collider.gameObject.GetComponent<EldritchEnemySystems>().BeamHit();
            }

            if(hit.collider.gameObject.tag == "Boss")
            {
                hit.collider.gameObject.GetComponent<Boss>().SlowDownBoss();
            }
        }

    }
}
