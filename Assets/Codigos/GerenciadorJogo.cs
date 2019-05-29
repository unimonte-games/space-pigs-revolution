using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    public bool pausado,
                fimDeJogo;

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
