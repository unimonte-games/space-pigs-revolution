using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPn : MonoBehaviour
{
    public PnTween menuPn;
    public DiarioPn diario;
    public bool aberto;

    [ContextMenu("Alternar")]
    public void Alternar()
    {
        aberto = !aberto;
        menuPn.Alternar(aberto);
        diario.Alternar(!aberto);
    }
}
