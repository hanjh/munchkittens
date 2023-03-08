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
    public GameObject nextDonut;
    public float distanceFromCamera = 2.0f;
    public float scale = 1.0f;
    public float nextScale = 0.1f;
    public float throwForce = 20.0f;
    public float spinForce = 20f;
    private static int parity = 1;
    private RandomEnumGenerator generator;
    private ColorEnum currentColor;

    [SerializeField] private AudioSource throwSoundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<RandomEnumGenerator>();
        currentColor = generator.GenerateRandomColorEnum();
        setDonut();
    }

    // Update is called once per frame
    void Update()
    {
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

            setDonut();
        }
    }

    public void setDonut() {
        switch (currentColor) {
            case ColorEnum.White:
                donut = whiteDonut;
                break;
            case ColorEnum.Black:
                donut = blackDonut;
                break;
            case ColorEnum.Orange:
                donut = orangeDonut;
                break;
            default:
                break;
        }
        if (nextDonut != null) {
            Destroy(nextDonut);
        }
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 cameraForward = mainCamera.transform.forward;

        Vector3 spawnPosition = cameraPosition + cameraForward * distanceFromCamera + Vector3.back;
        Vector3 nextDonutScale = new Vector3(nextScale, nextScale, nextScale);
        nextDonut = Instantiate(donut, spawnPosition, Quaternion.identity);
        nextDonut.transform.localScale = nextDonutScale;
        nextDonut.layer = LayerMask.NameToLayer("IgnoreLight");

        currentColor = generator.GenerateRandomColorEnum();
    }
}