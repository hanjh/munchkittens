using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class OverlayCanvas : MonoBehaviour
{
    public GameObject overlayCanvas;

    public bool displayComboOverlay = false;

    public Image canvasImage;

    // Start is called before the first frame update
    void Start()
    {
        canvasImage = overlayCanvas.GetComponentInChildren<Image>();
        if (canvasImage == null)
        {
            UnityEngine.Debug.Log("canvasImage is NULL");
        }
        canvasImage.enabled = false;
        overlayCanvas.SetActive(true);
    }

    // Built in functions that subscribe and unsubscribe to the event
    void OnEnable()
    {
        ComboEventManager.Combo += OnCombo;
        UnityEngine.Debug.Log("registered event listener");
    }

    void OnDisable()
    {
        ComboEventManager.Combo -= OnCombo;
        UnityEngine.Debug.Log("deregistered event listener");
    }

    // Update is called once per frame
    void Update()
    {
        if (displayComboOverlay)
        {
            canvasImage.enabled = true;
        }
        else
        {
            canvasImage.enabled = false;
        }
    }

    public void OnCombo(ComboEventManager.ComboEventArgs args)
    {
        // Handle the event
        UnityEngine.Debug.Log(args.data);
        UnityEngine.Debug.Log("received combo event");
        displayComboOverlay = true;
        StartCoroutine(BooleanTimerCoroutine());
    }

    private IEnumerator BooleanTimerCoroutine()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1.0f);

        // Set the boolean back to false
        displayComboOverlay = false;
    }
}
