using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiseQndInvisivel : MonoBehaviour
{
    public ComparadorDistancia distancia;
    public bool destrutivel;
    Transform cam, tr;

    void Start()
    {
        cam = Camera.main.GetComponent<Transform>();
        tr  = GetComponent<Transform>();
        //StartCoroutine(Co_Update());
    }

    void Update()
    {
//        while (true)
//        {
            if (cam != null && tr != null)
            {
                if (!DentroDaDistancia(cam, tr) && destrutivel)
                {
                    Destroy(gameObject);
                    //break;
                }
            }
//            yield return new WaitForSeconds(0.25f);
//        }
    }

    bool DentroDaDistancia(Transform _cam, Transform _tr)
    {
        return distancia.DentroDaDistancia(_tr.position, _cam.position);
    }

    public void DefinirDestrutivel(bool def)
    {
        destrutivel = def;
    }

    #if UNITY_EDITOR

    public bool previsualizar;

    void OnDrawGizmos()
    {
        Transform _cam = Camera.main.GetComponent<Transform>();

        if (_cam == null || !previsualizar)
            return;

        Gizmos.color =
            DentroDaDistancia(_cam, transform)
                ? new Color(0, 1, 1)
                : new Color(1, 0, 1)
        ;

        var pontos = distancia.ObterPontosPraGizmos();
        var tr_pos = new Vector2(transform.position.x, transform.position.y);

        for (int i = 1; i < pontos.Length; i++)
            Gizmos.DrawLine(pontos[i-1] + tr_pos, pontos[i] + tr_pos);
        Gizmos.DrawLine(pontos[pontos.Length-1] + tr_pos, pontos[0] + tr_pos);
    }

#endif
}
