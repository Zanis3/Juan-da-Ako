using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifeSpan = 1f;
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
