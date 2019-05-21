using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiarioPn : MonoBehaviour
{
    public PnTween pn;
    public bool aberto;

    [ContextMenu("Alternar")]
    public void Alternar()
    {
        aberto = !aberto;
        pn.Alternar(aberto);
    }

    public void Alternar(bool def)
    {
        aberto = def;
        pn.Alternar(aberto);
    }
}
