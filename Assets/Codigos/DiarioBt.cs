using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiarioBt : MonoBehaviour//, IPointerEnterHandler
{
    public bool mouseEmCima;

    public void DefMouseEmCima(bool def)
    {
        mouseEmCima = def;
    }
}
