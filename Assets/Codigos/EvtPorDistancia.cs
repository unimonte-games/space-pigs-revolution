using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtPorDistancia : MonoBehaviour
{
    public float distancia;
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
            if (DentroDistancia())
            {
                evt.Invoke();
                jaAtivou = true;
            }
        }
        else if (!jaSaiu)
        {
            if (!DentroDistancia())
            {
                evtAoSair.Invoke();
                jaSaiu = true;
            }
        }
    }

    bool DentroDistancia()
    {
        return Vector3.Distance(tr.position, alvo_tr.position) <= distancia;
    }

    public void DefinirDistancia(float def)
    {
        distancia = def;
    }

#if UNITY_EDITOR

    public Color prever_Cor_Fora   = new Color(0, 0, 1, 0.5f);
    public Color prever_Cor_Dentro = new Color(0, 1, 0, 0.5f);

    void OnDrawGizmos()
    {
        Gizmos.color =
            alvo_tr == null 
                ? Color.red 
                :(
                    Vector3.Distance(transform.position, alvo_tr.position) <=  distancia
                        ? prever_Cor_Dentro
                        : prever_Cor_Fora
            );

        Gizmos.DrawWireSphere(transform.position, distancia);
    }

#endif
}
