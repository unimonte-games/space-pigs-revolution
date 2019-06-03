using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida;
    public AudioSource audio;

    Animator anim;
    ParticleSystem fumacaPs;

    bool jaObteuCompos;


    /// Desconta vida pelo dano,
    /// talvez a vida descontada não seja a mesma do dano
    /// por conta da possível presença do escudo.
    /// Retorna a vida descontada.
    public int CausarDano(int dano)
    {
        // TODO: Implementar efeito de escudo
        vida -= dano;

        if (!jaObteuCompos)
        {
            anim = GetComponent<Animator>();

            var fumaca_tr = transform.Find("fumaca");
            if (fumaca_tr)
                fumacaPs = fumaca_tr.GetComponent<ParticleSystem>();

            jaObteuCompos = true;
        }

        if (anim != null)
            anim.SetTrigger("LevouDano");

        if (fumacaPs != null)
            fumacaPs.Play();

        if (audio != null)
            audio.Play();

        return dano;
    }
}
