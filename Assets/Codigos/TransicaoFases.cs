using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class TransicaoFases
{
    static int fase_atual = 1;

    public static void ProximaFase()
    {
        fase_atual = fase_atual + 1;
        string nome_fase = string.Concat("fase_", fase_atual.ToString("00"));
        SceneManager.LoadScene(nome_fase);
    }
}
