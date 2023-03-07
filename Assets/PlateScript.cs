using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool moveForward = true;
    private Rigidbody rb;
    // list that stores all the donuts piled on this plate
    public List<Transform> childTransforms = new List<Transform>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // lock movement to the Z axis, lock rotation
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        Vector3 translation = Vector3.forward * moveSpeed * Time.deltaTime;
        if (!moveForward)
        {
            translation *= -1;
        }
        transform.Translate(translation);

        // Move all child objects along with the plate
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform != null)
            {
                childTransform.Translate(translation);
            }
        }

        // swap directions if we hit the edge of the table
        if (transform.position.z >= 4f)
        {
            moveForward = true;
        }

        if (transform.position.z <= -4f)
        {
            moveForward = false;
        }

    }
}