using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateDonuts : MonoBehaviour
{
    public GameObject donut;
    public GameObject whiteDonut;
    public GameObject blackDonut;
    public GameObject orangeDonut;
    public float distanceFromCamera = 2.0f;
    public float scale = 0.1f;
    public float throwForce = 20.0f;
    public float spinForce = 20f;
    private static int parity = 1;

    [SerializeField] private AudioSource throwSoundEffect;
    [SerializeField] private AudioSource colorSoundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            colorSoundEffect.Play();
            donut = whiteDonut;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {   
            colorSoundEffect.Play();
            donut = blackDonut;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            colorSoundEffect.Play();
            donut = orangeDonut;
        }
        if (Input.GetMouseButtonDown(0))
        {
            throwSoundEffect.Play();
            Camera mainCamera = Camera.main;
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 cameraForward = mainCamera.transform.forward;

            Vector3 spawnPosition = cameraPosition + cameraForward * distanceFromCamera;
            Vector3 spawnScale = new Vector3(scale, scale, scale);

            GameObject newGameObject = Instantiate(donut, spawnPosition, Quaternion.identity);
            newGameObject.transform.localScale = spawnScale;
            Rigidbody rb = newGameObject.AddComponent<Rigidbody>();

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 throwDirection = mouseRay.direction;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            // reverse spin direction on every throw
            rb.AddTorque(transform.up * spinForce * parity, ForceMode.Impulse);
            parity *= -1;

        }
    }
}
