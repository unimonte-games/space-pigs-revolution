using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtPorDistancia : MonoBehaviour
{
    public ComparadorDistancia distancia;
    public Transform alvo_tr;
    public UnityEngine.Events.UnityEvent evt, evtAoSair;

    bool jaAtivou, jaSaiu;


    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (alvo_tr == null)
            return;

        if (!jaAtivou)
        {
            if (distancia.DentroDaDistancia(tr.position, alvo_tr.position))
            {
                evt.Invoke();
                jaAtivou = true;
            }
        }
        else if (!jaSaiu)
        {
            if (!distancia.DentroDaDistancia(tr.position, alvo_tr.position))
            {
                evtAoSair.Invoke();
                jaSaiu = true;
            }
        }
    }

    public void DefinirDistancia(float def)
    {
        distancia.distancia = def;
    }

#if UNITY_EDITOR

    public Color prever_Cor_Fora   = new Color(0, 0, 1, 0.5f);
    public Color prever_Cor_Dentro = new Color(0, 1, 0, 0.5f);
    public bool previsualizar;

    void OnDrawGizmos()
    {
        if (!previsualizar)
            return;

        Vector2 tr_pos = new Vector2(transform.position.x, transform.position.y);

        Gizmos.color =
            alvo_tr == null
                ? Color.red
                :(
                    distancia.DentroDaDistancia(tr_pos, alvo_tr.position)
                        ? prever_Cor_Dentro
                        : prever_Cor_Fora
            );

        var pontos = distancia.ObterPontosPraGizmos();
        for (int i = 1; i < pontos.Length; i++)
            Gizmos.DrawLine(pontos[i-1] + tr_pos, pontos[i] + tr_pos);
        Gizmos.DrawLine(pontos[pontos.Length-1] + tr_pos, pontos[0] + tr_pos);
    }

#endif
}
