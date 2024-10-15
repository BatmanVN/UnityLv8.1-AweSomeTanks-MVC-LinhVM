using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokerShot : MonoBehaviour
{
    Transform cameraTransform;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransform.transform.rotation * -Vector3.forward, cameraTransform.transform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        this.gameObject.SetActive(true);
    }
    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        Invoke(nameof(Disable), 0.4f);
    }
}
