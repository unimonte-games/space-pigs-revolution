using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movese : MonoBehaviour
{
    public Vector3 dir, vel;
    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        var pos = tr.position;

        pos.x += dir.x * vel.x * Time.deltaTime;
        pos.y += dir.y * vel.y * Time.deltaTime;
        pos.z += dir.z * vel.z * Time.deltaTime;

        tr.position = pos;
    }
}
