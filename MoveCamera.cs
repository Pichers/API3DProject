using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPos;
    void Update()
    {
        transform.position = cameraPos.position;
        transform.rotation = cameraPos.rotation;
    }
}