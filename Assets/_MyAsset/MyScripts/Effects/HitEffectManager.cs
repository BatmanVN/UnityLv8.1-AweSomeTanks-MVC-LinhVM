using UnityEngine;

public class HitEffectManager : SingletonDontdestroy<HitEffectManager>
{
    public HitEffectMapper[] effectMap;
    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        HitEffectMapper mapper = System.Array.Find(effectMap, effect => effect.surface == surfaceType);
        return mapper?.effectPrefab;
    }
}
