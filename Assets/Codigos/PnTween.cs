using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnTween : MonoBehaviour
{
    public RectTransform rtr;

    public bool horizontal;
    public float abertoMin, abertoMax, fechadoMin, fechadoMax;
    float min, max;
    public bool aberto;

    void Start()
    {
        if (horizontal)
        {
            min = rtr.anchorMin.x;
            max = rtr.anchorMax.x;
        }
        else
        {
            min = rtr.anchorMin.y;
            max = rtr.anchorMax.y;
        }
    }

    public void Alternar()
    {
        Alternar(!aberto);
    }

    public void Alternar(bool def)
    {
        aberto = def;
        min = aberto ? abertoMin : fechadoMin;
        max = aberto ? abertoMax : fechadoMax;
    }

    void Update()
    {
        var anc_min = rtr.anchorMin;
        var anc_max = rtr.anchorMax;

        if (horizontal)
        {
            anc_min.x = Mathf.Lerp(anc_min.x, min, Time.deltaTime * 4);
            anc_max.x = Mathf.Lerp(anc_max.x, max, Time.deltaTime * 4);
        }
        else
        {
            anc_min.y = Mathf.Lerp(anc_min.y, min, Time.deltaTime * 4);
            anc_max.y = Mathf.Lerp(anc_max.y, max, Time.deltaTime * 4);
        }

        rtr.anchorMin = anc_min;
        rtr.anchorMax = anc_max;
    }
}
