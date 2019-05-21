using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiarioBt : MonoBehaviour, IPointerEnterHandler
{
    public DiarioPn diario;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //diario.mouseEmCima = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //diario.mouseEmCima = false;
    }
}
