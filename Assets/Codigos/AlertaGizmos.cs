using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertaGizmos : MonoBehaviour
{
    const float escalaY = 5f;
    const float escalaX = escalaY/4f;

    public static void Exclamacao(Vector3 posicao)
    {

        // coordenadas de ajuda
        float espaco = escalaY * 0.1f;
        float tamanho_ponto = escalaY * 0.2f;
        float altura_traco = escalaY - tamanho_ponto - espaco;

        float pos_ponto = tamanho_ponto / 2;
        float pos_traco = (altura_traco / 2) + tamanho_ponto + espaco;

        Vector3 vec = new Vector3();

        // desenho do ponto
        vec.y = pos_ponto;
        Gizmos.DrawCube(vec + posicao, new Vector3(escalaX, tamanho_ponto, 1f));

        // desenho do traço
        vec.y = pos_traco;
        Gizmos.DrawCube(vec + posicao, new Vector3(escalaX, altura_traco, 1f));
    }

    void OnDrawGizmos()
    {
        var evtsPorDistancia = FindObjectsOfType<EvtPorDistancia>();

        const float deslocamento = escalaX / 0.5f;
        Vector3 orig_pos = Vector3.zero;
        Vector3 pos = Vector3.zero;

        Gizmos.color = Color.yellow;

        for (uint i = 0; i < evtsPorDistancia.Length; i++)
        {
            if (evtsPorDistancia[i].alvo_tr == null)
            {
                orig_pos = evtsPorDistancia[i].transform.position;
                pos = orig_pos;
                pos.x += deslocamento * i + 10f;
                Exclamacao(pos);
                Gizmos.DrawLine(orig_pos, pos);
            }
        }
    }
}
