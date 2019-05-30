using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    Vida vida;
    Image[] vidaImgs;
    Image[] vidaImgs_contorno;
    Color transparente = new Color(1f,1f,1f,0f);

    void Start()
    {
        var jogadorgbj = GameObject.FindWithTag("Player");
        vida = jogadorgbj.GetComponent<Vida>();

        vidaImgs = new Image[transform.childCount];
        vidaImgs_contorno = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            var ch = transform.GetChild(i);
            vidaImgs[i] = ch.Find("preenchimento").GetComponent<Image>();
            vidaImgs_contorno[i] = ch.Find("contorno").GetComponent<Image>();
        }
    }

    void Update()
    {
        for (int i = 0; i < vidaImgs.Length; i++)
        {
            if (i*4 <= vida.vida-4)
            {
                vidaImgs_contorno[i].color = Color.white;
                vidaImgs[i].fillAmount = 1f;
            }
            else if (i*4 < vida.vida)
            {
                vidaImgs_contorno[i].color = Color.white;
                vidaImgs[i].fillAmount = ((vida.vida % 4f)) / 4f;
            }
            else
            {
                vidaImgs[i].fillAmount = 0f;
            }
        }

        for (int i = 0; i < vidaImgs_contorno.Length; i++)
        {
            vidaImgs_contorno[i].color = (i*4 < VidaMaxJogador.vidaMax) ? Color.white : transparente;
        }
    }
}
