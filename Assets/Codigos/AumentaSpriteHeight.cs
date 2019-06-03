using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentaSpriteHeight : MonoBehaviour
{
    SpriteRenderer spr;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var s = spr.size;
        s.y += 1 * Time.deltaTime;
        spr.size  = s;
    }
}
