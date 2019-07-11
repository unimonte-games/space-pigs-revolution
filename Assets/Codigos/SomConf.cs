using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomConf : MonoBehaviour
{
    public bool isEfeitoSonoro;

    public Toggle[] configuradores;

    bool ObterConf()
    {
        return isEfeitoSonoro
            ? GerenciadorJogo.efsonsMudo
            : GerenciadorJogo.musicaMudo;
    }

    void Start()
    {
        bool conf = ObterConf();
        for (int i = 0; i < configuradores.Length; i++)
            {configuradores[i].isOn = conf; print("isOn" + conf.ToString());}

        AtualizaLocal();
    }

    public void Atualiza()
    {
        var todos = FindObjectsOfType<SomConf>();
        for (int i = 0; i < todos.Length; i++)
            todos[i].AtualizaLocal();
    }

    void AtualizaLocal()
    {
        GetComponent<AudioSource>().enabled = ObterConf();
    }
}
