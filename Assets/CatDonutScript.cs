using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class CatDonutScript : MonoBehaviour
{
    public float destroyDelay = 2.0f;

    public string DonutColor = "white";

    private bool attached = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("plate") && !attached)
        {
            // only works because the script is called PlateScript.cs
            PlateScript plateScript = collision.gameObject.GetComponent<PlateScript>();
            if (plateScript != null)
            {
                // bind the donut to the plate so that they move together
                attached = true;
                transform.parent = collision.gameObject.transform;
                plateScript.childTransforms.Add(transform);

                if (collision.gameObject.name.Contains(DonutColor))
                {
                    UnityEngine.Debug.Log("Collided with matching plate: " + collision.gameObject.name);
                    Destroy(gameObject, destroyDelay);
                    SendCombo();
                }
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendCombo()
    {
        // Do something that triggers the event
        ComboEventManager.ComboEventArgs args = new ComboEventManager.ComboEventArgs();
        args.data = "some data";
        ComboEventManager.SendCombo(args);
    }
}
