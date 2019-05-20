using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoFases : MonoBehaviour
{

    public void ProximaFase()
    {
        string nome_fase_atual = SceneManager.GetActiveScene().name;
        int numb_fase_atual = int.Parse(nome_fase_atual.Substring(5));

        numb_fase_atual = numb_fase_atual + 1;
        string nome_fase = string.Concat("fase_", numb_fase_atual.ToString("00"));

        IrParaFase(nome_fase);
    }

    public void IrParaFase(string nome_fase)
    {
        SceneManager.LoadScene(nome_fase);
    }
}
