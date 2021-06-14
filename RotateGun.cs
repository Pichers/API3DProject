using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Grapple grapple;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;
    

    void Update()
    {
        if (!grapple.IsGrappling())
            desiredRotation = transform.parent.rotation;
        else
            desiredRotation = Quaternion.LookRotation(grapple.GetGrapplePoint() - transform.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
