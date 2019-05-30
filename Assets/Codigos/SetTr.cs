using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTr : MonoBehaviour
{
    Transform tr;
    public float intervalo;
    public float x = 1;
    public float y = 1;

    public void Mul()
    {
        if (tr == null)
            tr = GetComponent<Transform>();

        var pos = tr.position;

        pos.x = pos.x * x;
        pos.y = pos.y * y;

        tr.position = pos;
    }

    void Start()
    {
        StartCoroutine(Repetir());
    }

    IEnumerator Repetir()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            Mul();
        }
    }
}
