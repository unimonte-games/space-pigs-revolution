using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorteChefao : MonoBehaviour
{
    Vida vida;
    bool tranca;

    void Awake()
    {
        vida = GetComponent<Vida>();
    }

    void Update()
    {
        if (vida.vida <= 0 && !tranca)
        {
            tranca = true;

            FindObjectOfType<GerenciadorJogo>().DefPausado(true);

            GetComponent<Coreografia>().enabled = false;
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetTrigger("Derrotado");

            for (int i = 0; i < transform.childCount; i++)
            {
                var inst = transform.GetChild(i).GetComponent<Instanciador>();
                if (inst)
                    inst.enabled = false;
                var evtpt = transform.GetChild(i).GetComponent<EvtPorTempo>();
                if (evtpt)
                    evtpt.enabled = false;
            }

            StartCoroutine(co());
        }
    }

    IEnumerator co()
    {
        var jogador = GameObject.FindWithTag("Player");
        var j_anim = jogador.GetComponent<Animator>();

        j_anim.SetTrigger("Rodopio");

        yield return new WaitForSeconds(2f);

        var pntr = GameObject
            .Find("Canvas FinalChefao")
            .GetComponent<Transform>()
            .GetChild(0);



        pntr.GetComponent<PnTween>().Alternar(true);
        pntr.GetChild(0).GetComponent<Button>().interactable = true;
    }
}
