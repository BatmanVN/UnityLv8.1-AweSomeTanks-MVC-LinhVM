using UnityEngine;
using System;
using System.Collections.Generic;

public class HitEffectManager : SingletonDontdestroy<HitEffectManager>
{
    //public HitEffectMapper[] effectMap; // Dùng mảng sẽ phải Using System hoặc System.Array
    public List<HitEffectMapper> effectMap;
    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        //HitEffectMapper mapper = Array.Find(effectMap, effect => effect.surface == surfaceType);
        HitEffectMapper mapper = effectMap.Find(effect => effect.surface == surfaceType);
        return mapper?.effectPrefab;
    }
    private void Start()
    {
        
    }
}
