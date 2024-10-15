using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSprite : MonoBehaviour
{
    Transform cameraTransform;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransform.transform.rotation * -Vector3.forward, cameraTransform.transform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
}
