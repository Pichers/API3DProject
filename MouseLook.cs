using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Player;

    public float MouseSens = 10;

    public float x = 0;
    public float y = 0;

    public Transform orientation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //INPUT
        y += Input.GetAxis("Mouse X") * MouseSens;
        x -= Input.GetAxis("Mouse Y") * MouseSens;

        //CLAMPING
        x = Mathf.Clamp(x, -90, 90);

        //ROTATION
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, y, 0);

        //CURSOR
        if (Input.GetKeyDown(KeyCode.Escape)&& Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
