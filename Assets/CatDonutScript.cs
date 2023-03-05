using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CatDonutScript : MonoBehaviour
{
    public float destroyDelay = 2.0f;

    public string DonutColor = "white";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains(DonutColor))
        {
            UnityEngine.Debug.Log("Collided with matching plate: " + collision.gameObject.name);
            Destroy(gameObject, destroyDelay);
        }
        else
        {
            UnityEngine.Debug.Log("Collided with : " + collision.gameObject.name);
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
}
