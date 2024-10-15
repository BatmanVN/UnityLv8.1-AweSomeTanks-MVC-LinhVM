using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSprite : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    Transform cameraTransform;
    private void LateUpdate()
    {
        effect.transform.LookAt(effect.transform.position + cameraTransform.transform.rotation * -Vector3.forward, cameraTransform.transform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(StringConst.bulletParaname))
        {
            effect.SetActive(true);
            Invoke(nameof(DeActive), .3f);
        }
    }
    public void DeActive()
    {
        effect.SetActive(false);
    }
}
