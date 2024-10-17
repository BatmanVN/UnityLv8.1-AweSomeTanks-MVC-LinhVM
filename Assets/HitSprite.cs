using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSprite : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource hitSound;
    Transform cameraTransform;
    private void LateUpdate()
    {
        effect.transform.LookAt(effect.transform.position + cameraTransform.transform.rotation * -Vector3.forward, cameraTransform.transform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(StringConst.bulletPlayer))
        {
            effect.SetActive(true);
            Invoke(nameof(DeActive), .3f);
            hitSound.Play();
        }
    }
    public void DeActive()
    {
        effect.SetActive(false);
    }
}
