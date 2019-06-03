using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomConf : MonoBehaviour
{
    public bool isEfeitoSonoro;

    void Start()
    {
        AtualizaLocal();
    }

    public void Atualiza()
    {
        var todos = FindObjectsOfType<SomConf>();
        for (int i = 0; i < todos.Length; i++)
        {
            todos[i].AtualizaLocal();
        }
    }

    void AtualizaLocal()
    {
        bool conf = isEfeitoSonoro
            ? GerenciadorJogo.efsonsMudo
            : GerenciadorJogo.musicaMudo;

        GetComponent<AudioSource>().enabled = conf;
    }
}
