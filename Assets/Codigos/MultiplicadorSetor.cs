using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicadorSetor : MonoBehaviour
{
#if UNITY_EDITOR

    public float tamanhoSetor, larguraPrev;
    public bool previsualizar;

    [ContextMenu("Atualizar setores")]
    void ContextoAtualizar() { Atualizar(true);  }
    void        OnValidate() { Atualizar(false); }

    void Atualizar(bool atualizaFundo)
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

        if (atualizaFundo)
        {
            var fundo = GetComponent<SpriteRenderer>();
            if (fundo)
                fundo.size = new Vector2(30, tamanhoSetor + tamanhoSetor * tr.childCount * 2);
        }

    }

    Vector3[] posicoes_setor = new Vector3[0];
    Vector3[] tamanhos_setor = new Vector3[0];

    void OnDrawGizmos()
    {
        if (!previsualizar)
            return;

        Transform tr = GetComponent<Transform>();
        var posInicial = tr.position;
        var jogador_pos = GameObject.FindWithTag("Player").transform.position;

        int qtd_setores = tr.childCount;
        int i = 0;

        if (posicoes_setor.Length != qtd_setores)
        {
            posicoes_setor = new Vector3[qtd_setores];
            tamanhos_setor = new Vector3[qtd_setores];

            // calc posições
            for (i = 0; i < qtd_setores; i++)
            {
                posicoes_setor[i] = posInicial + new Vector3(0, i * tamanhoSetor, 0);
                tamanhos_setor[i] = new Vector3(larguraPrev, tamanhoSetor, 1f);
            }
        }
        else
        {
            for (i = 0; i < qtd_setores; i++)
            {
                Gizmos.color = i == 0 || tr.GetChild(i).childCount > 0
                    ? Color.white
                    : Color.red;


                bool jogador_no_setor
                    =  jogador_pos.y < posicoes_setor[i].y + tamanhoSetor/2
                    && jogador_pos.y > posicoes_setor[i].y - tamanhoSetor/2;


                // calc tamanhos
                tamanhos_setor[i] = Vector3.Lerp(
                    tamanhos_setor[i],
                    new Vector3(
                        jogador_no_setor ? tamanhoSetor : larguraPrev,
                        tamanhoSetor,
                        1f
                    ),
                    Time.deltaTime * 4
                );

                // desenha setores
                Gizmos.DrawWireCube(
                    posicoes_setor[i],
                    tamanhos_setor[i]
                );

                if (jogador_no_setor)
                {
                    Gizmos.color = Color.gray;

                    // desenha setores
                    Gizmos.DrawWireCube(
                        posicoes_setor[i],
                        new Vector3(larguraPrev, tamanhoSetor, 1f)
                    );
                }
            }
        }
    }

#endif
}
