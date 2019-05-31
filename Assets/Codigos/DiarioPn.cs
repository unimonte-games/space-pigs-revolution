using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DiarioPn : MonoBehaviour
{
    public PnTween pn;
    public bool aberto;
    GerenciadorJogo gerenJogo;

    void Start()
    {
        gerenJogo = FindObjectOfType<GerenciadorJogo>();
    }

    [ContextMenu("Alternar")]
    public void Alternar()
    {
        aberto = !aberto;
        gerenJogo.pausado = aberto;
        pn.Alternar(aberto);
    }

    public void Alternar(bool def)
    {
        aberto = def;
        pn.Alternar(aberto);
        if (SceneManager.GetActiveScene().name != "Menu")
            gerenJogo.pausado = def;
    }
}
