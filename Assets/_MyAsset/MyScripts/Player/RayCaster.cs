using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private Camera aimingCamera;
    [SerializeField] private LayerMask layerMask;

    public void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefab, hitInfo.point, effectRotation);
            }
        }
    }
    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            ShowHitEffect(hitInfo);
        }
    }
    private void Update()
    {
        PerformRayCasting();
    }
}
