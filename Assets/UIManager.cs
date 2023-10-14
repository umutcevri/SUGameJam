using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Sprite currentItemSprite;
    UnityEngine.UI.Image heldItem;
    void Start()
    {
        heldItem = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHeldItem(Sprite sprite)
    {
        heldItem.enabled = true;
        heldItem.sprite = sprite;
    }
}
