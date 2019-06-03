using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour
{
    public bool pausado,
                fimDeJogo,
                emPergunta;

    public int pergsRespondidas;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            VidaMaxJogador.vidaMax = VidaMaxJogador.VIDA_MAX_INICIAL;
            BancoDePerguntas.ZerarPerguntasRespondidas();
        }
        pergsRespondidas = BancoDePerguntas.perguntasRespondidas;
    }

    public void DefPausado(bool def)
    {
        pausado = def;
    }

    public void DefFimDeJogo(bool def)
    {
        fimDeJogo = def;
        if (def)
            pausado = true;
    }
}
