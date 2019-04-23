using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPerguntas : MonoBehaviour
{
    Pergunta perguntaEmUso;

    public void DefinirPerguntaEmUso(Pergunta p)
    {
        perguntaEmUso = p;
    }

    public void EvtAlternativaEscolhida(int indiceAlternativa)
    {        
        if (indiceAlternativa > 3)
            Debug.LogError("Alternativa não válida");

        // se alternativa tentada é a certa
        if (perguntaEmUso.resposta == indiceAlternativa && !perguntaEmUso.jaRespondida)
            ConfirmarAcerto();
    }

    void ConfirmarAcerto()
    {
        Debug.Log("Acerto confirmado!");
        // TODO: pegar melhoria aleatória
        // TODO: aplicar melhoria
        
        // marcar pergunta como usada
        perguntaEmUso.jaRespondida = true;
    }
}
