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
    public GameObject cheeringCats;
    public Animator comboCatsAnimator;

    public Image canvasImage;

    IEnumerator comboCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        canvasImage = overlayCanvas.GetComponentInChildren<Image>();
        if (canvasImage == null)
        {
            UnityEngine.Debug.Log("canvasImage is NULL");
        }
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
    }

    public void OnCombo(ComboEventManager.ComboEventArgs args)
    {
        // Handle the event
        UnityEngine.Debug.Log(args.data);
        UnityEngine.Debug.Log("received combo event");
        
        comboCatsAnimator.CrossFade("ComboContainerActive", 0.2f);

        if (comboCoroutine != null) {
            StopCoroutine(comboCoroutine);
        }
        comboCoroutine = BooleanTimerCoroutine();
        StartCoroutine(comboCoroutine);
    }

    private IEnumerator BooleanTimerCoroutine()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2.0f);

        comboCoroutine = null;
        comboCatsAnimator.CrossFade("ComboContainerIdle", 4f);
    }
}
