using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;


public class CatDonutScript : MonoBehaviour
{
    public float destroyDelay = 1.0f;
    public bool attached = false;
    public bool notCollided = true;
    public bool hitCorrectPlate = false;

    public string DonutColor = "white";
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource incorrectSound;
    [SerializeField] private AudioSource comboSoundEffect;

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
        // TODO clean up these if statements
        if (!collision.gameObject.name.Contains("plate"))
        {        
            if (!collision.gameObject.name.Contains("Donut"))
            {
                if (!collision.gameObject.name.Contains("table"))
                {
                    Destroy(gameObject, 0);
                }
                else
                {
                    notCollided = false;
                    UnityEngine.Debug.Log("Collided with : " + collision.gameObject.name);
                    if (!hitCorrectPlate)
                    {
                        incorrectSound.Play();
                        Destroy(gameObject, destroyDelay);
                        ResetComboCount();
                    }
                }
            }
            else {
                if (collision.gameObject.name.Contains(DonutColor))
                {
                    // we hit a donut of the same color before hitting the plate, do nothing for now
                    // we will likely hit the plate soon due to gravity
                }
            }
        }
        else
        {            
            // bind the donut to the plate so that they move together
            if (collision.contacts[0].normal.y > 0.5f)
            {
                transform.SetParent(collision.transform);
            }

            if (collision.gameObject.name.Contains(DonutColor))
            {
                UnityEngine.Debug.Log("Collided with matching plate: " + collision.gameObject.name);
                hitCorrectPlate = true;
                if (notCollided)
                {
                    notCollided = false;
                    correctSound.Play();
                    IncrementTotalScore();
                    IncrementComboCount();
                }
            }
            else
            {
                ResetComboCount();
            }
        }

    }

    public void IncrementTotalScore()
    {
        ComboEventManager.ComboEventArgs args = new ComboEventManager.ComboEventArgs();
        args.data = "incrementing total score";
        ComboEventManager.IncrementTotalScore(args);
    }

    public void ResetComboCount()
    {
        ComboEventManager.ComboEventArgs args = new ComboEventManager.ComboEventArgs();
        args.data = "resetting combo";
        ComboEventManager.ResetComboCount(args);
    }

    public void IncrementComboCount()
    {
        // Do something that triggers the event
        ComboEventManager.ComboEventArgs args = new ComboEventManager.ComboEventArgs();
        args.data = "incrementing combo";
        ComboEventManager.IncrementComboCount(args, comboSoundEffect);
    }
}
