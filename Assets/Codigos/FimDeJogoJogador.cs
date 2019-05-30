using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeJogoJogador : MonoBehaviour
{
    public Vida vida;
    public bool acabou;

    void Update()
    {
        if (vida.vida <= 0 && !acabou)
        {
            var canvasFJ = GameObject.Find("Canvas Game Over");
            var pn_total = canvasFJ.transform.Find("Pn Total");
            var pnTw = pn_total.GetComponent<PnTween>();
            pnTw.Alternar(true);
            acabou = true;
            var geren = FindObjectOfType<GerenciadorJogo>();
            geren.DefFimDeJogo(true);
        }
    }
}
