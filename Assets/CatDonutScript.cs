using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;


public class CatDonutScript : MonoBehaviour
{
    public float destroyDelay = 2.0f;
    public bool attached = false;
    public bool notCollided = true;

    public string DonutColor = "white";
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource incorrectSound;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("plate"))
        {
            // only works because the script is called PlateScript.cs
            PlateScript plateScript = collision.gameObject.GetComponent<PlateScript>();
            if (plateScript != null)
            {
                // bind the donut to the plate so that they move together
                transform.SetParent(collision.transform);

                if (collision.gameObject.name.Contains(DonutColor))
                {
                    UnityEngine.Debug.Log("Collided with matching plate: " + collision.gameObject.name);
                    if (notCollided)
                    {
                        notCollided = false;
                        correctSound.Play();
                        SendCombo();
                    }
                    Destroy(gameObject, destroyDelay);
                }
            }
        }
        else
        {
            UnityEngine.Debug.Log("Collided with : " + collision.gameObject.name);
            incorrectSound.Play();
        }
    }

    public void SendCombo()
    {
        // Do something that triggers the event
        ComboEventManager.ComboEventArgs args = new ComboEventManager.ComboEventArgs();
        args.data = "some data";
        ComboEventManager.SendCombo(args);
    }
}
