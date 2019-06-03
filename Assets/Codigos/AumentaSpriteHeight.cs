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
        s.y = Mathf.Sin(Time.time/5)*5 + 30;
        spr.size  = s;
    }
}
