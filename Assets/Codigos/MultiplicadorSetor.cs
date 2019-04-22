using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicadorSetor : MonoBehaviour
{
#if UNITY_EDITOR

    public float tamanhoSetor, larguraPrev;
    public bool previsualizar;

    [ContextMenu("Atualizar setores")]
    void Atualizar()
    {
        Transform tr = GetComponent<Transform>();

        for (int i = 0; i < tr.childCount; i++)
        {
            var child = tr.GetChild(i);
            var pos = child.localPosition;
            pos.y = tamanhoSetor * i;
            child.localPosition = pos;
        }

        var coreografias = FindObjectsOfType<Coreografia>();
        for (int i = 0; i < coreografias.Length; i++)
            coreografias[i].DEBUG_AtualizaPreverTr();
    }

    void OnValidate()
    {
        Atualizar();
    }

    void OnDrawGizmos()
    {
        if (!previsualizar)
            return;

        Transform tr = GetComponent<Transform>();
        var posInicial = tr.position;

        for (int i = 0; i < tr.childCount; i++)
        {
            Gizmos.DrawWireCube(
                posInicial + new Vector3(0, i * tamanhoSetor, 0),
                new Vector3(larguraPrev, tamanhoSetor, 1f)
            );
        }
    }

#endif
}
