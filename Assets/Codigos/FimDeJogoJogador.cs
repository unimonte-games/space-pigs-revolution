using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            pn_total.Find("Bt Menu").GetComponent<Button>().interactable = true;
            var pnTw = pn_total.GetComponent<PnTween>();
            pnTw.Alternar(true);
            acabou = true;
            var geren = FindObjectOfType<GerenciadorJogo>();
            geren.DefFimDeJogo(true);
        }
    }
}
