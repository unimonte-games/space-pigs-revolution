using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueGbj : MonoBehaviour
{
    public Transform gbj_tr;
    public Vector3 deslocamento, intensidade;
    Vector3 posResultado;

    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }


    void Update()
    {
        Seguir();
    }

#if UNITY_EDITOR
    [ContextMenu("Rodar função")]
#endif

    void Seguir()
    {
#if UNITY_EDITOR
        if (tr == null)
            tr = GetComponent<Transform>();
#endif

        if (tr && gbj_tr)
        {
            posResultado = gbj_tr.position;

            posResultado.x *= intensidade.x;
            posResultado.y *= intensidade.y;
            posResultado.z *= intensidade.z;

            posResultado += deslocamento;

            tr.position = posResultado;
        }
    }

}
