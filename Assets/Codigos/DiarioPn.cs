using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiarioPn : MonoBehaviour
{
    public RectTransform rtr;
    public bool aberto;
    public bool mouseEmCima;

    float minX, maxX;

    void Start()
    {
        minX = rtr.anchorMin.x;
        maxX = rtr.anchorMax.x;
    }

    [ContextMenu("Alternar")]
    public void Alternar()
    {
        aberto = !aberto;
        minX = aberto ? 0f : 1f;
        maxX = aberto ? 1f : 2f;
    }

    void Update()
    {
        var min = rtr.anchorMin;
        var max = rtr.anchorMax;

        min.x = Mathf.Lerp(min.x, minX, Time.deltaTime * 4);
        max.x = Mathf.Lerp(max.x, maxX, Time.deltaTime * 4);

        rtr.anchorMin = min;
        rtr.anchorMax = max;
    }
}
