using UnityEngine;

public class camracon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Camera cam;

    float xMouse;
    float yMouse;

    float xRotation;
    float yRotation;

    public float ySensitivity;
    public float xSensitivity;

    float multiplier = 0.01f;
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        getinput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    void getinput()
    {
        xMouse = Input.GetAxisRaw("Mouse X");
        yMouse = Input.GetAxisRaw("Mouse Y");

        yRotation += xMouse * xSensitivity * multiplier;
        xRotation -= yMouse * ySensitivity * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
